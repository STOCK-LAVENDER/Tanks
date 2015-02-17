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
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch, 
            int physicalAttack, 
            int physicalDefense,
            int healthPoints,
            double speed)
            : base(objTexture, positionX, positionY, width, height, spriteBatch, physicalAttack, physicalDefense, healthPoints, speed)
        {
        }

        public override void ApplyItemEffects()
        {
            var activeItems = this.Inventory.Where(item => item.State == CollectibleItemState.Active);

            foreach (var item in activeItems)
            {
                this.HealthPoints += item.HealthEffect;
                this.PhysicalDefense += item.Defenseffect;
                this.PhysicalAttack += item.DamageEffect;
                this.Speed += item.SpeedEffect;
            }
        }
    }
}
