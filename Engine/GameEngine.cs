namespace UltimateTankClash.Engine
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Models;
    using Models.AmmunitionItems;
    using Models.Characters;
    using Models.Characters.Bunkers;
    using Models.Characters.Tanks;
    using Models.Characters.Tanks.Enemies;
    using Models.CollectibleItems;
    using Models.GameObstacles;
    using Models.Hideouts;
    using Resources.Sounds;
    using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
    using Keys = Microsoft.Xna.Framework.Input.Keys;

    #endregion

    /// <summary>
    /// This is the main type for our game
    /// </summary>
    public class GameEngine : Game
    {
        public const int WindowWidth = 1024;
        public const int WindowHeight = 640;
        public const int Offset = 25;

        public static List<GameObject> GameObjects = new List<GameObject>();
        public static SpriteFont Font;
        public static Texture2D BulletTexture;
        public static Texture2D BasicTankTexture;
        public static Texture2D PlayerTankTexture;
        public static Texture2D BasicWallTexture;
        public static Texture2D FastTankTexture;
        public static Texture2D BasicBushTexture;
        public static Texture2D SpeedUpEffectTexture;
        public static Texture2D BunkerTexture;
        public static Texture2D ArmorTexture;
        public static Texture2D HealthTexture;
        public static Texture2D ShieldTexture;
        public static Texture2D SpeedPowerUpTexture;
        public static Texture2D SteelWallTexture;
        public static GameLevel Level;
        public static SoundEffectInstance SoundTankShootingInstance;

        private SpriteFont gamePauseFont;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Sound fields
        private SoundEffect backgroundInGameSoundEffect;
        
        private bool isGamePaused;
        private bool isGameOver = false;
        private bool isGameWon = false;

        private IController controller;

        public GameEngine(IController controller)
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.controller = controller;
            this.AttachControllerEvents();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;
            this.graphics.ApplyChanges();
            Font = this.Content.Load<SpriteFont>("Graphics/Fonts/ArialFont");
            this.gamePauseFont = this.Content.Load<SpriteFont>("Graphics/Fonts/GamePauseFont");

            // Sounds
            this.backgroundInGameSoundEffect = this.Content.Load<SoundEffect>("Sound/SoundFX/Failing Defense");
            SoundHandler.HandleBackgroundSoundEffect(this.backgroundInGameSoundEffect);
            
            BasicTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            PlayerTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/playerSprite");
            FastTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/fastTank");
            BasicWallTexture = this.Content.Load<Texture2D>("Graphics/Sprites/Bricks");
            BasicBushTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            BulletTexture = this.Content.Load<Texture2D>("Graphics/Sprites/cannonBullet");
            BunkerTexture = this.Content.Load<Texture2D>("Graphics/Sprites/turret");
            ArmorTexture = this.Content.Load<Texture2D>("Graphics/Sprites/armorSprite");
            HealthTexture = this.Content.Load<Texture2D>("Graphics/Sprites/healthConsumableSprite");
            ShieldTexture = this.Content.Load<Texture2D>("Graphics/Sprites/shieldSprite");
            SpeedPowerUpTexture = this.Content.Load<Texture2D>("Graphics/Sprites/speedPowerUpTexture");
            SteelWallTexture = this.Content.Load<Texture2D>("Graphics/Sprites/steelWall");

            GameObjects = MapLoader.LoadMap(this.spriteBatch, Level);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (!this.isGamePaused)
            {
                var walls = GameObjects.Where(gameObject => !(gameObject is Ammunition) && !(gameObject is CollectibleItem)).ToList();
                var collectibles = GameObjects.Where(gameObject => gameObject is CollectibleItem).ToList();
                var ammo = GameObjects.Where(gameObject => gameObject is Ammunition).ToList();

                for (int i = 0; i < GameObjects.Count; i++)
                {
                    GameObjects[i].Update();
                }

                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].RespondToCollision(CollisionHandler.GetCollisionInfo(walls[i]));
                }

                for (int i = 0; i < collectibles.Count; i++)
                {
                    collectibles[i].RespondToCollision(CollisionHandler.GetCollisionInfo(collectibles[i]));
                }

                for (int i = 0; i < ammo.Count; i++)
                {
                    ammo[i].RespondToCollision(CollisionHandler.GetCollisionInfo(ammo[i]));
                }

                GameObjects.RemoveAll(x => x.State == GameObjectState.Destroyed);
            }
            
            this.HandleGameMute();

            this.CheckGameOver();

            base.Update(gameTime);
            this.controller.ProcessUserInput();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.DarkGoldenrod);
            this.spriteBatch.Begin();

            var characters = GameObjects.Where(gameObject => gameObject is Character);
            var obstacles = GameObjects.Where(gameObject => gameObject is Obstacle || gameObject is Hideout);
            var collectibles = GameObjects
                .Where(gameObject => gameObject is CollectibleItem && ((CollectibleItem)gameObject).ItemState == CollectibleItemState.Available);
            var bullets = GameObjects.Where(gameObject => gameObject is Ammunition);

            foreach (var character in characters)
            {
                character.Draw(this.spriteBatch);
            }

            foreach (var character in obstacles)
            {
                character.Draw(this.spriteBatch);
            }

            foreach (var item in collectibles)
            {
                item.Draw(this.spriteBatch);
            }

            foreach (var character in bullets)
            {
                character.Draw(this.spriteBatch);
            }

            if (this.isGamePaused)
            {
                if (this.isGameOver)
                {
                    const string GameLostMessage = "You were killed! Press Enter to go back and try again.";
                    const string GameWonMessage = "All enemies are destroyed! Press Enter to try another level.";
                    
                    this.spriteBatch.DrawString(
                        Font, 
                        this.isGameWon ? GameWonMessage : GameLostMessage,
                        new Vector2(50, WindowHeight - 100), 
                        Color.BlanchedAlmond);
                }
                else
                {
                    this.spriteBatch.DrawString(
                        this.gamePauseFont, 
                        "Paused", 
                        new Vector2(WindowWidth / 3, WindowHeight / 3), 
                        Color.BlanchedAlmond);
                }
            }

            this.spriteBatch.End();
           
            base.Draw(gameTime);
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += (sender, args) =>
            {
                this.isGamePaused = !this.isGamePaused;
            };

            this.controller.GameMute += (sender, args) =>
            {
                SoundHandler.IsGameMuted = !SoundHandler.IsGameMuted;
            };

            this.controller.GameRestart += (sender, args) =>
            {
                if (this.isGameOver)
                {
                    Application.Restart();
                }
            };
        }

        private void HandleGameMute()
        {
            SoundHandler.MuteBackgroundSounds();
        }

        private void CheckGameOver()
        {
            bool enemiesLeft = GameObjects.Any(gameObject => gameObject is EnemyTank || gameObject is Bunker);
            bool playerAlive = GameObjects.Any(gameObject => gameObject is Player);

            if (!enemiesLeft)
            {
                this.isGameOver = true;
                this.isGameWon = true;
            }
            else if (!playerAlive)
            {
                this.isGameOver = true;
                this.isGameWon = false;
            }

            if (this.isGameOver)
            {
                this.isGamePaused = true;
            }
        }
    }
}
