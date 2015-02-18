namespace UltimateTankClash.Models.Characters.Tanks
{
    using System;
    using Exceptions;
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
            Vector2 position,
            Vector2 size,
            int physicalAttack,
            int physicalDefense,
            int healthPoints,
            double speed)
            : base(objTexture, position, size, physicalAttack, physicalDefense, healthPoints)
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

        public abstract void Move();

        public override void Update()
        {
            this.Move();
            //this.RespondToCollision(this);

            if (this.Direction == Direction.Up)
            {
                this.rotationAngle = angleUp;
                this.Position = new Vector2(this.Position.X, (int)(this.Position.Y - this.Speed));
                this.Rectangle = new Rectangle(
                    (int)this.Position.X,
                    (int)(this.Position.Y - this.Speed),
                    (int)this.Size.X,
                    (int)this.Size.Y);
            }
            else if (this.Direction == Direction.Down)
            {
                this.rotationAngle = angleDown;
                this.Position = new Vector2(this.Position.X, (int)(this.Position.Y + this.Speed));
                this.Rectangle = new Rectangle(
                    (int)this.Position.X,
                    (int)(this.Position.Y + this.Speed),
                    (int)this.Size.X,
                    (int)this.Size.Y);
            }
            else if (this.Direction == Direction.Left)
            {
                this.rotationAngle = angleLeft;
                this.Position = new Vector2((int)(this.Position.X - this.Speed), this.Position.Y);
                this.Rectangle = new Rectangle(
                    (int)(this.Position.X - this.Speed),
                    (int)this.Position.Y,
                    (int)this.Size.X,
                    (int)this.Size.Y);
            }
            else if (this.Direction == Direction.Right)
            {
                this.rotationAngle = angleRight;
                this.Position = new Vector2((int)(this.Position.X + this.Speed), this.Position.Y);
                this.Rectangle = new Rectangle(
                    (int)(this.Position.X + this.Speed),
                    (int)this.Position.Y,
                    (int)this.Size.X,
                    (int)this.Size.Y);
            }



            //this.RespondToCollision(this);
        }
    }
}
