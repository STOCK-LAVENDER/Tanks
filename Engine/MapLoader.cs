
namespace UltimateTankClash.Engine
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using UltimateTankClash.Model.CollectibleItems.PowerUpEffects;
    using UltimateTankClash.Model.GameObstacles.SpeedUpObstacles;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.GameObstacles.Walls;
    using UltimateTankClash.Model.GameObstacles.Bushes;
    using UltimateTankClash.Exceptions;

    static class MapLoader
    {
        public static List<GameObject> LoadMap(SpriteBatch spriteBatch, params Texture2D[] textures)
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

                        if (ch == 'W')
                        {
                            gameObjects.Add(
                                new BasicWall(
                                    textures[0],
                                    new Vector2(positionX, positionY),
                                    new Vector2(textures[0].Width, textures[0].Height)));
                        }
                        if (ch == 'B')
                        {
                            gameObjects.Add(
                                new BasicWall(
                                    textures[1],
                                    new Vector2(positionX, positionY),
                                    new Vector2(textures[1].Width, textures[1].Height)));
                        }
                        if (ch == 'I')
                        {
                            gameObjects.Add(
                                new BasicWall(
                                    textures[2],
                                    new Vector2(positionX, positionY),
                                    new Vector2(textures[2].Width, textures[2].Height)));
                        }

                        if (ch.Equals('\n'))
                        {
                            positionY += textures[0].Height;
                            positionX = 0 - textures[0].Width;
                        }
                        positionX += textures[0].Width;
                    }
                }
                return gameObjects;
            }
            catch (Exception)
            {
                throw new MapNotFoundException("Missing Map File!");
            }
        }
    }
}
