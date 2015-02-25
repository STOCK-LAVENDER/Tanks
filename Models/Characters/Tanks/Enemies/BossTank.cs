namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using System.Collections.Generic;
    using System.Linq;
    using CollectibleItems;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BossTank : EnemyTank, ICollect
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
            this.BaseSpeed = DefaultSpeed;
        }

        public int BaseSpeed { get; set; }

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
            this.PhysicalAttack += item.DamageEffect;
            this.HealthPoints += item.HealthEffect;
            this.PhysicalDefense += item.DefenseEffect;
            this.Speed += item.SpeedEffect;
            this.BaseSpeed += item.SpeedEffect;
        }

        protected virtual void RemoveItemEffects()
        {
            foreach (var item in this.inventory.Where(x => x.ItemState == CollectibleItemState.Expired))
            {
                this.PhysicalAttack -= item.DamageEffect;
                this.HealthPoints -= item.HealthEffect;
                this.PhysicalDefense -= item.DefenseEffect;
                if (this.Speed < item.SpeedEffect)
                {
                    this.Speed = this.BaseSpeed;
                }
                else
                {
                    this.Speed -= item.SpeedEffect;
                }

                this.BaseSpeed -= item.SpeedEffect;
            }

            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
    }
}
