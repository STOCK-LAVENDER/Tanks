﻿namespace UltimateTankClash.Model.CollectibleItems.PowerUpEffects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    using Interfaces;

    public abstract class PowerUp : CollectibleItem, ITimeoutable
    {
        private const int DefaultItemEffectDuration = 500;

        protected PowerUp(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
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
