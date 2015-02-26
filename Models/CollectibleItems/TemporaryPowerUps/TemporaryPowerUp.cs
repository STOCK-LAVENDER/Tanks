namespace UltimateTankClash.Models.CollectibleItems.TemporaryPowerUps
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class TemporaryPowerUp : CollectibleItem, ITimeoutable
    {
        protected TemporaryPowerUp(
            Texture2D objTexture, 
            Rectangle rectangle, 
            int damageEffect, 
            int defenseEffect, 
            int healthEffect, 
            int speedEffect, 
            int timeout)
            : base(
                objTexture, 
                rectangle, 
                damageEffect, 
                defenseEffect, 
                healthEffect, 
                speedEffect)
        {
            this.Timeout = timeout;
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
