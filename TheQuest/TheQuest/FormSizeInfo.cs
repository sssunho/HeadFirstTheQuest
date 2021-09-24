using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    class FormSizeInfo
    {
        public const int WIDTH = 600;
        public const int DEPTH = 400;

        public const int TilePixelSize = 38;
        public const int GroundNumsTileX = 12;
        public const int GroundNumsTileY = 5;
        public const int GroundWidth = TilePixelSize * GroundNumsTileX;
        public const int GroundHeight = TilePixelSize * GroundNumsTileY;

        public const int InvenCellSize = 58;
        public const int NumsInvenCell = 8;

        private static Point _origin = new Point(72, 55);
        public static Point Origin { get => _origin; }

        public static Rectangle GroundRect = new Rectangle(0, 0, GroundNumsTileX - 1, GroundNumsTileY - 1);

        private static Point invenOrigin = new Point(72, 315);
        public static Point InvenOrigin { get => invenOrigin; }

        public static Point PixelToTile(Point p)
        {
            return new Point(p.X / GroundNumsTileX, p.Y / GroundNumsTileY);
        }

        public static Point TileToMidPixel(Point p)
        {
            return new Point(Origin.X + p.X * TilePixelSize + (TilePixelSize / 2), Origin.Y + p.Y * TilePixelSize + (TilePixelSize / 2));
        }

        public static Point TileToLeftUpPixel(Point p)
        {
            return new Point(Origin.X + p.X * TilePixelSize, Origin.Y + p.Y * TilePixelSize);
        }

        public static bool IsInGround(Point p)
        {
            return p.X < GroundNumsTileX && p.Y < GroundNumsTileY && p.X >= 0 && p.Y >= 0;
        }

        public static Point GetInvenMidPixel(int n)
        {
            return InvenOrigin.Add(new Point(n * InvenCellSize + InvenCellSize / 2, InvenCellSize / 2));
        }

        public static Point GetInvenLeftUpPixel(int n)
        {
            return InvenOrigin.Add(new Point(n * InvenCellSize, 0));
        }

        public static Rectangle GetInvenCell(int n)
        {
            return new Rectangle(GetInvenLeftUpPixel(n), new Size(InvenCellSize, InvenCellSize));
        }
    }

}