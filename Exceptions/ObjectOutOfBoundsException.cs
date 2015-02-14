namespace UltimateTankClash.Exceptions
{
    using System;
    using Model;

    class ObjectOutOfBoundsException : ArgumentOutOfRangeException
    {
        public ObjectOutOfBoundsException(string paramName, object obj, string message)
            : base(paramName, obj, message)
        {
        }
    }
}
