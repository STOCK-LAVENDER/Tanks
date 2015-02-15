namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public class BasicTank : Tank
    {
        private const int PhysicalAttack = 50;
        private const int PhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;
        private const int DefaultSpeed = 3;

        private float rotationAngle = 0f;
        private float angleUp = 0f;
        private float angleDown = (float)Math.PI;
        private float angleRight = (float)Math.PI / 2;
        private float angleLeft = (float)Math.PI + (float)Math.PI / 2;

        private SpriteBatch spriteBatch;

        public BasicTank(
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
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up) )
            {
                this.rotationAngle = angleUp;
                this.rect.Y -= this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Up);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.rotationAngle = angleDown;
                this.rect.Y += this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Down);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.rotationAngle = angleLeft;
                this.rect.X -= this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Left);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.rotationAngle = angleRight;
                this.rect.X += this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Right);
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
    }
}
