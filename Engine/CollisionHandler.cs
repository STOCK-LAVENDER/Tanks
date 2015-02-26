namespace UltimateTankClash.Engine
{
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Models;
    using Models.AmmunitionItems;
    using Models.Characters.Bunkers;
    using Models.Characters.Tanks.Enemies;
    using Models.GameObstacles;
    using Models.GameObstacles.Walls;

    public static class CollisionHandler
    {
        public static GameObject GetCollisionInfo(GameObject obj)
        {
            var collidingObject = GameEngine.GameObjects
                .FirstOrDefault(gameObject => (!gameObject.Equals(obj) && gameObject.Rectangle.Intersects(obj.Rectangle)));

            if (obj is Wall)
            {
                collidingObject = GameEngine.GameObjects.FirstOrDefault(x => (x is Ammunition) && x.Rectangle.Intersects(obj.Rectangle));
            }

            return collidingObject;
        }

        public static bool ObstaclesObstructingView(Rectangle rect)
        {
            var obstacles = GameEngine.GameObjects.Where(
                    x => (x is Obstacle || x is EnemyTank || x is Bunker) && x.Rectangle.Intersects(rect));

            return obstacles.Any();
        } 
    }
}
