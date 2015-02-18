namespace UltimateTankClash.Models.GameObstacles.Bushes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicBush : Bush
    {
        public BasicBush(Texture2D objTexture, Rectangle rectangle)
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
