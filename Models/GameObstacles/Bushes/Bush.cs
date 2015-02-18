namespace UltimateTankClash.Models.GameObstacles.Bushes
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Bush : Obstacle, IDestroyable
    {
        protected Bush(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public int HealthPoints { get; protected set; }

        public int PhysicalDefense { get; protected set; }
    }
}
