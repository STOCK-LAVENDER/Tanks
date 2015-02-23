namespace UltimateTankClash.MenuItems
{
    using System;
    using System.Threading;
    using Engine;

    public partial class MainMenu : BackgroundForm
    {
        public MainMenu()
        {
            this.InitializeComponent();
        }

        public void StartGame()
        {
            GameEngine game = new GameEngine();
            game.Run();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            this.Hide();
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }

        private void StartGameOnClick(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
        }

        private void Instructions_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructionsForm instrForm = new InstructionsForm();
            instrForm.ShowDialog();
        }

        private void About_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
