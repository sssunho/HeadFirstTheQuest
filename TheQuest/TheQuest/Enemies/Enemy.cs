using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    abstract class Enemy : Mover
    {
        private const int NearPlayerDistance = 1;

        private int maxHitPoints;
        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }
        public bool Dead
        {
            get { return hitPoints <= 0; }
        }

        public Enemy(GameManager manager, Point location, string imageName, int hitPoints) : base(manager, location, imageName)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints;
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
            Direction directionToMove = Direction.NONE;

            if (playerLocation.X > location.X)
                directionToMove = Direction.Right;
            else if (playerLocation.X < location.X)
                directionToMove = Direction.Left;
            else if (playerLocation.Y > location.Y)
                directionToMove = Direction.Down;
            else if (playerLocation.Y < location.Y)
                directionToMove = Direction.Up;

            return directionToMove;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Bitmap hpbar = manager.ImageTable["hp"];
            Point hpBarOrigin = FormSizeInfo.TileToLeftUpPixel(location).Add(new Point(0, -10));
            float hpRatio = hitPoints >= 0 ? hitPoints / (float)maxHitPoints : 0;
            Rectangle hpRect = new Rectangle(hpBarOrigin, new Size((int)(hpbar.Width * hpRatio), hpbar.Height));
            g.DrawImage(hpbar, hpRect);
        }

    }
}
