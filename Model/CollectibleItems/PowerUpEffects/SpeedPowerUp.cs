namespace UltimateTankClash.Model.CollectibleItems.PowerUpEffects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public class SpeedPowerUp : PowerUp
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultSpeedEffect = 5;

        public SpeedPowerUp(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
        {
            this.HealthEffect = DefaultHealthEffect;
            this.DamageEffect = DefaultDamageEffect;
            this.Defenseffect = DefaultDefenseEffect;
            this.SpeedEffet = DefaultSpeedEffect;
        }
    }
}
