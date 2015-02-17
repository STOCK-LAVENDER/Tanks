namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using System.Linq;
    using CollectibleItems;
    using CollectibleItems.PowerUpEffects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    using Interfaces;

    public abstract class Vehicle : Character, IMoveable
    {
        private double speed;
        public const int DefaultSpeed = 3;
        protected Vehicle(
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
            : base(objTexture, positionX, positionY, width, height, spriteBatch, physicalAttack, physicalDefense, healthPoints)
        {
            this.Speed = speed;
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }

            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Speed cannot be negative or equal to 0.");
                }
                this.speed  = value;
            }
        }

        

        public override void RemoveFromInventory(CollectibleItem item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        protected override void RemoveItemEffects(CollectibleItem item)
        {
            base.RemoveItemEffects(item);

            this.Speed = DefaultSpeed;
            if (item is SpeedPowerUp)
            {
                item.State = CollectibleItemState.Expired;
            }
        }
    }
}
