
namespace UltimateTankClash.Engine
{
    using System.Collections.Generic;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.Characters.Vehicles;
    using UltimateTankClash.Model.GameObstacles;
    
    public static class CollissionHandler
    {
        private static List<GameObject> collidingObjects = new List<GameObject>();
        private static int screenW;
        private static int screenH;

        public static void Initialize(List<GameObject> gameObjects, int screenWidth, int screenHeight)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj is Obstacle)
                {
                    collidingObjects.Add(obj);
                }
            }
            screenW = screenWidth;
            screenH = screenHeight;
        }

        public static void  MovementCollisionDetector(Vehicle vehicle, Direction direction)
        {
            foreach (GameObject obstacle in collidingObjects)
            {
                if (vehicle.rect.X - (vehicle.objTexture.Width)/2 < obstacle.rect.X + obstacle.rect.Width &&
                    vehicle.rect.X + vehicle.rect.Width - (vehicle.objTexture.Width)/2 > obstacle.rect.X &&
                    vehicle.rect.Y - (vehicle.objTexture.Width)/2 < obstacle.rect.Y + obstacle.rect.Height &&
                    vehicle.rect.Height + vehicle.rect.Y - (vehicle.objTexture.Width)/2 > obstacle.rect.Y ||
                    vehicle.rect.X > screenW - vehicle.rect.Width/2 ||
                    vehicle.rect.Y > screenH - vehicle.rect.Width/2 ||
                    (vehicle.rect.Y - vehicle.rect.Width / 2) < 0  ||
                    (vehicle.rect.X - vehicle.objTexture.Width / 2) < 0)

                {
                    switch (direction)
                    {
                        case Direction.Up:
                            vehicle.rect.Y += vehicle.Speed;
                            break;
                        case Direction.Down:
                            vehicle.rect.Y -= vehicle.Speed;
                            break;
                        case Direction.Left:
                            vehicle.rect.X += vehicle.Speed;
                            break;
                        case Direction.Right:
                            vehicle.rect.X -= vehicle.Speed;
                            break;
                    }
                }
            }
        }
    }
}
