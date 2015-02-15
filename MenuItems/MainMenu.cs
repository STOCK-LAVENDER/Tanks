namespace UltimateTankClash.Menus
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class MainMenu : Menu
    {
        private bool down;
        private bool isClicked;
        private List<Button> buttons; 

        public MainMenu(Texture2D texture, GraphicsDevice graphics)
            : base(texture, graphics)
        {
            this.Texture = texture;
            this.Size = new Vector2(graphics.Viewport.Width / 4, graphics.Viewport.Height / 10);
        }

        public void Update()
        {
        }
    }
}
