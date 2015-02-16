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
    public partial class MainMenu : Form
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
    }
}
