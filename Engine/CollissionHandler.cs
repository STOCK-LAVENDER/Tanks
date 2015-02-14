
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

        public static void  CollisionDetector(GameObject sender, Direction direction)
        {
            foreach (var gameObj in collidingObjects)
            {
                if (sender.rect.X - (sender.objTexture.Width) / 2 < gameObj.rect.X + gameObj.rect.Width &&
                   sender.rect.X + sender.rect.Width - (sender.objTexture.Width) / 2 > gameObj.rect.X &&
                   sender.rect.Y - (sender.objTexture.Width) / 2 < gameObj.rect.Y + gameObj.rect.Height &&
                   sender.rect.Height + sender.rect.Y - (sender.objTexture.Width) / 2 > gameObj.rect.Y)
                {
                    switch (direction)
                    {
                        case Direction.Up: sender.rect.Y += 5; break;
                        case Direction.Down: sender.rect.Y -= 5; break;
                        case Direction.Left: sender.rect.X += 5; break;
                        case Direction.Right: sender.rect.X -= 5; break;
                    }
                }
            }
        }
    }
}
