namespace UltimateTankClash.Model.Characters.Vehicles
{
    using System;
    using Interfaces;

    public abstract class Vehicle : Character, IMoveable
    {
        public double Speed
        {
            get { throw new NotImplementedException(); }
        }
    }
}
