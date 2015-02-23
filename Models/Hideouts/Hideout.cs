namespace UltimateTankClash.Models.Hideouts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Hideout : GameObject
    {
        protected Hideout(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }
    }
}
