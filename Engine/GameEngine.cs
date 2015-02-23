namespace UltimateTankClash.Engine
{
    #region Using Statements

    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Models;
    using Models.AmmunitionItems;
    using Models.Characters;
    using Models.Characters.Tanks;
    using Models.CollectibleItems.PowerUpEffects;
    using Models.GameObstacles;
    using Models.Hideouts;

    #endregion

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        public const int WindowWidth = 1024;
        public const int WindowHeight = 720;

        public static List<GameObject> GameObjects = new List<GameObject>();
        public static SpriteFont Font;
        public static Texture2D BulletTexture;

        private Texture2D basicTankTexture;
        private Player player;
        private BasicTank enemyTank;
        private Texture2D basicWallTexture;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D basicBushTexture;
        private Texture2D basicIceLakeTexture;
        private Texture2D speedUpEffectTexture;
        private SpeedPowerUp speedPowerUp;

        //Sound fields
        private SoundEffect soundTankShootingEffect;
        private SoundEffectInstance soundInstance;
        public GameEngine()
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;
            this.graphics.ApplyChanges();
            Font = Content.Load<SpriteFont>("Graphics/Fonts/ArialFont");

            //Sounds
            this.soundTankShootingEffect =
                this.Content.Load<SoundEffect>("Sound/SoundFX/MP5_SMG-GunGuru-703432894");
            this.soundInstance = soundTankShootingEffect.CreateInstance();
            this.basicTankTexture = Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            this.player = new Player(this.basicTankTexture, new Rectangle(25, 25, 50, 50), this.soundInstance);
            this.enemyTank = new BasicTank(this.basicTankTexture, new Rectangle(500, 400, 50, 50));

            this.basicWallTexture = Content.Load<Texture2D>("Graphics/Sprites/basicWall");
            this.basicBushTexture = Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            this.basicIceLakeTexture = Content.Load<Texture2D>("Graphics/Sprites/icelake");
            this.speedUpEffectTexture = Content.Load<Texture2D>("Graphics/Sprites/speedy");
            BulletTexture = Content.Load<Texture2D>("Graphics/Sprites/bullet");
            this.speedPowerUp = new SpeedPowerUp(this.speedUpEffectTexture, new Rectangle(20, 160, 50, 50));

            GameObjects = MapLoader.LoadMap(this.spriteBatch, this.basicWallTexture, this.basicBushTexture, this.basicIceLakeTexture);
            GameObjects.Add(this.player);
            GameObjects.Add(this.enemyTank);

            GameObjects.Add(this.speedPowerUp);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update();
                GameObjects[i].RespondToCollision(CollisionHandler.GetCollisionInfo(GameObjects[i]));
            }

            GameObjects.RemoveAll(x => x.State == GameObjectState.Destroyed);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();

            var characters = GameObjects.Where(x => x is Character);
            var obstacles = GameObjects.Where(x => x is Obstacle || x is Hideout);
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
