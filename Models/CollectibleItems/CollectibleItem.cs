namespace UltimateTankClash.Models.CollectibleItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class CollectibleItem : GameObject, ICollectible
    {
        protected CollectibleItem(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.Exists = true;
        }

        public bool Exists { get; set; }

        public CollectibleItemState State { get; set; }

        public int DamageEffect { get; protected set; }

        public int Defenseffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public double SpeedEffect { get; protected set; }
    }
}