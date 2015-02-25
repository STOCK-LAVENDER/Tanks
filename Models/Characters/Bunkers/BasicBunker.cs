namespace UltimateTankClash.Models.Characters.Bunkers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BasicBunker : Bunker
    {
        private const int DefaultPhysicalAttack = 120;
        private const int DefaultPhysicalDefense = 15;
        private const int DefaultHealthPoints = 500;
        private const int TimeBetweenShots = 50;

        public BasicBunker(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, TimeBetweenShots)
        {
        }
    }
}
