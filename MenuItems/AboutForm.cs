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

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
