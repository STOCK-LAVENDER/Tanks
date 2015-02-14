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
        private float rotationAngle = 0f;
        private SpriteBatch spriteBatch;

        public BasicTank(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
            : base(objTexture, positionX, positionY, width, height, spriteBatch, PhysicalAttack, PhysicalDefense)
        {
            this.spriteBatch = spriteBatch;
            this.Speed = 3;
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up) && this.rect.Y - this.rect.Width / 2 > 0)
            {
                this.rotationAngle = 0f;
                this.rect.Y -= this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Up);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.rotationAngle = (float)Math.PI;
                this.rect.Y += this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Down);
            }
            else if (state.IsKeyDown(Keys.Left) && this.rect.X - this.objTexture.Width / 2 > 0)
            {
                this.rotationAngle = (float)Math.PI + (float)Math.PI / 2;
                this.rect.X -= this.Speed;
                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Left);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.rotationAngle = (float)Math.PI / 2;
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
