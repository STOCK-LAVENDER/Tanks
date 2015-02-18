namespace UltimateTankClash.Exceptions
{
    using System;

    class ObjectOutOfBoundsException : ArgumentOutOfRangeException
    {
        public ObjectOutOfBoundsException(string paramName, object obj, string message)
            : base(paramName, obj, message)
        {
        }
    }
}
