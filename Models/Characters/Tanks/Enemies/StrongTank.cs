namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StrongTank : EnemyTank
    {
        private const int DefaultPhysicalAttack = 200;
        private const int DefaultPhysicalDefense = 15;
        private const int DefaultHealthPoints = 1200;
        private const int DefaultSpeed = 1;
        private const int TimeBetweenDirectionSwitches = 120;
        private const int TimeBetweenShots = 75;

        public StrongTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }
    }
}
