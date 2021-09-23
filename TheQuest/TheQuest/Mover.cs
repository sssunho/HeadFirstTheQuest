using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TheQuest
{
    abstract class Mover
    {
        string imageName;

        private const int MoveInterval = FormSizeInfo.TilePixelSize;
        protected Point location;
        public Point Location { get { return location; } }
        protected GameManager manager;

        public Mover(GameManager manager, Point location, string imageName)
        {
            this.manager = manager;
            this.location = location;
            this.imageName = imageName;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            return MathF.Abs(location.X - locationToCheck.X) < distance &&
                   MathF.Abs(location.Y - locationToCheck.Y) < distance;
        }
        public bool Nearby(Point center, Point target, int radius)
        {
            return MathF.Abs(target.X - center.X) < radius &&
                   MathF.Abs(target.Y - center.Y) < radius;
        }

        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            switch(direction)
            {
                case Direction.Up:
                    newLocation.Y += newLocation.Y - 1 >= boundaries.Top ? -1 : 0;
                    break;

                case Direction.Down:
                    newLocation.Y += newLocation.Y + 1 <= boundaries.Bottom ? 1 : 0;
                    break;

                case Direction.Right:
                    newLocation.X += newLocation.X + 1 <= boundaries.Right ? 1 : 0;
                    break;

                case Direction.Left:
                    newLocation.X += newLocation.X - 1 >= boundaries.Left ? -1 : 0;
                    break;
            }

            return newLocation;
        }
        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target;
            switch (direction)
            {
                case Direction.Up:
                    newLocation.Y += newLocation.Y - 1 >= boundaries.Top ? -1 : 0;
                    break;

                case Direction.Down:
                    newLocation.Y += newLocation.Y + 1 <= boundaries.Bottom ? 1 : 0;
                    break;

                case Direction.Right:
                    newLocation.X += newLocation.X + 1 <= boundaries.Right ? 1 : 0;
                    break;

                case Direction.Left:
                    newLocation.X += newLocation.X - 1 >= boundaries.Left ? -1 : 0;
                    break;
            }

            return newLocation;
        }

        public void Draw(Graphics g)
        {
            Point drawPoint = FormSizeInfo.TileToMidPixel(location);
            manager.DrawImage(g, imageName, drawPoint, true);
        }
    }
}
