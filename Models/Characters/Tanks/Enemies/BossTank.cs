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

        private List<ICollectible> inventory = new List<ICollectible>();

        public BossTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            base.RespondToCollision(hitObject);

            if (hitObject is CollectibleItem)
            {
                this.AddItemToInventory((ICollectible)hitObject);
            }
        }

        public void AddItemToInventory(ICollectible item)
        {
            this.inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public void ApplyItemEffects(ICollectible item)
        {
            this.HealthPoints += item.HealthEffect;
            this.PhysicalDefense += item.Defenseffect;
            this.PhysicalAttack += item.DamageEffect;
            this.Speed += item.SpeedEffect;
        }
    }
}
