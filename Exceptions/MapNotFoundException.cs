using System;
using System.IO;

namespace UltimateTankClash.Exceptions
{
    public class MapNotFoundException : IOException
    {
        public MapNotFoundException(string message)
            : base(message)
        {
        }
    }
}
