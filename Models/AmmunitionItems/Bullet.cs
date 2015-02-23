namespace UltimateTankClash.Models.AmmunitionItems
{
    using Characters.Tanks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bullet : Ammunition
    {
        private const int DefaultDamageModifier = 1;

        public Bullet(Texture2D objTexture, Rectangle rectangle, int damage, Direction direction)
            : base(objTexture, rectangle, damage, direction, DefaultDamageModifier)
        {
        }
    }
}
