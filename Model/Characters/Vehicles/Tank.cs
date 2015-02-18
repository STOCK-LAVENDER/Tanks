namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System.Linq;
    using CollectibleItems;
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
            Vector2 position,
            Vector2 size,
            int physicalAttack,
            int physicalDefense,
            int healthPoints,
            double speed)
            : base(objTexture, position, size, physicalAttack, physicalDefense, healthPoints, speed)
        {
        }
    }
}
