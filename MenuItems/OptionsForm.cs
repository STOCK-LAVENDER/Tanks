namespace UltimateTankClash.MenuItems
{
    using System;

    public partial class OptionsForm : BackgroundForm
    {
        public OptionsForm()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }
    }
}
