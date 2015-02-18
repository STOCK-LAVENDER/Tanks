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

    public class BasicTank : Tank
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;
        private const int DefaultSpeed = 3;

        private float rotationAngle = 0f;
        private float angleUp = 0f;
        private float angleDown = (float)Math.PI;
        private float angleRight = (float)Math.PI / 2;
        private float angleLeft = (float)Math.PI + (float)Math.PI / 2;

        public BasicTank(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                this.rotationAngle = angleUp;
                this.Position = new Vector2(this.Position.X, (int)(this.Position.Y - this.Speed));
                this.Rectangle = new Rectangle(
                                (int)this.Position.X,
                                (int)(this.Position.Y - this.Speed),
                                (int)this.Size.X,
                                (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Up);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.rotationAngle = angleDown;
                this.Position = new Vector2(this.Position.X, (int)(this.Position.Y + this.Speed));
                this.Rectangle = new Rectangle(
                                (int)this.Position.X,
                                (int)(this.Position.Y + this.Speed),
                                (int)this.Size.X,
                                (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Down);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.rotationAngle = angleLeft;
                this.Position = new Vector2((int)(this.Position.X - this.Speed), this.Position.Y);
                this.Rectangle = new Rectangle(
                                (int)(this.Position.X - this.Speed),
                                (int)this.Position.Y,
                                (int)this.Size.X,
                                (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Left);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.rotationAngle = angleRight;
                this.Position = new Vector2((int)(this.Position.X + this.Speed), this.Position.Y);
                this.Rectangle = new Rectangle(
                                (int)(this.Position.X + this.Speed),
                                (int)this.Position.Y,
                                (int)this.Size.X,
                                (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Right);
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
    }
}
