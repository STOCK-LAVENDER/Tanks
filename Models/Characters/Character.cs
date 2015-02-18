namespace UltimateTankClash.Models.Characters
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Character : GameObject, IAttack, IDestroyable
    {
        protected Character(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size,
            int physicalAttack,
            int physicalDefense,
            int healthPoints)
            : base(objTexture, position, size)
        {
            this.PhysicalAttack = physicalAttack;
            this.PhysicalDefense = physicalDefense;
            this.HealthPoints = healthPoints;
        }

        public int PhysicalAttack { get; protected set; }

        public int PhysicalDefense { get; protected set; }

        public int HealthPoints { get; protected set; }
    }
}
