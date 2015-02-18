namespace UltimateTankClash.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using UltimateTankClash.Model.CollectibleItems;
    using UltimateTankClash.Model.CollectibleItems.PowerUpEffects;
    using UltimateTankClash.Model.GameObstacles.SpeedUpObstacles;
    using UltimateTankClash.Model.GameObstacles.Walls;
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



        public static Direction MovementCollisionDetector(Vehicle vehicle, Direction direction)
        {
         
            foreach (GameObject obstacle in collidingObjects)
            {
                CheckForUncollidableObjects(vehicle, obstacle);

                if (IsCollisionEffectOn &&
                    vehicle.Rectangle.X - (vehicle.objTexture.Width) / 2 < obstacle.Rectangle.X + obstacle.Rectangle.Width &&
                    vehicle.Rectangle.X + vehicle.Rectangle.Width - (vehicle.objTexture.Width) / 2 > obstacle.Rectangle.X &&
                    vehicle.Rectangle.Y - (vehicle.objTexture.Width) / 2 < obstacle.Rectangle.Y + obstacle.Rectangle.Height &&
                    vehicle.Rectangle.Height + vehicle.Rectangle.Y - (vehicle.objTexture.Width) / 2 > obstacle.Rectangle.Y ||
                    vehicle.Rectangle.X > screenW - vehicle.Rectangle.Width / 2 ||
                    vehicle.Rectangle.Y > screenH - vehicle.Rectangle.Width / 2 ||
                    (vehicle.Rectangle.Y - vehicle.Rectangle.Width / 2) < 0 ||
                    (vehicle.Rectangle.X - vehicle.objTexture.Width / 2) < 0)
                {
                    Array values = Enum.GetValues(typeof(Direction));
                    Random random = new Random();
                    Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));

                    switch (direction)
                    {
                        case Direction.Up:
                            vehicle.Rectangle = new Rectangle(
                                (int)vehicle.Position.X, 
                                (int)(vehicle.Position.Y - vehicle.Speed), 
                                (int)vehicle.Size.X, 
                                (int)vehicle.Size.Y);
                            break;
                        case Direction.Down:
                            vehicle.Rectangle = new Rectangle(
                                (int)vehicle.Position.X,
                                (int)(vehicle.Position.Y + vehicle.Speed),
                                (int)vehicle.Size.X,
                                (int)vehicle.Size.Y);
                            break;
                        case Direction.Left:
                            vehicle.Rectangle = new Rectangle(
                                (int)(vehicle.Position.X - vehicle.Speed), 
                                (int)vehicle.Position.Y, 
                                (int)vehicle.Size.X, 
                                (int)vehicle.Size.Y);
                            break;
                        case Direction.Right:
                            vehicle.Rectangle = new Rectangle(
                                (int)(vehicle.Position.X + vehicle.Speed),
                                (int)vehicle.Position.Y,
                                (int)vehicle.Size.X,
                                (int)vehicle.Size.Y);
                            break;
                    }
                    return randomDirection;
                }
            }
            return direction;
        }

        private static void CheckForPowerEffects(Player vehicle, GameObject obstacle)
        {
            PowerUp effect = obstacle as SpeedPowerUp;
            if (vehicle.Rectangle.Intersects(obstacle.Rectangle) && obstacle is PowerUp)
            {
                if (effect != null)
                {
                    vehicle.AddItemToInventory(effect);
                    effect.State = CollectibleItemState.Active;
                    //This needs to be refactored later.
                }
            }
            if (effect != null)
            {
                if (effect.State == CollectibleItemState.Expired)
                {
                    vehicle.RemoveFromInventory(effect);
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
