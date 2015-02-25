namespace UltimateTankClash.Models.CollectibleItems
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ArmorConsumable : CollectibleItem
    {
        private const int DefaultDefenseEffect = 100;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 0;

        public ArmorConsumable(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultDamageEffect, DefaultDefenseEffect, DefaultHealthEffect, DefaultSpeedEffect)
        {
        }
    }
}
