namespace UltimateTankClash.Models.CollectibleItems.PowerUpEffects
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class PowerUp : CollectibleItem, ITimeoutable
    {
        private const int DefaultItemEffectDuration = 500;

        protected PowerUp(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.State = CollectibleItemState.Available;
            this.Timeout = DefaultItemEffectDuration;
        }

        public int Timeout { get; set; }

        public override void Update()
        {
            if (this.State != CollectibleItemState.Active)
            {
                return;
            }

            this.Timeout--;
            
            if (this.Timeout == 0)
            {
                
                this.State = CollectibleItemState.Expired;
            }
        }
    }
}
