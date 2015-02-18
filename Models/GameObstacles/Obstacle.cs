namespace UltimateTankClash.Models.GameObstacles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Obstacle : GameObject
    {
        protected Obstacle(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size)
            : base(objTexture, position, size)
        {
        }
    }
}
