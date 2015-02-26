namespace UltimateTankClash.Models.CollectibleItems
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class HealthConsumable : CollectibleItem
    {
        private const int DefaultDamageEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultHealthEffect = 100;
        private const int DefaultSpeedEffect = 0;

        public HealthConsumable(Texture2D objTexture, Rectangle rectangle)
            : base(
                objTexture, 
                rectangle, 
                DefaultDamageEffect, 
                DefaultDefenseEffect, 
                DefaultHealthEffect, 
                DefaultSpeedEffect)
        {
        }
    }
}