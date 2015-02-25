namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BossTank : EnemyTank
    {
        private const int DefaultPhysicalAttack = 25;
        private const int DefaultPhysicalDefense = 10;
        private const int DefaultHealthPoints = 250;
        private const int DefaultSpeed = 4;
        private const int TimeBetweenDirectionSwitches = 50;
        private const int TimeBetweenShots = 25;

        public BossTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }
    }
}
