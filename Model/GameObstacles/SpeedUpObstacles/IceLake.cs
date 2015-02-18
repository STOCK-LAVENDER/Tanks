namespace UltimateTankClash.Model.GameObstacles.SpeedUpObstacles
{
    using System.Security.Policy;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class IceLake : Obstacle
    {


        public IceLake(Texture2D objTexture,
                       Vector2 position,
                       Vector2 size)
            : base(objTexture, position, size)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.objTexture, this.Rectangle, Color.White);
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}