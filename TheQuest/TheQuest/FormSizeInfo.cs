using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    static class FormSizeInfo
    {
        public const int WIDTH = 600;
        public const int DEPTH = 400;

        public const int TilePixelSize = 37;
        public const int GroundNumsTileX = 12;
        public const int GroundNumsTileY = 5;
        public const int GroundWidth = TilePixelSize * GroundNumsTileX;
        public const int GroundHeight = TilePixelSize * GroundNumsTileY;

        public static Point PixelToGround(Point p)
        {
            return new Point(p.X / GroundNumsTileX, p.Y / GroundNumsTileY);
        }

    }

}
