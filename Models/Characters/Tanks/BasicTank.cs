namespace UltimateTankClash.Models.Characters.Tanks
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicTank : Tank
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;
        private const int DefaultSpeed = 3;

        private int timeToNewDirection = 0;

        private Direction currentDirection = Direction.Up;
        private Array values = Enum.GetValues(typeof(Direction));

        public BasicTank(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
        }

        private Direction GetOpposite(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                default: return Direction.Up;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.objTexture,
                null,
                this.Rectangle,
                null,
                new Vector2(this.objTexture.Width / 2, this.objTexture.Width / 2),
                rotationAngle,
                Vector2.Zero,
                Color.White,
                SpriteEffects.None,
                0f);
        }

        public override void Move()
        {
            // change direction on certain time
            timeToNewDirection++;
            if (timeToNewDirection == 150)
            {
                Random rnd = new Random();

                Direction randomDirection = (Direction)values.GetValue(rnd.Next(values.Length));

                while (randomDirection == GetOpposite(currentDirection))
                {
                    randomDirection = (Direction)values.GetValue(rnd.Next(values.Length));
                }
                this.currentDirection = randomDirection;
                this.timeToNewDirection = 0;
            }
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            return;
        }
    }
}
