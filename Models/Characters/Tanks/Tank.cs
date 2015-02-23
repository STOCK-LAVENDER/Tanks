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
        private double speed;
        protected float rotationAngle = 0f;
        private float angleUp = 0f;
        private float angleDown = (float)Math.PI;
        private float angleRight = (float)Math.PI / 2;
        private float angleLeft = (float)Math.PI + (float)Math.PI / 2;

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
                if (value <= 0)
                {
                    throw new InvalidObjectParameterException(
                        "speed",
                        "Speed should be greater than 0.");
                }

                this.speed = value;
            }
        }

        public Direction Direction { get; set; }

        private Vector2 PreviousPosition { get; set; }

        public abstract void Move();

        public override void Update()
        {
            this.PreviousPosition = new Vector2(this.Rectangle.X, this.Rectangle.Y);
            this.Move();

            if (this.Direction == Direction.Up)
            {
                this.rotationAngle = angleUp;

                this.Rectangle = new Rectangle(
                    this.Rectangle.X,
                    (int)(this.Rectangle.Y - this.Speed),
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }
            else if (this.Direction == Direction.Down)
            {
                this.rotationAngle = angleDown;

                this.Rectangle = new Rectangle(
                    this.Rectangle.X,
                    (int)(this.Rectangle.Y + this.Speed),
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }
            else if (this.Direction == Direction.Left)
            {
                this.rotationAngle = angleLeft;

                this.Rectangle = new Rectangle(
                    (int)(this.Rectangle.X - this.Speed),
                    this.Rectangle.Y,
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }
            else if (this.Direction == Direction.Right)
            {
                this.rotationAngle = angleRight;

                this.Rectangle = new Rectangle(
                    (int)(this.Rectangle.X + this.Speed),
                    this.Rectangle.Y,
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }

            this.CheckBorderCollision();
            this.RespondToCollision(CollisionHandler.GetCollisionInfo(this));

        }

        public void CheckBorderCollision()
        {
            bool isOnLeftBorder = this.Rectangle.X - this.objTexture.Width/2 < 0;
            bool isOnRightBorder = this.Rectangle.X + this.objTexture.Width/2 > GameEngine.WindowWidth;
            bool isOnTopBorder = this.Rectangle.Y - this.objTexture.Height/2 < 0;
            bool isOnBottomBorder = this.Rectangle.Y + this.objTexture.Height/2 > GameEngine.WindowHeight;

            if (isOnLeftBorder)
            {
                this.Rectangle = new Rectangle(this.objTexture.Width / 2, this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            }
            else if (isOnRightBorder)
            {
                this.Rectangle = new Rectangle(GameEngine.WindowWidth - this.objTexture.Width / 2, this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            }
            else if (isOnBottomBorder)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, GameEngine.WindowHeight - this.objTexture.Height / 2, this.Rectangle.Width, this.Rectangle.Height);
            }
            else if (isOnTopBorder)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.objTexture.Height/2, this.Rectangle.Width, this.Rectangle.Height);
            }
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            
            if (hitObject is Character || hitObject is Obstacle || hitObject is Ammunition)
            {
                this.Rectangle = new Rectangle((int)this.PreviousPosition.X, (int)this.PreviousPosition.Y, this.Rectangle.Width, this.Rectangle.Height);
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
               rotationAngle,
               Vector2.Zero,
               Color.White,
               SpriteEffects.None,
               0f);
        }
    }
}
