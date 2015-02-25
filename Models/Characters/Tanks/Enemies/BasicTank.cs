namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicTank : EnemyTank
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 10;
        private const int DefaultHealthPoints = 750;
        private const int DefaultSpeed = 2;
        private const int TimeBetweenDirectionSwitches = 100;
        private const int TimeBetweenShots = 50;

        public BasicTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }
    }
}
