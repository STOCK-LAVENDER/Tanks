namespace UltimateTankClash.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Models;


    public static class CollisionHandler
    {
        public static GameObject GetCollisionInfo(GameObject obj)
        {
            var collidingObject = GameEngine.GameObjects
                .FirstOrDefault(gameObject => (!gameObject.Equals(obj) && gameObject.Rectangle.Intersects(obj.Rectangle)));

            return collidingObject;
        }
    }
}
