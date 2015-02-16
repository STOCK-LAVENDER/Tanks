namespace UltimateTankClash.Engine
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Model.CollectibleItems;
    using Model.CollectibleItems.PowerUpEffects;
    using Model.GameObstacles.SpeedUpObstacles;
    using Model.GameObstacles.Walls;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.Characters.Vehicles;
    using UltimateTankClash.Model.GameObstacles;
    using UltimateTankClash.Model.GameObstacles.Bushes;


    public static class CollissionHandler
    {
        private static List<GameObject> collidingObjects = new List<GameObject>();
        private static int screenW;
        private static int screenH;
        private static bool IsCollisionEffectOn;

        public static void Initialize(List<GameObject> gameObjects, int screenWidth, int screenHeight)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj is Obstacle && obj is Bush == false && obj is IceLake == false)
                {
                    IsCollisionEffectOn = true;
                    collidingObjects.Add(obj);
                }

                if (obj is SpeedPowerUp)
                {
                    collidingObjects.Add(obj);
                }
            }
            screenW = screenWidth;
            screenH = screenHeight;
        }

        public static void MovementCollisionDetector(Vehicle vehicle, Direction direction)
        {
            foreach (GameObject obstacle in collidingObjects)
            {
                CheckForUncollidableObjects(vehicle, obstacle);
                CheckForPowerEffects(vehicle, obstacle);
                
                if (IsCollisionEffectOn &&
                    vehicle.rect.X - (vehicle.objTexture.Width) / 2 < obstacle.rect.X + obstacle.rect.Width &&
                    vehicle.rect.X + vehicle.rect.Width - (vehicle.objTexture.Width) / 2 > obstacle.rect.X &&
                    vehicle.rect.Y - (vehicle.objTexture.Width) / 2 < obstacle.rect.Y + obstacle.rect.Height &&
                    vehicle.rect.Height + vehicle.rect.Y - (vehicle.objTexture.Width) / 2 > obstacle.rect.Y ||
                    vehicle.rect.X > screenW - vehicle.rect.Width / 2 ||
                    vehicle.rect.Y > screenH - vehicle.rect.Width / 2 ||
                    (vehicle.rect.Y - vehicle.rect.Width / 2) < 0 ||
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

        private static void CheckForPowerEffects(Vehicle vehicle, GameObject obstacle)
        {
            if (vehicle.rect.Intersects(obstacle.rect) && obstacle is PowerUp)
            {
                PowerUp effect = obstacle as SpeedPowerUp;
                if (effect != null)
                {
                    vehicle.AddToInventory(effect);    
                }
            }
        }

        private static void CheckForUncollidableObjects(Vehicle vehicle, GameObject gameObject)
        {
            if (gameObject is PowerUp)
            {
                IsCollisionEffectOn = false;
            }
            else
            {
                IsCollisionEffectOn = true;
            }
        }
    }
}
