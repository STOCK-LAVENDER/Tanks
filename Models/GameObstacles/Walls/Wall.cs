namespace UltimateTankClash.Models.GameObstacles.Walls
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Wall : Obstacle, IDestroyable
    {
        protected Wall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public int HealthPoints { get; protected set; }

        public int PhysicalDefense { get; protected set; }
    }
}
