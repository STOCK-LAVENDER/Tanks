namespace UltimateTankClash.Models.AmmunitionItems
{
    using Characters;
    using Characters.Tanks;
    using Engine;
    using GameObstacles;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Resources.Sounds;

    public abstract class Ammunition : GameObject, IAttack, IMoveable
    {
        private const int DefaultSpeed = 6;

        protected Ammunition(
            Texture2D objTexture, 
            Rectangle rectangle, 
            int damage, 
            Direction direction, 
            double damageModifier)
            : base(objTexture, rectangle)
        {
            this.DamageModifier = damageModifier;
            this.PhysicalAttack = (int)(damage * this.DamageModifier);
            this.Speed = DefaultSpeed;
            this.Direction = direction;
        }

        public int PhysicalAttack { get; protected set; }

        public Direction Direction { get; protected set; }

        public double Speed { get; private set; }

        protected double DamageModifier { get; set; }

        public void Shoot(Direction direction)
        {
        }

        public void Move()
        {
            switch (this.Direction)
            {
                case Direction.Up:
                    this.Rectangle = new Rectangle(
                        this.Rectangle.X,
                        (int)(this.Rectangle.Y - this.Speed),
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Down:
                    this.Rectangle = new Rectangle(
                        this.Rectangle.X,
                        (int)(this.Rectangle.Y + this.Speed),
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Left:
                    this.Rectangle = new Rectangle(
                        (int)(this.Rectangle.X - this.Speed),
                        this.Rectangle.Y,
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Right:
                    this.Rectangle = new Rectangle(
                        (int)(this.Rectangle.X + this.Speed),
                        this.Rectangle.Y,
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
            }
        }

        public override void Update()
        {
            this.Move();
            this.CheckOutOfBounds();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character || hitObject is Obstacle)
            {
                this.State = GameObjectState.Destroyed;
                SoundHandler.HandleDestroyObjectSoundEffect();
            }
        }

        private void CheckOutOfBounds()
        {
            if (this.Rectangle.X < -GameEngine.Offset ||
                this.Rectangle.X > GameEngine.WindowWidth + GameEngine.Offset ||
                this.Rectangle.Y < -GameEngine.Offset ||
                this.Rectangle.Y > GameEngine.WindowHeight + GameEngine.Offset)
            {
                this.State = GameObjectState.Destroyed;
            }
        }
    }
}
