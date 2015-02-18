namespace UltimateTankClash.Models.Characters.Bunkers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Bunker : Character
    {
        protected Bunker(
            Texture2D objTexture,
            Rectangle rectangle,
            int damage,
            int defense,
            int health)
            : base(objTexture, rectangle, damage, defense, health)
        {
        }
    }
}
