namespace UltimateTankClash.Model.Characters.Bunkers
{
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Bunker : Character
    {
        protected Bunker(Texture2D objTexture, double positionX, double positionY,
            double width, double height, SpriteBatch spriteBatch, int physicalAttack, int physicalDefense)
            :base(objTexture,positionX,positionY,width,height, spriteBatch, physicalAttack, physicalDefense)
        {
        }
    }
}
