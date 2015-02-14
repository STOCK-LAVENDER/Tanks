namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Storage;
    using Microsoft.Xna.Framework.GamerServices;

    using Interfaces;

    public abstract class Vehicle : Character, IMoveable
    {
        protected Vehicle(
            Texture2D objTexture,
            double positionX,
            double positionY,
            double width,
            double height,
            SpriteBatch spriteBatch)
            : base(objTexture, positionX, positionY, width, height, spriteBatch)
        {
        }

        public double Speed
        {
            get { throw new NotImplementedException(); }
        }
    }
}
