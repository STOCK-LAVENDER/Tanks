namespace UltimateTankClash.Models.Characters.Tanks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CollectibleItems;
    using Engine;
    using Hideouts;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Resources.Sounds;

    public class Player : Tank, ICollect
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 15;
        private const int DefaultHealthPoints = 800;
        private const double DefaultSpeed = 3;

        private List<CollectibleItem> inventory = new List<CollectibleItem>();

        // private SoundEffectInstance soundEffectInstance;
        public Player(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
            this.Direction = Direction.Down;
            //this.SoundEffectInstance = soundEffectInstance;
            this.BaseSpeed = DefaultSpeed;
            this.IsVisible = true;
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

        public SoundEffectInstance SoundEffectInstance { get; private set; }

        public double BaseSpeed { get; set; }

        public bool IsVisible { get; set; }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                this.Direction = Direction.Up;
                this.Speed = this.BaseSpeed;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.Direction = Direction.Down;
                this.Speed = this.BaseSpeed;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.Direction = Direction.Left;
                this.Speed = this.BaseSpeed;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.Direction = Direction.Right;
                this.Speed = this.BaseSpeed;
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
                //this.SoundEffectInstance.Play();
                SoundHandler.HandleGunShot();
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

            if (hitObject is CollectibleItem)
            {
                this.AddItemToInventory((CollectibleItem)hitObject);
            }

            if (hitObject is Hideout)
            {
                this.IsVisible = false;
            }
            else
            {
                this.IsVisible = true;
            }
        }

        public void AddItemToInventory(CollectibleItem item)
        {
            this.Inventory.Add(item);
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
            foreach (var item in this.Inventory.Where(x => x.ItemState == CollectibleItemState.Expired))
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(GameEngine.Font, string.Format("HP: {0}", this.HealthPoints), new Vector2(10, GameEngine.WindowHeight - 50), Color.Black);
        }
    }
}
