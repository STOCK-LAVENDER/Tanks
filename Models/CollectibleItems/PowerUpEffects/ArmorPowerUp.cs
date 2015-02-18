namespace UltimateTankClash.Models.CollectibleItems.PowerUpEffects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ArmorPowerUp : PowerUp
    {
        private const int DefaultDefenseEffect = 100;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 0;

        public ArmorPowerUp(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.DamageEffect = DefaultDamageEffect;
            this.Defenseffect = DefaultDefenseEffect;
            this.HealthEffect = DefaultHealthEffect;
            this.SpeedEffect = DefaultSpeedEffect;
        }

        

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
