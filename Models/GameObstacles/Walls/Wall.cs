﻿namespace UltimateTankClash.Models.GameObstacles.Walls
{
    using AmmunitionItems;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Wall : Obstacle, IDestroyable
    {
        protected Wall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public int HealthPoints { get; protected set; }

        public int PhysicalDefense { get; protected set; }

        public override void Update()
        {
            if (this.HealthPoints <= 0)
            {
                this.State = GameObjectState.Destroyed;
            }
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            var ammunition = hitObject as Ammunition;

            if (ammunition != null)
            {
                this.HealthPoints -= ammunition.PhysicalAttack;
            }
        }
    }
}
