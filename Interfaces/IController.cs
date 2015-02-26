namespace UltimateTankClash.Interfaces
{
    using System;

    public interface IController
    {
        event EventHandler Pause;

        event EventHandler GameMute;

        event EventHandler GameRestart;

        void ProcessUserInput();
    }
}
