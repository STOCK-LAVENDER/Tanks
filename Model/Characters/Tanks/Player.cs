namespace UltimateTankClash.Model.Characters.Tanks
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using CollectibleItems;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    class Player : Tank, ICollect
    {
        private List<ICollectible> inventory = new List<ICollectible>();

        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;
        private const double DefaultSpeed = 3;

        public Player(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
            this.Direction = Direction.Down;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.objTexture,
                null,
                this.Rectangle,
                null,
                new Vector2(this.objTexture.Width / 2, this.objTexture.Width / 2),
                rotationAngle,
                Vector2.Zero,
                Color.White,
                SpriteEffects.None,
                0f);
        }

        public virtual void ApplyItemEffects()
        {
            foreach (var item in this.Inventory)
            {
                this.PhysicalAttack += item.DamageEffect;
                this.HealthPoints += item.HealthEffect;
                this.PhysicalDefense += item.Defenseffect;
            }
        }

        protected virtual void RemoveItemEffects()
        {
            foreach (var item in this.Inventory)
            {
                this.PhysicalAttack -= item.DamageEffect;
                this.HealthPoints -= item.HealthEffect;
                this.PhysicalDefense -= item.Defenseffect;
            }

            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
        public void AddItemToInventory(CollectibleItem item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects();
        }

        public void RemoveFromInventory(CollectibleItem item)
        {
            if (this.Inventory.Contains(item))
            {
                this.Inventory.Remove(item);
            }

            this.RemoveItemEffects();
        }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                this.Direction = Direction.Up;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.Direction = Direction.Down;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.Direction = Direction.Left;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.Direction = Direction.Right;
            }
            else
            {
                this.Direction = Direction.Still;
            }
        }
    }
}
