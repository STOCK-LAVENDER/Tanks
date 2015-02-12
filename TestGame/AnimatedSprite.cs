using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TextureAtlas
{
    using Microsoft.Xna.Framework.Input;
    using TestGame;

    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private KeyboardState oldState;


        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int x = mouseState.X;
                int y = mouseState.Y;

                if (0 <= x && x <= Game1.windowWidth - 50 && 0 <= y && y <= Game1.windowHeight - 50)
                {
                    this.X = x - 25;
                    this.Y = y - 25;
                }

            }

            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Left))
            {
                if (0 < this.X)
                {
                    this.X--;
                }
            }
            else if (newState.IsKeyDown(Keys.Right))
            {
                if (this.X < Game1.windowWidth - 50)
                {
                    this.X++;
                }
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                if (0 < this.Y)
                {
                    this.Y--;
                }
            }
            else if (newState.IsKeyDown(Keys.Down))
            {
                if (this.Y < Game1.windowHeight - 50)
                {
                    this.Y++;
                }
            }

            oldState = newState;  // set the new state as the old state for next time
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.X, (int)this.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}