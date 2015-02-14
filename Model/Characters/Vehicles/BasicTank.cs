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

        public BasicTank(Texture2D objTexture, double positionX, double positionY, 
            double width, double height, SpriteBatch spriteBatch)
            :base(objTexture,positionX,positionY,width,height,spriteBatch, PhysicalAttack, PhysicalDefense)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up) && this.rect.Y - this.rect.Width / 2 > 0)
            {
                this.rect.Y -= 5;
                this.rotationAngle = 0f;
                CollisionDetector(Direction.Up);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.rect.Y += 5;
                this.rotationAngle = (float)Math.PI;
                CollisionDetector(Direction.Down);
            }
            else if (state.IsKeyDown(Keys.Left) && this.rect.X - this.objTexture.Width / 2 > 0)
            {
                this.rect.X -= 5;
                this.rotationAngle = 4.7123f;
                CollisionDetector(Direction.Left);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.rect.X += 5;
                this.rotationAngle = 1.5707f;
                CollisionDetector(Direction.Right);
            }

        }

        public void Draw()
        {
            spriteBatch.Draw(this.objTexture, null, this.rect, null,
                new Vector2(this.objTexture.Width / 2, this.objTexture.Width / 2),
                    rotationAngle, Vector2.Zero, Color.White, SpriteEffects.None, 0f);
            
        }


        public void CollisionDetector(Direction direction)
        {
            foreach (var gameObj in UltimateTankClash.Engine.GameEngine.GameObjects)
            {
                if (this.rect.X - (this.objTexture.Width)/2 < gameObj.rect.X + gameObj.rect.Width &&
                   this.rect.X + this.rect.Width - (this.objTexture.Width) / 2 > gameObj.rect.X &&
                   this.rect.Y - (this.objTexture.Width) / 2 < gameObj.rect.Y + gameObj.rect.Height &&
                   this.rect.Height + this.rect.Y - (this.objTexture.Width) / 2 > gameObj.rect.Y)
                {
                    switch (direction)
                    {
                        case Direction.Up: this.rect.Y += 5; break;
                        case Direction.Down: this.rect.Y -= 5; break;
                        case Direction.Left: this.rect.X += 5; break;
                        case Direction.Right: this.rect.X -= 5; break;
                    }
                }
            }
        }

    }
}
