namespace UltimateTankClash.Models.AmmunitionItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Ammunition : GameObject, IAttack
    {
        protected Ammunition(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        protected double DamageModifier { get; set; }

        public int PhysicalAttack { get; protected set; }
    }
}
