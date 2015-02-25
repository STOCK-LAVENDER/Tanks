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
            if (hitObject is Ammunition)
            {
                Ammunition ammunition = (Ammunition)hitObject;
                this.HealthPoints -= ammunition.PhysicalAttack - this.PhysicalDefense;
                this.State = GameObjectState.Damaged;
            }

            if (this.HealthPoints <= 0)
            {
                this.State = GameObjectState.Destroyed;
            }
        }

        public void Shoot(Direction direction)
        {
            Rectangle bulletPosition;
            int rectangleBulletMinimizedWidth = this.Rectangle.Width / 3;
            int rectangleBulletMinimizedHeight = this.Rectangle.Height / 3;

            switch (direction)
            {
                case Direction.Down:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X + (this.Rectangle.Width / 3), 
                        this.Rectangle.Y + this.Rectangle.Height, 
                        rectangleBulletMinimizedWidth, 
                        rectangleBulletMinimizedHeight);
                    break;
                case Direction.Up:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X + (this.Rectangle.Width / 3), 
                        this.Rectangle.Y - (this.Rectangle.Height / 2), 
                        rectangleBulletMinimizedWidth, 
                        rectangleBulletMinimizedHeight);
                    break;
                case Direction.Left:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X - (this.Rectangle.Width / 2), 
                        this.Rectangle.Y + (this.Rectangle.Height / 4), 
                        rectangleBulletMinimizedWidth, 
                        rectangleBulletMinimizedHeight);
                    break;
                case Direction.Right:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X + this.Rectangle.Width, 
                        this.Rectangle.Y + (this.Rectangle.Height / 4), 
                        rectangleBulletMinimizedWidth, 
                        rectangleBulletMinimizedHeight);
                    break;
                default:
                    throw new Exception();
            }

            GameEngine.GameObjects.Add(new Bullet(GameEngine.BulletTexture, bulletPosition, this.PhysicalAttack, direction));
        }
    }
}
