
namespace UltimateTankClash.Engine
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using Model.CollectibleItems.PowerUpEffects;
    using Model.GameObstacles.SpeedUpObstacles;
    using UltimateTankClash.Model;
    using UltimateTankClash.Model.Characters.Vehicles;
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
                                new BasicWall(textures[0], positionX, positionY,
                                    textures[0].Width, textures[0].Height
                                    , spriteBatch));
                        }
                        if (ch == 'B')
                        {
                            gameObjects.Add(
                                new BasicBush(textures[1], positionX, positionY,
                                    textures[1].Width, textures[1].Height
                                    , spriteBatch));
                        }
                        if (ch == 'I')
                        {
                            gameObjects.Add(
                                    new IceLake(textures[2], positionX, positionY,
                                        textures[2].Width, textures[2].Height,
                                        spriteBatch));
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
