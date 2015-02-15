namespace UltimateTankClash.Model.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;

    public abstract class Character : GameObject, IAttack, IDestroyable
    {
        protected Character(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch,
            int physicalAttack,
            int physicalDefense,
            int healthPoints)
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
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
