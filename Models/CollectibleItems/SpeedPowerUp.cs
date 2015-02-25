namespace UltimateTankClash.Models.CollectibleItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpeedPowerUp : CollectibleItem, ITimeoutable
    {
        public const int DefaultTimeout = 10;

        public SpeedPowerUp(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
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
