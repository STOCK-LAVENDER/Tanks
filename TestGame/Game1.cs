#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace TestGame
{
    using TextureAtlas;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private string canYouSeeMe;
        public static int windowWidth = 1200;
        public static int windowHeight = 1000;

        private Texture2D background;
        private Texture2D shuttle;
        private Texture2D earth;
        private SpriteFont font;
        private int score = 0;
        private AnimatedSprite animatedSprite;
        private Texture2D arrow;
        private float angle = 0;
        

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;

             
            graphics.ApplyChanges();
            
            this.IsMouseVisible = true;
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
            background = Content.Load<Texture2D>("Graphics/stars"); // change these names to the names of your images
            shuttle = Content.Load<Texture2D>("Graphics/shuttle");  // if you are using your own images.
            earth = Content.Load<Texture2D>("Graphics/earth");
            font = Content.Load<SpriteFont>("Graphics/SpriteFont1");
            Texture2D texture = Content.Load<Texture2D>("Graphics/SmileyWalk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);
            arrow = Content.Load<Texture2D>("Graphics/arrow");

            // TODO: use this.Content to load your game content here
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

            score++;
            angle += 0.01f;
            // TODO: Add your update logic here
            animatedSprite.Update();
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

            spriteBatch.Draw(background, new Rectangle(0, 0, windowWidth, windowHeight), Color.White);
            spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);

            spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.Wheat);
            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height);

            spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);

            spriteBatch.End();
            animatedSprite.Draw(spriteBatch);
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
