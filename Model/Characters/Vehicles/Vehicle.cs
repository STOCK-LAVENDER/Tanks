namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using System.Linq;
    using CollectibleItems;
    using CollectibleItems.PowerUpEffects;
    using Exceptions;
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
            Vector2 position,
            Vector2 size,
            int physicalAttack,
            int physicalDefense,
            int healthPoints,
            double speed)
            : base(objTexture, position, size, physicalAttack, physicalDefense, healthPoints)
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
                if (value <= 0)
                {
                    throw new InvalidObjectParameterException(
                        "speed",
                        "Speed should be greater than 0.");
                }

                this.speed = value;
            }
        }
    }
}
