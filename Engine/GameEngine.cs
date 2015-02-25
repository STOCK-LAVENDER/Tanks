﻿namespace UltimateTankClash.Engine
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Runtime.Remoting.Channels;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using Models;
    using Models.AmmunitionItems;
    using Models.Characters;
    using Models.Characters.Tanks;
    using Models.CollectibleItems.PowerUpEffects;
    using Models.GameObstacles;
    using Models.GameObstacles.Walls;
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

        private Texture2D basicTankTexture;
        private Player player;
        private Texture2D playerTankTexture;
        private BasicTank enemyTank;
        private Texture2D basicWallTexture;
        private Texture2D orangeEnemyTankTexture;

        private GraphicsDeviceManager graphics;
        private SpriteFont spriteFont;
        private SpriteBatch spriteBatch;
        private Texture2D basicBushTexture;
        private Texture2D basicIceLakeTexture;
        private Texture2D speedUpEffectTexture;
        private SpeedPowerUp speedPowerUp;

        private bool isGamePaused;
        private IController controller;

        //Sound fields
        private SoundEffect soundTankShootingEffect;
        private SoundEffectInstance soundTankShootingInstance;
        private Song backgroundSong;

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
            this.controller.Pause += this.ControlGamePaused;
        }

        private void ControlGamePaused(object sender, EventArgs args)
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
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;
            this.graphics.ApplyChanges();
            Font = this.Content.Load<SpriteFont>("Graphics/Fonts/ArialFont");

            this.spriteFont = this.Content.Load<SpriteFont>("Graphics/Fonts/GamePauseFont");
            //Sounds
            this.backgroundSong = this.Content.Load<Song>("Sound/SoundFX/Failing Defense-1");
            SoundHandler.HandleBackgroundSoundEffect(this.backgroundSong);
            this.soundTankShootingEffect =
                this.Content.Load<SoundEffect>("Sound/SoundFX/Gun_Shot-Marvin-1140816320 1");
            this.soundTankShootingInstance = this.soundTankShootingEffect.CreateInstance();
            this.basicTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            this.playerTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/23vnh8n");
            this.player = new Player(this.playerTankTexture, new Rectangle(25, 25, this.playerTankTexture.Width, this.playerTankTexture.Height), this.soundTankShootingInstance);
            this.enemyTank = new BasicTank(this.basicTankTexture, new Rectangle(500, 400, 50, 50));
            this.orangeEnemyTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/tank");

            this.basicWallTexture = this.Content.Load<Texture2D>("Graphics/Sprites/Bricks");
            this.basicBushTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            this.basicIceLakeTexture = this.Content.Load<Texture2D>("Graphics/Sprites/icelake");
            this.speedUpEffectTexture = this.Content.Load<Texture2D>("Graphics/Sprites/speedy");
            BulletTexture = this.Content.Load<Texture2D>("Graphics/Sprites/cannonBullet");
            
            this.speedPowerUp = new SpeedPowerUp(this.speedUpEffectTexture, new Rectangle(20, 160, 50, 50));

            GameObjects = MapLoader.LoadMap(this.spriteBatch, this.basicWallTexture, this.basicBushTexture, this.basicIceLakeTexture);
            GameObjects.Add(this.player);
            GameObjects.Add(this.enemyTank);
            //Test adding second enemy tank. Delete this code before Production!
            GameObjects.Add(new BasicTank(this.orangeEnemyTankTexture, new Rectangle(300, 400, this.orangeEnemyTankTexture.Width, this.orangeEnemyTankTexture.Height)));
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

            this.controller.ProcessInput();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();

            var characters = GameObjects.Where(x => x is Character);
            var obstacles = GameObjects.Where(x => x is Obstacle || x is Hideout);
            var bullets = GameObjects.Where(x => x is Ammunition);

            if (this.isGamePaused)
            {
                this.spriteBatch.DrawString(this.spriteFont,
                                            "Game Paused",
                                            new Vector2(WindowWidth / 3, WindowHeight / 3),
                                            Color.DarkSeaGreen);
            }
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
