namespace UltimateTankClash.Models.CollectibleItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpeedPowerUp : CollectibleItem, ITimeoutable
    {
        public const int DefaultTimeout = 500;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 3;

        public SpeedPowerUp(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultDamageEffect, DefaultDefenseEffect, DefaultHealthEffect, DefaultSpeedEffect)
        {
            this.Timeout = DefaultTimeout;
        }

        public int Timeout { get; set; }

        public override void Update()
        {
            base.Update();

            if (this.ItemState == CollectibleItemState.Active)
            {
                this.Timeout--;
            }

            if (this.Timeout == 0)
            {
                this.ItemState = CollectibleItemState.Expired;
            }
        }
    }
}
