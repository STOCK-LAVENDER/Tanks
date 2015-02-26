﻿namespace UltimateTankClash.Engine
{
    using System;
    using System.Threading;
    using System.Windows.Forms.VisualStyles;
    using Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class KeyboardController : IController
    {
        private KeyboardState keyboard;

        public event EventHandler Pause;

        public event EventHandler GameMute;

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
            else if (this.keyboard.IsKeyDown(Keys.M))
            {
                if (this.GameMute != null)
                {
                    this.GameMute(this, new EventArgs());
                }
            }
        }
    }
}
