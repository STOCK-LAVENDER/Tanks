namespace UltimateTankClash.MenuItems
{
    using System;

    public partial class AboutForm : BackgroundForm
    {
        public AboutForm()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
