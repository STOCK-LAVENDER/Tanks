namespace UltimateTankClash.Model.AmmunitionItems
{
    using Engine;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public abstract class Ammunition : GameObject, IAttack
    {
        protected Ammunition(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
        {
        }

        protected double DamageModifier { get; set; }

        public int PhysicalAttack { get; protected set; }
    }
}
