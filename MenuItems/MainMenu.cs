using System.Runtime.CompilerServices;

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
        private static bool isVisible = true;

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
            singlePlayerButton.Visible = false;
            instructions.Visible = false;
            this.about.Visible = false;
            exitButton.Visible = false;
            
            this.backButton.Visible = true;
            this.easyLevelButton.Visible = true;
            this.mediumLevelButton.Visible = true;
            this.hardLevelButton.Visible = true;
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

        private void EasyLevelButton_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            GameEngine.Level = GameLevel.Easy;
        }
       
        private void MediumLevelButton_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            GameEngine.Level = GameLevel.Medium;
        }

        private void HardLevelButton_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(this.StartGame);
            this.Close();
            theThread.Start();
            GameEngine.Level = GameLevel.Hard;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.singlePlayerButton.Visible = true;
            this.instructions.Visible = true;
            this.about.Visible = true;
            this.exitButton.Visible = true;

            this.easyLevelButton.Visible = false;
            this.mediumLevelButton.Visible = false;
            this.hardLevelButton.Visible = false;
            this.backButton.Visible = false;
        }

        private void GameName_Click(object sender, EventArgs e)
        {
        }
    }
}
