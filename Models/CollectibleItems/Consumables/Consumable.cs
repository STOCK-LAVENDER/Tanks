namespace UltimateTankClash.Models.CollectibleItems.Consumables
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Consumable : CollectibleItem
    {
        protected Consumable(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
        {
            this.State = CollectibleItemState.Available;
        }
    }
}
