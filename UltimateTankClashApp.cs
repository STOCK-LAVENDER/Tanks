﻿namespace UltimateTankClash
{
    #region Using Statements

    using System;
    using Engine;

    #endregion

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class UltimateTankClashApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var game = new GameEngine())
            //    game.Run();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
#endif
}
