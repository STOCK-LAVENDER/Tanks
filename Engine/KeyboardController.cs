namespace UltimateTankClash.Engine
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class KeyboardController : IController
    {
        public event EventHandler Pause;
        private KeyboardState keyboardState;
        public void ProcessInput()
        {
            this.keyboardState = Keyboard.GetState();
            if (this.keyboardState.IsKeyDown(Keys.P))
            {
                if (this.Pause != null)
                {
                    this.Pause(this, new EventArgs());
                }
            }
        }
    }
}
