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
            Rectangle leftView = new Rectangle(-25, this.Rectangle.Y, this.Rectangle.X, this.Rectangle.Height);
            var inSight = GameEngine.GameObjects.FirstOrDefault(x => x is Player && x.Rectangle.Intersects(leftView));
            OpenFiringSequence(inSight, Direction.Left);

            Rectangle rightView = new Rectangle(this.Rectangle.X, this.Rectangle.Y, GameEngine.WindowWidth - this.Rectangle.X, this.Rectangle.Height);
            inSight = GameEngine.GameObjects.FirstOrDefault(x => x is Player && x.Rectangle.Intersects(rightView));
            OpenFiringSequence(inSight, Direction.Right);

            Rectangle topView = new Rectangle(this.Rectangle.X, -25, this.Rectangle.Width, this.Rectangle.Y);
            inSight = GameEngine.GameObjects.FirstOrDefault(x => x is Player && x.Rectangle.Intersects(topView));
            OpenFiringSequence(inSight, Direction.Up);

            Rectangle bottomView = new Rectangle(this.Rectangle.X, this.Rectangle.Y, this.Rectangle.Width, GameEngine.WindowHeight - this.Rectangle.Height);
            inSight = GameEngine.GameObjects.FirstOrDefault(x => x is Player && x.Rectangle.Intersects(bottomView));
            OpenFiringSequence(inSight, Direction.Down);
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
                    this.shotTimeout = ShotTimeout;
                }
            }
        }
    }
}
