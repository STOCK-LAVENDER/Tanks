namespace UltimateTankClash.Exceptions
{
    using System;

    class InvalidObjectParameterException : ArgumentOutOfRangeException
    {
        public InvalidObjectParameterException(string paramName, string message)
            : base(paramName, message)
        {
        }
    }
}
