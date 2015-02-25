namespace UltimateTankClash.Models.CollectibleItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ShieldPowerUp : CollectibleItem, ITimeoutable
    {
        private const int DefaultDefenseEffect = 100;
        private const int DefaultHealthEffect = 0;
        private const int DefaultDamageEffect = 0;
        private const int DefaultSpeedEffect = 0;

        public const int DefaultTimeout = 10;

        public ShieldPowerUp(Texture2D objTexture, Rectangle rectangle)
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
