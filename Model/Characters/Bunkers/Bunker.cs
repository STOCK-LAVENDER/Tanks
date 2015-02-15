﻿namespace UltimateTankClash.Model.Characters.Bunkers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    public abstract class Bunker : Character
    {
        protected Bunker(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch,
            int damage,
            int defense,
            int health)
            : base(objTexture, positionX, positionY, width, height, spriteBatch, damage, defense, health)
        {
        }
    }
}
