namespace UltimateTankClash
{
    #region Using Statements

    using System;
    using MenuItems;

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
        public static void Main()
        {
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
#endif
}
