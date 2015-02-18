namespace UltimateTankClash.Models
{
    using System.Windows.Forms.VisualStyles;
    using Engine;
    using Exceptions;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : ICollidable
    {
        public Texture2D objTexture;
        private Rectangle rectangle;

        protected GameObject(
            Texture2D objTexture,
            Rectangle rectangle)
        {
            this.objTexture = objTexture;

            this.Rectangle = rectangle;
        }

        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }

            set
            {
                if (value.Width <= 0 || value.Height <= 0)
                {
                    throw new InvalidObjectParameterException(
                        "size",
                        "The object should have positive width and height.");
                }

                this.rectangle = value;
            }
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.objTexture,
                new Rectangle(this.Rectangle.X - 25, this.Rectangle.Y - 25, this.Rectangle.Width, this.Rectangle.Height),
                Color.White);
        }

        public abstract void RespondToCollision(GameObject hitObject);
    }
}
