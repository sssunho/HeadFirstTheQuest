using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    abstract class Enemy : Mover
    {
        private const int NearPlayerDistance = 1;
        private int hitPoints;
        public int HitPoints { get { return HitPoints; } }
        public bool Dead
        {
            get { return hitPoints <= 0; }
        }

        public Enemy(GameManager manager, Point location, string imageName, int hitPoints) : base(manager, location, imageName)
        {
            this.hitPoints = hitPoints;
        }

        public abstract void Move(Random random);

        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer()
        {
            return (Nearby(manager.PlayerLocation, NearPlayerDistance));
        }

        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove = Direction.Up;

            if (playerLocation.X > location.X + 1)
                directionToMove = Direction.Right;
            else if (playerLocation.X < location.X - 1)
                directionToMove = Direction.Left;
            else if (playerLocation.Y > location.Y + 1)
                directionToMove = Direction.Up;
            else if (playerLocation.Y < location.Y - 1)
                directionToMove = Direction.Down;

            return directionToMove;
        }
    }
}
