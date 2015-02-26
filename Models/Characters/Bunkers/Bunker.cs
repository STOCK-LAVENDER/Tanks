namespace UltimateTankClash.Models.Characters.Bunkers
{
    using System.Linq;
    using Engine;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Tanks;

    public abstract class Bunker : Character
    {
        private int shotTimeout;

        protected Bunker(
            Texture2D objTexture,
            Rectangle rectangle,
            int damage,
            int defense,
            int health,
            int timeBetweenShots)
            : base(objTexture, rectangle, damage, defense, health)
        {
            this.ShotTimeout = timeBetweenShots;
        }

        protected int ShotTimeout { get; set; }

        public override void Update()
        {
            this.CheckPlayerInSight();
        }

        private void CheckPlayerInSight()
        {
            var player = (Player)GameEngine.GameObjects.FirstOrDefault(x => x is Player);

            if (player != null && player.IsVisible)
            {
                Rectangle leftView = new Rectangle(
                    -25,
                    this.Rectangle.Y,
                    this.Rectangle.X + 25,
                    player.Rectangle.Height);

                Rectangle left = new Rectangle(
                    player.Rectangle.X,
                    player.Rectangle.Y,
                    leftView.Width - player.Rectangle.X - 25,
                    this.Rectangle.Height - 25);

                if (player.Rectangle.Intersects(leftView) && !CollisionHandler.ObstaclesObstructingView(left))
                {
                    this.OpenFiringSequence(Direction.Left);
                }

                Rectangle rightView = new Rectangle(
                    this.Rectangle.X,
                    this.Rectangle.Y,
                    GameEngine.WindowWidth + 25 - this.Rectangle.X,
                    player.Rectangle.Height);

                Rectangle right = new Rectangle(
                    this.Rectangle.X,
                    this.Rectangle.Y,
                    player.Rectangle.Width - this.Rectangle.X - 25,
                    this.Rectangle.Height - 25);

                if (player.Rectangle.Intersects(rightView) && !CollisionHandler.ObstaclesObstructingView(right))
                {
                    this.OpenFiringSequence(Direction.Right);
                }

                Rectangle topView = new Rectangle(
                    this.Rectangle.X, 
                    -25,
                    this.Rectangle.Width,
                    this.Rectangle.Y);

                Rectangle top = new Rectangle(
                    player.Rectangle.X,
                    player.Rectangle.Y,
                    player.Rectangle.Width,
                    this.Rectangle.Y - player.Rectangle.Y);

                if (player.Rectangle.Intersects(topView) && !CollisionHandler.ObstaclesObstructingView(top))
                {
                    this.OpenFiringSequence(Direction.Up);
                }

                Rectangle bottomView = new Rectangle(
                    this.Rectangle.X,
                    this.Rectangle.Y,
                    this.Rectangle.Width,
                    GameEngine.WindowHeight - this.Rectangle.Y);

                Rectangle bottom = new Rectangle(
                    bottomView.X,
                    bottomView.Y + this.Rectangle.Height,
                    bottomView.Width,
                    player.Rectangle.Y - this.Rectangle.Y);

                if (player.Rectangle.Intersects(bottomView) && !CollisionHandler.ObstaclesObstructingView(bottom))
                {
                    this.OpenFiringSequence(Direction.Down);
                }
            }
        }

        private void OpenFiringSequence(Direction direction)
        {
            this.shotTimeout--;

            if (this.shotTimeout <= 0)
            {
                this.Direction = direction;
                this.Shoot(direction);
                this.shotTimeout = this.ShotTimeout;
            }
        }
    }
}
