namespace UltimateTankClash.Models.GameObstacles.Barricades
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Barricade : Obstacle
    {
        protected Barricade(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
        {
        }
    }
}
