namespace UltimateTankClash.Models.Characters.Tanks.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class StrongTank : EnemyTank
    {
        private const int DefaultPhysicalAttack = 60;
        private const int DefaultPhysicalDefense = 25;
        private const int DefaultHealthPoints = 500;
        private const int DefaultSpeed = 1;
        private const int TimeBetweenDirectionSwitches = 100;
        private const int TimeBetweenShots = 50;

        public StrongTank(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed, TimeBetweenDirectionSwitches, TimeBetweenShots)
        {
        }
    }
}
