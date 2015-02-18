namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using System.Threading;
    using CollectibleItems;
    using Engine;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public class Enemy : Tank
    {
        private const int PhysicalAttack = 50;
        private const int PhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;

        private float rotationAngle = 0f;
        private float angleUp = 0f;
        private float angleDown = (float)Math.PI;
        private float angleRight = (float)Math.PI / 2;
        private float angleLeft = (float)Math.PI + (float)Math.PI / 2;
        private Direction currentDirection = Direction.Up;
        private Array values = Enum.GetValues(typeof(Direction));

        private int timeToNewDirection = 0;

        private SpriteBatch spriteBatch;

        public Enemy(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
            : base(objTexture, positionX, positionY, width, height, spriteBatch, PhysicalAttack, PhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update()
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
            else
            {
                switch (currentDirection)
                {
                    case (Direction.Up):
                        {
                            this.rotationAngle = angleUp;
                            this.rect.Y -= (int)this.Speed;
                            this.currentDirection = Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Up);
                            break;
                        }
                    case (Direction.Down):
                        {
                            this.rotationAngle = angleDown;
                            this.rect.Y += (int)this.Speed;
                            this.currentDirection = Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Down);
                            break;
                        }
                    case (Direction.Left):
                        {
                            this.rotationAngle = angleLeft;
                            this.rect.X -= (int)this.Speed;
                            this.currentDirection = Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Left);
                            break;
                        }
                    case (Direction.Right):
                        {
                            this.rotationAngle = angleRight;
                            this.rect.X += (int)this.Speed;
                            this.currentDirection = Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Right);
                            break;
                        }
                }
            }
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

        public override void Draw()
        {
            spriteBatch.Draw(
                this.objTexture,
                null,
                this.rect,
                null,
                new Vector2(this.objTexture.Width / 2, this.objTexture.Width / 2),
                rotationAngle,
                Vector2.Zero,
                Color.White,
                SpriteEffects.None,
                0f);
        }

        public override void AddItemToInventory(CollectibleItem item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects();
        }

        public override void RemoveFromInventory(CollectibleItem item)
        {
            if (this.Inventory.Contains(item))
            {
                this.Inventory.Remove(item);
            }
            this.RemoveItemEffects(item);
        }
    }
}
