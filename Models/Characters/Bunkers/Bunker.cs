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
            if (player != null)
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
}
