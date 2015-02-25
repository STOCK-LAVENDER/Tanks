namespace UltimateTankClash.Models.CollectibleItems
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ArmorConsumable : CollectibleItem
    {
        private const int DefaultDefenseEffect = 100;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 0;

        public ArmorConsumable(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.DamageEffect = DefaultDamageEffect;
            this.DefenseEffect = DefaultDefenseEffect;
            this.HealthEffect = DefaultHealthEffect;
            this.SpeedEffect = DefaultSpeedEffect;
        }
    }
}
