namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using System;
    using System.Linq;
    using Engine;
    using GameObstacles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class EnemyTank : Tank
    {
        private static readonly string[] Directions = Enum.GetNames(typeof(Direction));
        private static Random rnd = new Random();

        private int ticks = 0;
        private int shotTimeout;
        private Direction currentDirection = Direction.Up;

        protected EnemyTank(Texture2D objTexture, Rectangle rectangle, int physicalAttack, int physicalDefense, int healthPoints, int speed, int timeBetweenDirectionChange, int timeBetweenShots)
            : base(objTexture, rectangle, physicalAttack, physicalDefense, healthPoints, speed)
        {
            this.TimeBetweenShot = timeBetweenShots;
            this.shotTimeout = this.TimeBetweenShot;
            this.TimeBetweenDirectionChange = timeBetweenDirectionChange;
            this.InitialSpeed = speed;
        }

        protected int TimeBetweenShot { get; set; }

        protected int TimeBetweenDirectionChange { get; set; }

        protected int InitialSpeed { get; set; }

        public override void Move()
        {
            this.ticks++;
            if (this.ticks % this.TimeBetweenDirectionChange == 0)
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

        public override void Update()
        {
            base.Update();
            this.CheckPlayerInSight();
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

        private void CheckPlayerInSight()
        {
            var player = (Player)GameEngine.GameObjects.FirstOrDefault(x => x is Player);

            if (player != null && player.IsVisible)
            {
                Rectangle leftView = new Rectangle(-25, this.Rectangle.Y, this.Rectangle.X, this.Rectangle.Height);
                if (player.Rectangle.Intersects(leftView))
                {
                    this.OpenFiringSequence(player, Direction.Left);
                }

                Rectangle rightView = new Rectangle(this.Rectangle.X, this.Rectangle.Y, GameEngine.WindowWidth - this.Rectangle.X, this.Rectangle.Height);
                if (player.Rectangle.Intersects(rightView))
                {
                    this.OpenFiringSequence(player, Direction.Right);
                }

                Rectangle topView = new Rectangle(this.Rectangle.X, -25, this.Rectangle.Width, this.Rectangle.Y);
                if (player.Rectangle.Intersects(topView))
                {
                    this.OpenFiringSequence(player, Direction.Up);
                }

                Rectangle bottomView = new Rectangle(this.Rectangle.X, this.Rectangle.Y, this.Rectangle.Width, GameEngine.WindowHeight - this.Rectangle.Height);
                if (player.Rectangle.Intersects(bottomView))
                {
                    this.OpenFiringSequence(player, Direction.Down);
                }
            }
        }

        private void OpenFiringSequence(GameObject player, Direction direction)
        {
            this.shotTimeout--;

            if (this.shotTimeout <= 0)
            {
                this.Speed = 0;
                this.Direction = direction;
                this.Shoot(direction);
                this.shotTimeout = this.TimeBetweenShot;
            }
            else
            {
                this.Speed = this.InitialSpeed;
            }
        }
    }
}
