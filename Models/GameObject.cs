namespace UltimateTankClash.Models
{
    using Engine;
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
            Rectangle rect = new Rectangle(
                this.Rectangle.X - GameEngine.Offset,
                this.Rectangle.Y - GameEngine.Offset,
                this.Rectangle.Width,
                this.Rectangle.Height);

            spriteBatch.Draw(
                this.objTexture,
                rect,
                Color.White);
        }

        public abstract void RespondToCollision(GameObject hitObject);
    }
}
