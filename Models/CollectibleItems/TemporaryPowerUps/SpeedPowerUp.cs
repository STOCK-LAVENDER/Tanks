namespace UltimateTankClash.Models.CollectibleItems.TemporaryPowerUps
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpeedPowerUp : TemporaryPowerUp
    {
        public const int DefaultTimeout = 500;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 3;

        public SpeedPowerUp(Texture2D objTexture, Rectangle rectangle)
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
