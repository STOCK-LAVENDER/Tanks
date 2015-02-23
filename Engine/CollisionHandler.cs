namespace UltimateTankClash.Engine
{
    using System;
    using System.Linq;
    using Models;
    using Models.AmmunitionItems;
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
    }
}
