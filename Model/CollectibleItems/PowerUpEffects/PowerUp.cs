namespace UltimateTankClash.Model.CollectibleItems.PowerUpEffects
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
        protected PowerUp(Texture2D objTexture, double positionX, double positionY, 
            double width, double height, SpriteBatch spriteBatch)
            :base(objTexture,positionX,positionY,width,height, spriteBatch)
        {
        }
    }
}
