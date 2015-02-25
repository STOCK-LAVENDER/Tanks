namespace UltimateTankClash.MenuItems
{
    using System;
    using System.IO;
    using System.Media;
    using System.Threading;
    using Engine;
    using Microsoft.Xna.Framework.Media;
    using Resources.Sounds;

    public partial class MainMenu : BackgroundForm
    {
        private SoundPlayer simpleSound;
        public MainMenu()
        {
            this.InitializeMenuBackgroundMusic();
            this.InitializeComponent();
        }

        public void StartGame()
        {
            this.simpleSound.Stop();
            KeyboardController keyboardController = new KeyboardController();
            GameEngine game = new GameEngine(keyboardController);
            game.Run();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            this.Hide();
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }

        private void InitializeMenuBackgroundMusic()
        {
            this.simpleSound = (new SoundPlayer(MenuBackgroundMusic.Volatile_Reaction));
            MediaPlayer.Volume = 1f;
            this.simpleSound.Play();
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

        private void gameName_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
