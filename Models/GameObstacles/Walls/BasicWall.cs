namespace UltimateTankClash.Models.GameObstacles.Walls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicWall : Wall
    {
        public BasicWall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
