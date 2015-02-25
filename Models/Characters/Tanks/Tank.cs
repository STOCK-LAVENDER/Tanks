namespace UltimateTankClash.Models.Characters.Tanks
{
    using System;
    using AmmunitionItems;
    using Engine;
    using Exceptions;
    using GameObstacles;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Tank : Character, IMoveable
    {
        private const float AngleUp = 0f;
        private const float AngleDown = (float)Math.PI;
        private const float AngleRight = (float)Math.PI / 2;
        private const float AngleLeft = (float)(Math.PI * 3 / 2);

        private float rotationAngle = 0f;
        private double speed;

        protected Tank(
            Texture2D objTexture,
            Rectangle rectangle,
            int physicalAttack,
            int physicalDefense,
            int healthPoints,
            double speed)
            : base(objTexture, rectangle, physicalAttack, physicalDefense, healthPoints)
        {
            this.Speed = speed;
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new InvalidObjectParameterException(
                        "speed",
                        "Speed cannot be negative.");
                }

                this.speed = value;
            }
        }

        public abstract void Move();

        public override void Update()
        {
            this.PreviousPosition = new Vector2(this.Rectangle.X, this.Rectangle.Y);
            this.Move();

            switch (this.Direction)
            {
                case Direction.Up:
                    this.rotationAngle = AngleUp;
                    this.rectangle.Y -= (int)this.Speed;
                    break;
                case Direction.Down:
                    this.rotationAngle = AngleDown;
                    this.rectangle.Y += (int)this.Speed;
                    break;
                case Direction.Left:
                    this.rotationAngle = AngleLeft;
                    this.rectangle.X -= (int)this.Speed;
                    break;
                case Direction.Right:
                    this.rotationAngle = AngleRight;
                    this.rectangle.X += (int)this.Speed;
                    break;
            }

            this.CheckBorderCollision();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character || hitObject is Obstacle || hitObject is Ammunition)
            {
                this.Rectangle = new Rectangle(
                    (int)this.PreviousPosition.X,
                    (int)this.PreviousPosition.Y,
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }

            base.RespondToCollision(hitObject);
        }

        public void CheckBorderCollision()
        {
            bool isOnLeftBorder = this.Rectangle.X - (this.objTexture.Width / 2) < 0;
            bool isOnRightBorder = this.Rectangle.X + (this.objTexture.Width / 2) > GameEngine.WindowWidth;
            bool isOnTopBorder = this.Rectangle.Y - (this.objTexture.Height / 2) < 0;
            bool isOnBottomBorder = this.Rectangle.Y + (this.objTexture.Height / 2) > GameEngine.WindowHeight;

            if (isOnLeftBorder)
            {
                this.rectangle.X = this.objTexture.Width / 2;
            }
            else if (isOnRightBorder)
            {
                this.rectangle.X = GameEngine.WindowWidth - (this.objTexture.Width / 2);
            }
            else if (isOnBottomBorder)
            {
                this.rectangle.Y = GameEngine.WindowHeight - (this.objTexture.Height / 2);
            }
            else if (isOnTopBorder)
            {
                this.rectangle.Y = this.objTexture.Height / 2;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
               this.objTexture,
               null,
               this.Rectangle,
               null,
               new Vector2(this.objTexture.Width / 2, this.objTexture.Width / 2),
               this.rotationAngle,
               Vector2.Zero,
               Color.White,
               SpriteEffects.None,
               0f);
        }
    }
}
