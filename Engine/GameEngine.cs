namespace UltimateTankClash.Engine
{
    #region Using Statements
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Linq;
    using UltimateTankClash.Model.CollectibleItems;
    using UltimateTankClash.Model.CollectibleItems.PowerUpEffects;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.GameObstacles;
    using UltimateTankClash.Model.Characters.Vehicles;
    using UltimateTankClash.Model.GameObstacles.Walls;
    using UltimateTankClash.Model.GameObstacles.Bushes;
    #endregion

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<GameObject> gameObjects = new List<GameObject>();
        
        private Texture2D basicTankTexture;
        private BasicTank basicTank;
        private Enemy enemyTank;

        private Texture2D basicWallTexture;

        private Texture2D basicBushTexture;

        private Texture2D basicIceLakeTexture;
        
        private Texture2D speedUpEffectTexture;
        private SpeedPowerUp speedPowerUp;

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

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            basicTankTexture = Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            basicTank = new BasicTank(basicTankTexture, 30, 30, basicTankTexture.Width, basicTankTexture.Height, spriteBatch);
            enemyTank = new Enemy(basicTankTexture, 500, 400, basicTankTexture.Width, basicTankTexture.Height, spriteBatch);

            basicWallTexture = Content.Load<Texture2D>("Graphics/Sprites/basicWall");
            basicBushTexture = Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            basicIceLakeTexture = Content.Load<Texture2D>("Graphics/Sprites/icelake");
            speedUpEffectTexture = Content.Load<Texture2D>("Graphics/Sprites/speedy");
            speedPowerUp = new SpeedPowerUp(speedUpEffectTexture, 20, 160, speedUpEffectTexture.Width, speedUpEffectTexture.Height, spriteBatch);
            
            this.gameObjects = MapLoader.LoadMap(spriteBatch, basicWallTexture, basicBushTexture, basicIceLakeTexture);

            this.gameObjects.Add(speedPowerUp);
            CollissionHandler.Initialize(gameObjects,
                            GraphicsDevice.Viewport.Bounds.Right,
                            GraphicsDevice.Viewport.Bounds.Bottom);
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
            basicTank.Update();
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

            foreach (GameObject obstacle in gameObjects)
            {
                PowerUp effectItem = obstacle as PowerUp;
                if (effectItem != null && effectItem.State == CollectibleItemState.Active)
                {
                    //Dont draw
                }
                else
                {
                    obstacle.Draw();
                }
            }
            basicTank.Draw();
            enemyTank.Draw();
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
