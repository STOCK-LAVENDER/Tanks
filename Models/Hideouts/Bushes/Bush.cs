namespace UltimateTankClash.Models.Hideouts.Bushes
{
    using Hideouts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bush : Hideout
    {
        public Bush(Texture2D objTexture, Rectangle rectangle)
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
