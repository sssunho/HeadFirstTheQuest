using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    public static class PointExtension4D
    {
        public static Point Add(this Point operand1, Point operand2)
        {
            return new Point(operand1.X + operand2.X, operand1.Y + operand2.Y);
        }
        public static Point Subtract(this Point operand1, Point operand2)
        {
            return new Point(operand1.X - operand2.X, operand1.Y - operand2.Y);
        }
        public static int Dot(this Point operand1, Point operand2)
        {
            return operand1.X * operand2.X + operand1.Y * operand2.Y;
        }

        public static Point GetClockwise(this Point p)
        {
            return new Point(-p.Y, p.X);
        }

        public static Point GetCounterClockwise(this Point p)
        {
            return new Point(p.Y, -p.X);
        }

        public static Point Negative(this Point p)
        {
            return new Point(-p.X, -p.Y);
        }


        public static Point ToVector(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(0, -1);
                case Direction.Down:
                    return new Point(0, 1);
                case Direction.Left:
                    return new Point(-1 , 0);
                case Direction.Right:
                    return new Point(1, 0);
                default:
                    return new Point(0, 0);
            }
        }
    }
}
