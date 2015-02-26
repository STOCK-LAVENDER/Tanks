namespace UltimateTankClash.Models.CollectibleItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class CollectibleItem : GameObject
    {
        protected CollectibleItem(
            Texture2D objTexture, 
            Rectangle rectangle, 
            int damageEffect, 
            int defenseEffect, 
            int healthEffect, 
            int speedEffect)
            : base(objTexture, rectangle)
        {
            this.DamageEffect = damageEffect;
            this.DefenseEffect = defenseEffect;
            this.HealthEffect = healthEffect;
            this.SpeedEffect = speedEffect;
        }

        public CollectibleItemState ItemState { get; set; }

        public int DamageEffect { get; set; }

        public int DefenseEffect { get; set; }

        public int HealthEffect { get; set; }

        public int SpeedEffect { get; set; }

        public override void Update()
        {
            if (this.ItemState == CollectibleItemState.Collected)
            {
                this.ItemState = CollectibleItemState.Active;
                this.Rectangle = new Rectangle(-999, -999, 1, 1);
            }
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is ICollect)
            {
                this.ItemState = CollectibleItemState.Collected;
            }
        }
    }
}
