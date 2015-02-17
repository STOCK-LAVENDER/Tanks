namespace UltimateTankClash.Model.Characters
{
    using System.Collections.Generic;
    using CollectibleItems;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;

    public abstract class Character : GameObject, IAttack, IDestroyable, ICollect
    {
        private List<CollectibleItem> inventory = new List<CollectibleItem>(); 
        protected Character(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch,
            int physicalAttack,
            int physicalDefense,
            int healthPoints)
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
        {
            this.PhysicalAttack = physicalAttack;
            this.PhysicalDefense = physicalDefense;
            this.HealthPoints = healthPoints;
        }

        public List<CollectibleItem> Inventory
        {
            get
            {
                return this.inventory;
            }

            protected set
            {
                this.inventory = value;
            }

        }

        public int PhysicalAttack { get; protected set; }

        public int PhysicalDefense { get; protected set; }

        public int HealthPoints { get; protected set; }

        public abstract void AddItemToInventory(CollectibleItem item);

        public abstract void RemoveFromInventory(CollectibleItem item);

        public abstract void ApplyItemEffects();


        protected virtual void RemoveItemEffects(CollectibleItem item)
        {
            this.PhysicalAttack -= item.DamageEffect;
            this.HealthPoints -= item.HealthEffect;
            this.PhysicalDefense -= item.Defenseffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
    }
}
