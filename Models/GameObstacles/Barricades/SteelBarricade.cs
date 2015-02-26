namespace UltimateTankClash.Models.GameObstacles.Barricades
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SteelBarricade : Barricade
    {
        public SteelBarricade(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public override void Update()
        {
        }

        public override void RespondToCollision(GameObject hitObject)
        {
        }
    }
}
