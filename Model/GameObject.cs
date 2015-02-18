namespace UltimateTankClash.Model
{
    using System.Windows.Forms.VisualStyles;
    using Exceptions;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public abstract class GameObject
    {
        public Texture2D objTexture;
        private Vector2 position;
        private Vector2 size;
        private Rectangle rectangle;

        protected GameObject(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
        {
            this.objTexture = objTexture;
            this.Position = position;
            this.Size = size;
            this.objTexture = objTexture;
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
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
                    throw new InvalidObjectParameterException(
                        "size", 
                        "the size of the object should be greater than zero on all dimensions.");
                }

                this.size = value;
            }

        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)this.Position.X,
                    (int)this.Position.Y,
                    (int)this.Size.X,
                    (int)this.Size.Y);
            }

            set
            {
                this.rectangle = value;
            }
        }

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
