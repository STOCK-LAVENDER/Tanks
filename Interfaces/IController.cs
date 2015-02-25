namespace UltimateTankClash.Interfaces
{
    using System;

    public interface IController
    {
        event EventHandler Pause;

        void ProcessUserInput();
    }
}
