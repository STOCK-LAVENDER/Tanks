namespace UltimateTankClash.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    interface IMenuItem
    {
        Vector2 Position { get; }

        Vector2 Size { get; }

        Rectangle Rectangle { get; }

        Color Colour { get; }

        SpriteFont SpriteFont { get; }
    }
}
