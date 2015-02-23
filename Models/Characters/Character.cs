namespace UltimateTankClash.Models.Characters
{
    using System;
    using AmmunitionItems;
    using Engine;
    using GameObstacles;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Tanks;

    public abstract class Character : GameObject, IAttack, IDestroyable
    {
        protected Character(
            Texture2D objTexture,
            Rectangle rectangle,
            int physicalAttack,
            int physicalDefense,
            int healthPoints)
            : base(objTexture, rectangle)
        {
            this.PhysicalAttack = physicalAttack;
            this.PhysicalDefense = physicalDefense;
            this.HealthPoints = healthPoints;
        }

        public int PhysicalAttack { get; protected set; }

        public Direction Direction { get; protected set; }

        public int PhysicalDefense { get; protected set; }

        public int HealthPoints { get; protected set; }

        public bool HasShot { get; protected set; }

        protected Vector2 PreviousPosition { get; set; }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character || hitObject is Obstacle || hitObject is Ammunition)
            {
                this.Rectangle = new Rectangle((int)this.PreviousPosition.X, (int)this.PreviousPosition.Y, this.Rectangle.Width, this.Rectangle.Height);
            }

            if (hitObject is Ammunition)
            {
                Ammunition ammunition = (Ammunition)hitObject;
                this.HealthPoints -= ammunition.PhysicalAttack;
            }

            if (this.HealthPoints <= 0)
            {
                this.State = GameObjectState.Destroyed;
            }
        }

        public void Shoot(Direction direction)
        {
            Rectangle bulletPosition;

            switch (direction)
            {
                case Direction.Down:
                    bulletPosition = new Rectangle(this.Rectangle.X, this.Rectangle.Y + this.Rectangle.Height, this.Rectangle.Width, this.Rectangle.Height);
                    break;
                case Direction.Up:
                    bulletPosition = new Rectangle(this.Rectangle.X, this.Rectangle.Y - this.Rectangle.Height, this.Rectangle.Width, this.Rectangle.Height);
                    break;
                case Direction.Left:
                    bulletPosition = new Rectangle(this.Rectangle.X - this.Rectangle.Width, this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
                    break;
                case Direction.Right:
                    bulletPosition = new Rectangle(this.Rectangle.X + this.Rectangle.Width, this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
                    break;
                default:
                    throw new Exception();
            }

            GameEngine.GameObjects.Add(new Bullet(GameEngine.BulletTexture, bulletPosition, this.PhysicalAttack, direction));
        }
    }
}
