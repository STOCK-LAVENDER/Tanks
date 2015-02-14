namespace UltimateTankClash.Engine
{
    #region Using Statements

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.Characters.Vehicles;
    using UltimateTankClash.Model.GameObstacles.Walls;
    #endregion

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<GameObject> gameObjects = new List<GameObject>();

        Texture2D basicTankTexture;
        BasicTank basicTank;

        Texture2D basicWallTexture;
        BasicWall basicWall;
        BasicWall basicWall2;

       
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

            // TODO: use this.Content to load your game content here
            basicTankTexture = Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            basicTank = new BasicTank(basicTankTexture, 30, 30, basicTankTexture.Width, basicTankTexture.Height,spriteBatch);
            basicWallTexture = Content.Load<Texture2D>("Graphics/Sprites/basicWall");
            basicWall = new BasicWall(basicWallTexture, 300, 265, basicWallTexture.Width, basicWallTexture.Height,spriteBatch);
            basicWall2 = new BasicWall(basicWallTexture, 300, 400, basicWallTexture.Width, basicWallTexture.Height, spriteBatch);

            gameObjects.Add(basicWall);
            gameObjects.Add(basicWall2);

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            basicTank.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            basicTank.Draw();

            foreach (GameObject obstacle in gameObjects) // draw all of the created obstacles
            {
                obstacle.Draw();
            }

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
