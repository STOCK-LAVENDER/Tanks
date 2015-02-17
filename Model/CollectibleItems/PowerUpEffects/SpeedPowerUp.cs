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
        private const double DefaultSpeedEffect = 0.010;

        private SpriteBatch spriteBatch;

        public SpeedPowerUp(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
        {
            this.State = CollectibleItemState.Active;
            this.HealthEffect = DefaultHealthEffect;
            this.DamageEffect = DefaultDamageEffect;
            this.Defenseffect = DefaultDefenseEffect;
            this.SpeedEffect = DefaultSpeedEffect;
            this.spriteBatch = spriteBatch;
        }

        public override void Draw()
        {
            this.spriteBatch.Draw(this.objTexture, this.rect, Color.White);
        }
    }
}
