﻿namespace UltimateTankClash.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exceptions;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models;
    using Models.CollectibleItems.PowerUpEffects;
    using Models.GameObstacles.Walls;
    using Models.Hideouts.Bushes;

    public static class MapLoader
    {
        public static List<GameObject> LoadMap(SpriteBatch spriteBatch, params Texture2D[] textures)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            try
            {
                using (StreamReader sr = new StreamReader("Map.txt"))
                {
                    int positionY = 50;
                    int positionX = 50;
                    string line = sr.ReadToEnd();
                    for (int i = 0; i < line.Length; i++)
                    {
                        char ch = line[i];

                        if (ch == 'W')
                        {
                            gameObjects.Add(new BasicWall(textures[0], new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                        }

                        if (ch == 'B')
                        {
                            gameObjects.Add(new Bush(textures[1], new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                        }

                        if (ch == 'I')
                        {
                            gameObjects.Add(new SpeedPowerUp(textures[2], new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                        }

                        if (ch.Equals('\n'))
                        {
                            positionY += 50;
                            positionX = 0 - 50;
                        }

                        positionX += 50;
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
