namespace UltimateTankClash.Models.CollectibleItems.Consumables
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Consumable : CollectibleItem
    {
        protected Consumable(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.State = CollectibleItemState.Available;
        }
    }
}
