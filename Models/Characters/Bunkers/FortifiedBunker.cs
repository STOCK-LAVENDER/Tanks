namespace UltimateTankClash.Models.Characters.Bunkers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FortifiedBunker : Bunker
    {
        private const int DefaultPhysicalAttack = 200;
        private const int DefaultPhysicalDefense = 25;
        private const int DefaultHealthPoints = 2000;
        private const int TimeBetweenShots = 20;

        public FortifiedBunker(Texture2D objTexture, Rectangle rectangle)
            : base(
                objTexture, 
                rectangle, 
                DefaultPhysicalAttack, 
                DefaultPhysicalDefense, 
                DefaultHealthPoints, 
                TimeBetweenShots)
        {
        }
    }
}
