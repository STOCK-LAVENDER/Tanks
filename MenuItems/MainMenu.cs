namespace UltimateTankClash.MenuItems
{
    using System;
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

        private void InitializeMenuBackgroundMusic()
        {
            this.simpleSound = new SoundPlayer(MenuBackgroundMusic.Volatile_Reaction);
            MediaPlayer.Volume = 1f;
            this.simpleSound.Play();
        }

        private void SinglePlayerButton_Click(object sender, EventArgs e)
        {
            SinglePlayerButton.Visible = false;
            instructions.Visible = false;
            about.Visible = false;
            exitButton.Visible = false;
            
            backButton.Visible = true;
            easyLevelButton.Visible = true;
            mediumLevelButton.Visible = true;
            hardLevelButton.Visible = true;
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

        private void easyLevelButton_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            GameEngine.Level = GameLevel.Easy;
        }

       
        private void mediumLevelButton_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            GameEngine.Level = GameLevel.Medium;
        }

        private void hardLevelButton_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            GameEngine.Level = GameLevel.Hard;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            SinglePlayerButton.Visible = true;
            instructions.Visible = true;
            about.Visible = true;
            exitButton.Visible = true;

            easyLevelButton.Visible = false;
            mediumLevelButton.Visible = false;
            hardLevelButton.Visible = false;
            backButton.Visible = false;
        }

       

       

    }
}
