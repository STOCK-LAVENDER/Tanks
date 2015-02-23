namespace UltimateTankClash.Models.Characters.Tanks
{
    using System;
    using GameObstacles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicTank : Tank
    {
        private static Random rnd = new Random();
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;
        private const int DefaultSpeed = 3;
        private const int TimeBetweenDirectionSwitches = 50;
        private int ticks = 0;

        private Direction currentDirection = Direction.Up;
        private readonly string[] directions = Enum.GetNames(typeof(Direction));

        public BasicTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
        }

        private void ChangeDirection()
        {
            string newDirection = currentDirection.ToString();

            while (newDirection == currentDirection.ToString())
            {
                newDirection = directions[rnd.Next(0, directions.Length)];
            }

            currentDirection = (Direction)Enum.Parse(typeof(Direction), newDirection);

            this.Direction = currentDirection;
        }

        public override void Move()
        {
            ticks++;
            if (ticks % TimeBetweenDirectionSwitches == 0)
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
    }
}
