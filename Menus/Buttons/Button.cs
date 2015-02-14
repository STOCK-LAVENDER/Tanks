namespace UltimateTankClash.Menus.Buttons
{
    using System;
    using Exceptions;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    class Button : IMenuItem
    {
        private Vector2 position;
        private Vector2 size;
        private Texture2D texture;
        private Color colour;
        private Color initialColour;
        public bool isClicked;
        private SpriteFont spriteFont;
        private GraphicsDevice graphics;


        public Button(Vector2 position, Texture2D texture, Color colour, SpriteFont font, GraphicsDevice graphics)
        {
            this.Position = position;
            this.Texture = texture;
            this.Colour = colour;
            this.initialColour = this.Colour;
            this.spriteFont = font;
            this.Size = new Vector2(50, 50);
            this.Rectangle = new Rectangle(
                (int)this.Position.X, 
                (int)this.Position.Y, 
                (int)this.Size.X, 
                (int)this.Size.Y);

            this.graphics = graphics;
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
                if (value.X < 0 || 800 < value.X || value.Y < 0 || 600 < value.Y) // Use constants here
                {
                    throw new ObjectOutOfBoundsException(
                        "position",
                        this,
                        "The object was outside the boundaries of the playing field.");
                }

                this.position = value;
            }
        }

        public Vector2 Size
        {
            get
            {
                return this.size;
            }

            protected set
            {
                if (value.X <= 0 || value.Y <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "size",
                        "The size of the object should be positive on all dimensions.");
                }

                this.size = value;
            }
        }

        public Texture2D Texture { get; protected set; }

        public Color Colour { get; protected set; }

        public Rectangle Rectangle { get; protected set; }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(this.Rectangle))
            {
                this.Colour = Color.Red;

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    this.isClicked = true;
                    this.Colour = Color.Yellow;
                }
            }
            else
            {
                this.Colour = this.initialColour;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, this.Colour);
            spriteBatch.DrawString(spriteFont, "Click me!", new Vector2(100, 100), Color.Wheat);
        }


        public SpriteFont SpriteFont { get; protected set; }
    }
}
