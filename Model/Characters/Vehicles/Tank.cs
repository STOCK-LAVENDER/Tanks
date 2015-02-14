namespace UltimateTankClash.Model.Characters.Vehicles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public abstract class Tank : Vehicle
    {
        protected Tank(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch, 
            int physicalAttack, 
            int physicalDefense)
            : base(objTexture, positionX, positionY, width, height, spriteBatch, physicalAttack, physicalDefense)
        {
        }
    }
}
