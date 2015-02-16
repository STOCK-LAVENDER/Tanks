namespace UltimateTankClash.Model.GameObstacles.SpeedUpObstacles
{
    using System.Security.Policy;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IceLake : Obstacle
    {
        private SpriteBatch iceLakeTexture;
        
        public IceLake(Texture2D objTexture,
                       double positionX,
                       double positionY,
                       double width,
                       double height,
                       SpriteBatch spriteBatch) 
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
        {
            this.iceLakeTexture = spriteBatch;
        }

        public override void Draw()
        {
            iceLakeTexture.Draw(this.objTexture, this.rect, Color.White);
        }
    }
}