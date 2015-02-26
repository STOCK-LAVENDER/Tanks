namespace UltimateTankClash.Models.CollectibleItems.TemporaryPowerUps
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ShieldPowerUp : TemporaryPowerUp
    {
        private const int DefaultTimeout = 10;
        private const int DefaultDefenseEffect = 100;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 0;

        public ShieldPowerUp(Texture2D objTexture, Rectangle rectangle)
            : base(
                objTexture, 
                rectangle, 
                DefaultDamageEffect, 
                DefaultDefenseEffect, 
                DefaultHealthEffect, 
                DefaultSpeedEffect, 
                DefaultTimeout)
        {
        }
    }
}
