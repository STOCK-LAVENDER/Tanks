namespace UltimateTankClash.Models.Characters.Tanks
{
    using System.Collections.Generic;
    using Engine;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : Tank, ICollect
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 100;
        private const int DefaultHealthPoints = 200;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (this.info != null)
            {
                spriteBatch.DrawString(
                    GameEngine.Font, 
                    string.Format(
                        "{0}, UL: {1}, UR: {2}, LL: {3}, LR: {4}", 
                        this.info, 
                        this.Rectangle.X, 
                        this.Rectangle.Y, 
                        this.Rectangle.X + this.Rectangle.Width, 
                        this.Rectangle.Y + this.Rectangle.Height), 
                    new Vector2(500, 200), 
                    Color.Red);
            }
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

        public void AddItemToInventory(ICollectible item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects();
        }

        public void RemoveFromInventory(ICollectible item)
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

        public override void RespondToCollision(GameObject hitObject)
        {
            base.RespondToCollision(hitObject);
            this.info = hitObject == null ? "None" : hitObject.GetType().Name;
        }

        public override void Update()
        {
            if (CollisionHandler.GetCollisionInfo(this) != null)
            {
                this.info = CollisionHandler.GetCollisionInfo(this).GetType().Name;
            }

            base.Update();

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
            {
                this.Shoot(this.Direction);
                this.SoundEffectInstance.Play();
            }
            else if (state.IsKeyUp(Keys.Space) && this.SoundEffectInstance.State == SoundState.Playing)
            {
                this.SoundEffectInstance.Pause();
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
    }
}
