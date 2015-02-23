namespace UltimateTankClash.Models.GameObstacles.Walls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicWall : Wall
    {
        private const int DefaultHealthPoints = 250;

        public BasicWall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.HealthPoints = DefaultHealthPoints;
        }
    }
}
