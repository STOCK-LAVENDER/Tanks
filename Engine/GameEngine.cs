namespace UltimateTankClash.Engine
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using Models;
    using Models.AmmunitionItems;
    using Models.Characters;
    using Models.CollectibleItems;
    using Models.GameObstacles;
    using Models.Hideouts;
    using Resources.Sounds;

    #endregion

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        public const int WindowWidth = 1024;
        public const int WindowHeight = 640;

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

        public static int Level = 0;
        private SpriteFont gamePauseFont;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Sound fields
        private SoundEffect soundTankShootingEffect;
        public static SoundEffectInstance SoundTankShootingInstance;
        private Song backgroundSong;

        private bool isGamePaused;
        private IController controller;

        public GameEngine(IController controller)
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.controller = controller;
            this.AttachControllerEvents();
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += this.ControlGamePause;
        }

        private void ControlGamePause(object sender, EventArgs args)
        {
            this.isGamePaused = !this.isGamePaused;
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
            //Sounds
            this.backgroundSong = this.Content.Load<Song>("Sound/SoundFX/Failing Defense-1");
            SoundHandler.HandleBackgroundSoundEffect(this.backgroundSong);
            this.soundTankShootingEffect = this.Content.Load<SoundEffect>("Sound/SoundFX/Gun_Shot-Marvin-1140816320 1");
            SoundTankShootingInstance = this.soundTankShootingEffect.CreateInstance();


            BasicTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            PlayerTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/playerSprite");
            //this.player = new Player(this.PlayerTankTexture, new Rectangle(25, 25, this.PlayerTankTexture.Width, this.PlayerTankTexture.Height), this.SoundTankShootingInstance);
            //this.enemyTank = new BasicTank(this.BasicTankTexture, new Rectangle(500, 400, 50, 50));
            FastTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/fastTank");

            BasicWallTexture = this.Content.Load<Texture2D>("Graphics/Sprites/Bricks");
            BasicBushTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            BulletTexture = this.Content.Load<Texture2D>("Graphics/Sprites/cannonBullet");
            BunkerTexture = this.Content.Load<Texture2D>("Graphics/Sprites/turret");
            ArmorTexture = this.Content.Load<Texture2D>("Graphics/Sprites/armorSprite");
            HealthTexture = this.Content.Load<Texture2D>("Graphics/Sprites/healthConsumableSprite");
            ShieldTexture = this.Content.Load<Texture2D>("Graphics/Sprites/shieldSprite");
            SpeedPowerUpTexture = this.Content.Load<Texture2D>("Graphics/Sprites/speedPowerUpTexture");

            //speedPowerUp = new SpeedPowerUp(this.SpeedUpEffectTexture, new Rectangle(20, 160, 50, 50));

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
                var walls = GameObjects.Where(x => !(x is Ammunition)).ToList();
                var ammo = GameObjects.Where(x => x is Ammunition).ToList();

                for (int i = 0; i < GameObjects.Count; i++)
                {
                    GameObjects[i].Update();
                }

                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].RespondToCollision(CollisionHandler.GetCollisionInfo(walls[i]));
                }

                for (int i = 0; i < ammo.Count; i++)
                {
                    ammo[i].RespondToCollision(CollisionHandler.GetCollisionInfo(ammo[i]));
                }

                GameObjects.RemoveAll(x => x.State == GameObjectState.Destroyed);
            }
            
            base.Update(gameTime);
            this.controller.ProcessUserInput();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();

            if (this.isGamePaused)
            {
                this.spriteBatch.DrawString(this.gamePauseFont, "Paused", new Vector2(WindowWidth / 3, WindowHeight / 3), Color.BlanchedAlmond);
            }

            var characters = GameObjects.Where(x => x is Character);
            var obstacles = GameObjects.Where(x => x is Obstacle || x is Hideout || x is CollectibleItem);
            var bullets = GameObjects.Where(x => x is Ammunition);

            foreach (var character in characters)
            {
                character.Draw(this.spriteBatch);
            }

            foreach (var character in obstacles)
            {
                character.Draw(this.spriteBatch);
            }

            foreach (var character in bullets)
            {
                character.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
