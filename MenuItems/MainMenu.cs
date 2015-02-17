using System;
using UltimateTankClash.Engine;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UltimateTankClash.MenuItems
{
    public partial class MainMenu : BackgroundForm
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            Thread theThread = new Thread(StartGame);
            this.Close();
            theThread.Start();
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
