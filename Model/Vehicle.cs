namespace UltimateTankClash.Model
{
    using System;
    using Engine;
    using Interfaces;

    public abstract class Vehicle : Character, IMoveable
    {
        public double Speed
        {
            get { throw new NotImplementedException(); }
        }
    }
}
