
namespace UltimateTankClash.Engine
{
    using System.Collections.Generic;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.Characters.Vehicles;

    public static class CollissionHandler
    {
        private static List<GameObject> collidingObjects = new List<GameObject>();
        
        public static void Initlialize(List<GameObject> gameObjects)
        {
            foreach (GameObject obj in gameObjects)
            {
                collidingObjects.Add(obj);
            }
        }

        public static void  MovementCollisionDetector(Vehicle vehicle, Direction direction)
        {
            foreach (GameObject obstacle in collidingObjects)
            {
                if (vehicle.rect.X - (vehicle.objTexture.Width) / 2 < obstacle.rect.X + obstacle.rect.Width &&
                   vehicle.rect.X + vehicle.rect.Width - (vehicle.objTexture.Width) / 2 > obstacle.rect.X &&
                   vehicle.rect.Y - (vehicle.objTexture.Width) / 2 < obstacle.rect.Y + obstacle.rect.Height &&
                   vehicle.rect.Height + vehicle.rect.Y - (vehicle.objTexture.Width) / 2 > obstacle.rect.Y)
                {
                    switch (direction)
                    {
                        case Direction.Up: vehicle.rect.Y += vehicle.Speed; ; break;
                        case Direction.Down: vehicle.rect.Y -= vehicle.Speed; break;
                        case Direction.Left: vehicle.rect.X += vehicle.Speed; break;
                        case Direction.Right: vehicle.rect.X -= vehicle.Speed; break;
                    }
                }
            }
        }
    }
}
