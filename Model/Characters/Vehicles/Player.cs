namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        private float rotationAngle = 0f;
        private float angleUp = 0f;
        private float angleDown = (float)Math.PI;
        private float angleRight = (float)Math.PI / 2;
        private float angleLeft = (float)Math.PI + (float)Math.PI / 2;

        public Player(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
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

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up) && this.Rectangle.Y - this.Rectangle.Width / 2 > 0)
            {
                this.rotationAngle = angleUp;
                this.Rectangle = new Rectangle(
                    (int)this.Position.X,
                    (int)(this.Position.Y - this.Speed),
                    (int)this.Size.X,
                    (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Up);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.rotationAngle = angleDown;
                this.Rectangle = new Rectangle(
                    (int)this.Position.X,
                    (int)(this.Position.Y + this.Speed),
                    (int)this.Size.X,
                    (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Down);
            }
            else if (state.IsKeyDown(Keys.Left) && this.Rectangle.X - this.objTexture.Width / 2 > 0)
            {
                this.rotationAngle = angleLeft;
                this.Rectangle = new Rectangle(
                    (int)(this.Position.X - this.Speed),
                    (int)this.Position.Y,
                    (int)this.Size.X,
                    (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Left);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.rotationAngle = angleRight;
                this.Rectangle = new Rectangle(
                    (int)(this.Position.X + this.Speed),
                    (int)this.Position.Y,
                    (int)this.Size.X,
                    (int)this.Size.Y);

                Engine.CollissionHandler.MovementCollisionDetector(this, Direction.Right);
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
    }
}
