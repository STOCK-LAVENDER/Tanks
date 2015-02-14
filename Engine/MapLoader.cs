
namespace UltimateTankClash.Engine
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.Characters.Vehicles;
    using UltimateTankClash.Model.GameObstacles.Walls;
   
    static class MapLoader
    {
        public static List<GameObject> LoadMap(Texture2D texture, SpriteBatch spriteBatch)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            try
            {
                using (StreamReader sr = new StreamReader("Map.txt"))
                {
                    int positionY = 0;
                    int positionX = 0;
                    String line = sr.ReadToEnd();
                    for (int i = 0; i < line.Length; i++)
                    {

                        char ch = line[i];
                        if (ch.Equals('\n'))
                        {
                            positionY += texture.Height + 1;
                            positionX = 0;
                        }
                        if (ch == 'W')
                        {
                            gameObjects.Add(
                                new BasicWall(texture, positionX, positionY,
                                    texture.Width, texture.Height
                                    , spriteBatch));
                        }
                        positionX += texture.Width;
                    }
                }
                return gameObjects;
            }
            catch (Exception)
            {
                throw new ArgumentException("Missing Map File!");
            }
        }
    }
}
