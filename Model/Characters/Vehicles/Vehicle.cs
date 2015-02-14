namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using Microsoft.Xna.Framework.Graphics;


    using Interfaces;

    public abstract class Vehicle : Character, IMoveable
    {
        protected Vehicle(Texture2D objTexture, double positionX, double positionY,
            double width, double height, SpriteBatch spriteBatch, int physicalAttack, int physicalDefense)
            :base(objTexture,positionX,positionY,width,height, spriteBatch, physicalAttack, physicalDefense)
        {
        }

        public double Speed
        {
            get { throw new NotImplementedException(); }
        }
    }
}
