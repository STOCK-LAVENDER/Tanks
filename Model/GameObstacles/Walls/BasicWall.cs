namespace UltimateTankClash.Model.GameObstacles.Walls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public class BasicWall : Wall
    {
        private SpriteBatch spriteBatch;

        public BasicWall(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Draw()
        {
            spriteBatch.Draw(this.objTexture, this.rect, Color.White);
        }
    }
}
