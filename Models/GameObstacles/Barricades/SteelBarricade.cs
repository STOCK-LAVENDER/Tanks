﻿namespace UltimateTankClash.Models.GameObstacles.Barricades
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SteelBarricade : Barricade
    {
        public SteelBarricade(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            return;
        }
    }
}