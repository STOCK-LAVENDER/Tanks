namespace UltimateTankClash.Models.GameObstacles.SpeedUpObstacles
{
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

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}