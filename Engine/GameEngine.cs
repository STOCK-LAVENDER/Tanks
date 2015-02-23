﻿namespace UltimateTankClash.Engine
{
    #region Using Statements
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Characters.Tanks;
    using Models.CollectibleItems;
    using Models.CollectibleItems.PowerUpEffects;

    #endregion

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static List<GameObject> GameObjects = new List<GameObject>();

        private Texture2D basicTankTexture;
        private Player player;
        private BasicTank enemyTank;
        public static SpriteFont font;
        private Texture2D basicWallTexture;

        private Texture2D basicBushTexture;

        private Texture2D basicIceLakeTexture;

        private Texture2D speedUpEffectTexture;
        private SpeedPowerUp speedPowerUp;

        public const int WindowWidth = 1024;
        public const int WindowHeight = 720;

        //Temporary variables

        public GameEngine()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.ApplyChanges();
            font = Content.Load<SpriteFont>("Graphics/Fonts/ArialFont");

            basicTankTexture = Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            player = new Player(basicTankTexture, new Rectangle(25, 25, 50, 50));
            enemyTank = new BasicTank(basicTankTexture, new Rectangle(500, 400, 50, 50));

            basicWallTexture = Content.Load<Texture2D>("Graphics/Sprites/basicWall");
            basicBushTexture = Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            basicIceLakeTexture = Content.Load<Texture2D>("Graphics/Sprites/icelake");
            speedUpEffectTexture = Content.Load<Texture2D>("Graphics/Sprites/speedy");
            speedPowerUp = new SpeedPowerUp(speedUpEffectTexture, new Rectangle(20, 160, 50, 50));

            GameObjects = MapLoader.LoadMap(spriteBatch, basicWallTexture, basicBushTexture, basicIceLakeTexture);
            GameObjects.Add(player);
            GameObjects.Add(enemyTank);

            GameObjects.Add(speedPowerUp);
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
                Exit();
            }

            speedPowerUp.Update();
            player.Update();
            enemyTank.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            foreach (GameObject obstacle in GameObjects)
            {
                PowerUp effectItem = obstacle as PowerUp;
                if (effectItem != null && effectItem.State == CollectibleItemState.Active)
                {
                    //Dont draw
                }
                else
                {
                    obstacle.Draw(spriteBatch);
                }
            }
            player.Draw(spriteBatch);
            enemyTank.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
