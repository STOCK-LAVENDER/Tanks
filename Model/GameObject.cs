namespace UltimateTankClash.Model
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public abstract class GameObject
    {
        public Rectangle rect;
        public Texture2D objTexture;
        private double positionX;
        private double positionY;
        private double width;
        private double height;

        protected GameObject(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
        {
            this.objTexture = objTexture;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Width = width;
            this.Height = height;
            this.rect = new Rectangle((int)positionX, (int)positionY, objTexture.Width, objTexture.Height);
        }

        public virtual double PositionX
        {
            get
            {
                return this.positionX;
            }

            protected set
            {
                this.positionX = value;
            }

        }

        public virtual double PositionY
        {
            get
            {
                return this.positionY;
            }

            protected set
            {
                this.positionY = value;
            }

        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                this.width = value;
            }

        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                this.height = value;
            }

        }
    }
}
