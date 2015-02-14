namespace UltimateTankClash.Menus
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    class MousePointer
    {
        private Texture2D texture;
        private Vector2 position;

        public MousePointer(Texture2D texture)
        {
            this.texture = texture;
            this.position = this.GetMouseCoordinates();
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)this.position.X, (int)this.position.Y, 40, 40);
            }
        }

        private Vector2 GetMouseCoordinates()
        {
            MouseState mouse = Mouse.GetState();
            Vector2 coordinates = new Vector2(mouse.X, mouse.Y);

            return coordinates;
        }

        public void Update()
        {
            this.position = GetMouseCoordinates();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.texture,
                null,
                this.Rectangle,
                null,
                new Vector2(this.texture.Width / 2, this.texture.Width / 2),
                0,
                Vector2.Zero,
                Color.White,
                SpriteEffects.None,
                0f);
        }
    }
}
