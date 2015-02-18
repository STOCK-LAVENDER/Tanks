namespace UltimateTankClash.Models.GameObstacles.Walls
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Wall : Obstacle, IDestroyable
    {
        protected Wall(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
        {
        }

        public int HealthPoints { get; protected set; }

        public int PhysicalDefense { get; protected set; }
    }
}
