namespace UltimateTankClash.Models.CollectibleItems.PowerUpEffects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpeedPowerUp : PowerUp
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const double DefaultSpeedEffect = 0.010;

        public SpeedPowerUp(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
        {
            this.HealthEffect = DefaultHealthEffect;
            this.DamageEffect = DefaultDamageEffect;
            this.Defenseffect = DefaultDefenseEffect;
            this.SpeedEffect = DefaultSpeedEffect;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.objTexture, this.Rectangle, Color.White);
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
