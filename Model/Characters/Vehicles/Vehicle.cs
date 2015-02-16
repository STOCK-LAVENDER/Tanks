namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
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

        protected override void ApplyItemEffects(CollectibleItem item)
        {
            base.ApplyItemEffects(item);

            this.Speed += 0.22;
        }

        protected override void RemoveItemEffects(CollectibleItem item)
        {
            base.RemoveItemEffects(item);

            this.Speed -= item.SpeedEffect;
            if (item is SpeedPowerUp)
            {
                item.State = CollectibleItemState.Expired;
            }
        }
    }
}
