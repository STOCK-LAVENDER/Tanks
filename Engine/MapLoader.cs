namespace UltimateTankClash.Engine
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
    using Models.CollectibleItems.TemporaryPowerUps;
    using Models.GameObstacles.Barricades;
    using Models.GameObstacles.Walls;
    using Models.Hideouts;

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

                    const int largeTextureSize = 70;
                    const int smallTextureSize = 50;

                    string line = sr.ReadToEnd();

                    for (int i = 0; i < line.Length; i++)
                    {
                        char currentSymbol = line[i];
                        Rectangle rect;

                        switch (currentSymbol)
                        {
                            case 'W':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new BasicWall(GameEngine.BasicWallTexture, rect));
                                break;
                            case 'B':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new Bush(GameEngine.BasicBushTexture, rect));
                                break;
                            case 'I':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new SpeedPowerUp(GameEngine.SpeedPowerUpTexture, rect));
                                break;
                            case 'P':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    GameEngine.PlayerTankTexture.Width,
                                    GameEngine.PlayerTankTexture.Height);

                                gameObjects.Add(new Player(GameEngine.PlayerTankTexture, rect));
                                break;
                            case 'T':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    smallTextureSize,
                                    smallTextureSize);

                                gameObjects.Add(new BasicTank(GameEngine.BasicTankTexture, rect));
                                break;
                            case 'F':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    smallTextureSize,
                                    smallTextureSize);

                                gameObjects.Add(new FastTank(GameEngine.FastTankTexture, rect));
                                break;
                            case 'S':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new StrongTank(GameEngine.BasicTankTexture, rect));
                                break;
                            case 'O':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    smallTextureSize,
                                    smallTextureSize);

                                gameObjects.Add(new BossTank(GameEngine.PlayerTankTexture, rect));
                                break;
                            case 'U':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new BasicBunker(GameEngine.BunkerTexture, rect));
                                break;
                            case 'R':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new FortifiedBunker(GameEngine.BunkerTexture, rect));
                                break;
                            case 'H':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new ShieldPowerUp(GameEngine.ShieldTexture, rect));
                                break;
                            case 'A':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new ArmorConsumable(GameEngine.ArmorTexture, rect));
                                break;
                            case 'E':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new HealthConsumable(GameEngine.HealthTexture, rect));
                                break;
                            case 'L':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    largeTextureSize,
                                    largeTextureSize);

                                gameObjects.Add(new SteelBarricade(GameEngine.SteelWallTexture, rect));
                                break;
                            case '\n':
                                positionY += largeTextureSize;
                                positionX = largeTextureSize;
                                break;
                        }

                        positionX += largeTextureSize;
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
