namespace UltimateTankClash.Menus
{
    using System;
    using System.Collections.Generic;
    using Buttons;
    using Exceptions;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    abstract class Menu : IMenuItem
    {
        private Vector2 position;
        private Vector2 size;
        private List<Button> buttons;
        private Texture2D texture;
        private Color colour;
        private SpriteFont spriteFont;

        protected Menu(Texture2D texture, GraphicsDevice graphics)
        {
            this.Texture = texture;
            this.Rectangle = new Rectangle(
                (int)this.Position.X,
                (int)this.Position.Y,
                (int)this.Size.X,
                (int)this.Size.Y);
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


        public SpriteFont SpriteFont { get; protected set; }
    }
}
