namespace UltimateTankClash.Models.CollectibleItems.Consumables
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Health : Consumable
    {
        private const int DefaultDamageEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultHealthEffect = 100;
        private const int DefaultSpeedEffect = 0;
       
        public Health(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            this.HealthEffect = DefaultHealthEffect;
            this.DamageEffect = DefaultDamageEffect;
            this.Defenseffect = DefaultDefenseEffect;
            this.SpeedEffect = DefaultSpeedEffect;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new NotImplementedException();
        }
    }
}