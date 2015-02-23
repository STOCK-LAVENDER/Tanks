namespace UltimateTankClash.Exceptions
{
    using System.IO;

    public class MapNotFoundException : IOException
    {
        public MapNotFoundException(string message)
            : base(message)
        {
        }
    }
}
