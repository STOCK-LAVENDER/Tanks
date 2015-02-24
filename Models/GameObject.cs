namespace UltimateTankClash.Models
{
    using Exceptions;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : ICollidable
    {
        protected Texture2D objTexture;
        protected Rectangle rectangle;

        protected GameObject(
            Texture2D objTexture,
            Rectangle rectangle)
        {
            this.objTexture = objTexture;
            this.State = GameObjectState.Intact;
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

        public GameObjectState State { get; set; }

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
