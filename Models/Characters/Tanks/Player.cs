﻿namespace UltimateTankClash.Models.Characters.Tanks
{
    using System.Collections.Generic;
    using System.Linq;
    using CollectibleItems;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : Tank, ICollect
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 15;
        private const int DefaultHealthPoints = 800;
        private const double DefaultSpeed = 3;

        private List<ICollectible> inventory = new List<ICollectible>();
        private string info;
        private SoundEffectInstance soundEffectInstance;

        public Player(Texture2D objTexture, Rectangle rectangle, SoundEffectInstance soundEffectInstance)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
            this.Direction = Direction.Down;
            this.SoundEffectInstance = soundEffectInstance;
        }

        public List<ICollectible> Inventory
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

        public SoundEffectInstance SoundEffectInstance { get; private set; }

        public virtual void ApplyItemEffects(ICollectible item)
        {
            this.PhysicalAttack += item.DamageEffect;
            this.HealthPoints += item.HealthEffect;
            this.PhysicalDefense += item.Defenseffect;
            this.Speed += item.SpeedEffect;
        }

        public void AddItemToInventory(ICollectible item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                this.Direction = Direction.Up;
                this.Speed = 3;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.Direction = Direction.Down;
                this.Speed = 3;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.Direction = Direction.Left;
                this.Speed = 3;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.Direction = Direction.Right;
                this.Speed = 3;
            }
            else
            {
                this.Speed = 0;
            }
        }

        public override void Update()
        {
            base.Update();

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space) && !this.HasShot)
            {
                this.Shoot(this.Direction);
                this.SoundEffectInstance.Play();
                this.HasShot = true;
            }
            else if (state.IsKeyUp(Keys.Space))
            {
                this.HasShot = false;
            }

            this.RemoveItemEffects();

            this.inventory.RemoveAll(x => x.ItemState == CollectibleItemState.Expired);
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            base.RespondToCollision(hitObject);

            if (hitObject is ICollectible)
            {
                this.AddItemToInventory((ICollectible)hitObject);
            }
        }

        protected virtual void RemoveItemEffects()
        {
            foreach (var item in this.Inventory.Where(x => x.ItemState == CollectibleItemState.Expired))
            {
                this.PhysicalAttack -= item.DamageEffect;
                this.HealthPoints -= item.HealthEffect;
                this.PhysicalDefense -= item.Defenseffect;
                this.Speed -= item.SpeedEffect;
            }

            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
    }
}
