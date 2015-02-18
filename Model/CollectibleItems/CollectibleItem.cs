namespace UltimateTankClash.Model.CollectibleItems
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    using Interfaces;

    public abstract class CollectibleItem : GameObject, ICollectible
    {
        protected CollectibleItem(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
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