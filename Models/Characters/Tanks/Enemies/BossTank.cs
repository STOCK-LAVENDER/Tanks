namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class BossTank : EnemyTank
    {
        private const int DefaultPhysicalAttack = 200;
        private const int DefaultPhysicalDefense = 15;
        private const int DefaultHealthPoints = 1200;
        private const int DefaultSpeed = 3;
        private const int TimeBetweenDirectionSwitches = 50;
        private const int TimeBetweenShots = 20;

        public BossTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }
    }
}
