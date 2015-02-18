namespace UltimateTankClash.Models.Characters.Bunkers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Bunker : Character
    {
        protected Bunker(
            Texture2D objTexture,
            Vector2 position,
            Vector2 size,
            SpriteBatch spriteBatch,
            int damage,
            int defense,
            int health)
            : base(objTexture, position, size, damage, defense, health)
        {
        }
    }
}
