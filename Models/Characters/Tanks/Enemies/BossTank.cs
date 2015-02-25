namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using System.Collections.Generic;
    using CollectibleItems;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BossTank : EnemyTank, ICollect
    {
        private const int DefaultPhysicalAttack = 25;
        private const int DefaultPhysicalDefense = 10;
        private const int DefaultHealthPoints = 250;
        private const int DefaultSpeed = 4;
        private const int TimeBetweenDirectionSwitches = 50;
        private const int TimeBetweenShots = 25;

        private List<CollectibleItem> inventory = new List<CollectibleItem>();

        public BossTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            base.RespondToCollision(hitObject);

            if (hitObject is CollectibleItem)
            {
                this.AddItemToInventory((CollectibleItem)hitObject);
            }
        }

        public void AddItemToInventory(CollectibleItem item)
        {
            this.inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public void ApplyItemEffects(CollectibleItem item)
        {
            this.HealthPoints += item.HealthEffect;
            this.PhysicalDefense += item.DefenseEffect;
            this.PhysicalAttack += item.DamageEffect;
            this.Speed += item.SpeedEffect;
        }
    }
}
