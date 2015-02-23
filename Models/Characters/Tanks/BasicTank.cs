namespace UltimateTankClash.Models.Characters.Tanks
{
    using System;
    using GameObstacles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicTank : Tank
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 100;
        private const int DefaultHealthPoints = 1000;
        private const int DefaultSpeed = 3;
        private const int TimeBetweenDirectionSwitches = 50;

        private static readonly string[] Directions = Enum.GetNames(typeof(Direction));
        private static Random rnd = new Random();

        private int ticks = 0;
        private Direction currentDirection = Direction.Up;

        public BasicTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
        }

        public override void Move()
        {
            this.ticks++;
            if (this.ticks % TimeBetweenDirectionSwitches == 0)
            {
                this.ChangeDirection();
            }
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            base.RespondToCollision(hitObject);
            if (hitObject is Character || hitObject is Obstacle)
            {
                this.ChangeDirection();
            }
        }

        private void ChangeDirection()
        {
            string newDirection = this.currentDirection.ToString();

            while (newDirection == this.currentDirection.ToString())
            {
                newDirection = Directions[rnd.Next(0, Directions.Length)];
            }

            this.currentDirection = (Direction)Enum.Parse(typeof(Direction), newDirection);

            this.Direction = this.currentDirection;
        }
    }
}
