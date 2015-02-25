namespace UltimateTankClash.Engine
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class KeyboardController : IController
    {
        public event EventHandler Pause;
        private KeyboardState keyboard;

        public void ProcessUserInput()
        {
            this.keyboard = Keyboard.GetState();
            if (this.keyboard.IsKeyDown(Keys.P))
            {
                if (this.Pause != null)
                {
                    this.Pause(this, new EventArgs());
                }
            }
        }
    }
}
