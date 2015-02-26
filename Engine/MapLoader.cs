﻿namespace UltimateTankClash.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exceptions;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models;
    using Models.Characters.Bunkers;
    using Models.Characters.Tanks;
    using Models.Characters.Tanks.Enemies;
    using Models.CollectibleItems;
    using Models.GameObstacles.Barricades;
    using Models.GameObstacles.Walls;
    using Models.Hideouts.Bushes;

    public static class MapLoader
    {
        public static List<GameObject> LoadMap(SpriteBatch spriteBatch, GameLevel level)
        {
            string map;
            switch (level)
            {
                case GameLevel.Easy:
                    map = @"../../../Resources/Maps/Map_TrainingFields.txt";
                    break;
                case GameLevel.Medium:
                    map = @"../../../Resources/Maps/Map_OnEnemyTerritory.txt";
                    break;
                case GameLevel.Hard:
                    map = @"../../../Resources/Maps/Map_Glory.txt";
                    break;
                default:
                    throw new MapNotFoundException("The specified map is not implemented.");
            }

            List<GameObject> gameObjects = new List<GameObject>();

            try
            {
                using (StreamReader sr = new StreamReader(map))
                {
                    int positionY = 70;
                    int positionX = 70;

                    string line = sr.ReadToEnd();

                    for (int i = 0; i < line.Length; i++)
                    {
                        char currentSymbol = line[i];

                        switch (currentSymbol)
                        {
                            case 'W':
                                gameObjects.Add(new BasicWall(GameEngine.BasicWallTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'B':
                                gameObjects.Add(new Bush(GameEngine.BasicBushTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'I':
                                gameObjects.Add(new SpeedPowerUp(GameEngine.SpeedPowerUpTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'P':
                                gameObjects.Add(new Player(
                                    GameEngine.PlayerTankTexture,
                                    new Rectangle(positionX - 25, positionY - 25, GameEngine.PlayerTankTexture.Width, GameEngine.PlayerTankTexture.Height)));
                                break;
                            case 'T':
                                gameObjects.Add(new BasicTank(GameEngine.BasicTankTexture, new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                                break;
                            case 'F':
                                gameObjects.Add(new FastTank(GameEngine.FastTankTexture, new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                                break;
                            case 'S':
                                gameObjects.Add(new StrongTank(GameEngine.BasicTankTexture, new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                                break;
                            case 'O':
                                gameObjects.Add(new BossTank(GameEngine.PlayerTankTexture, new Rectangle(positionX - 25, positionY - 25, 50, 50)));
                                break;
                            case 'U':
                                gameObjects.Add(new BasicBunker(GameEngine.BunkerTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'R':
                                gameObjects.Add(new FortifiedBunker(GameEngine.BunkerTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'H':
                                gameObjects.Add(new ShieldPowerUp(GameEngine.ShieldTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'A':
                                gameObjects.Add(new ArmorConsumable(GameEngine.ArmorTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'E':
                                gameObjects.Add(new HealthConsumable(GameEngine.HealthTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case 'L':
                                gameObjects.Add(new SteelBarricade(GameEngine.SteelWallTexture, new Rectangle(positionX - 25, positionY - 25, 70, 70)));
                                break;
                            case '\n':
                                positionY += 70;
                                positionX = 70;
                                break;
                        }

                        positionX += 70;
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
