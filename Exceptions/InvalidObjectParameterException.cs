namespace UltimateTankClash.Exceptions
{
    using System;

    public class InvalidObjectParameterException : ArgumentOutOfRangeException
    {
        public InvalidObjectParameterException(string paramName, string message)
            : base(paramName, message)
        {
        }
    }
}
