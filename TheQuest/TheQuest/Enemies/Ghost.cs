using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Enemies
{
    class Ghost : Enemy
    {
        public Ghost(GameManager manager, Point location) : base(manager, location, "ghost", 8)
        { }

        public override void Move(Random random)
        {
            if (HitPoints <= 0)
                return;

            Point newLocation = location;

            if (NearPlayer())
            {
                manager.HitPlayer(3, TheQuest.random);
                return;
            }

            if (random.Next(3) == 0)
            {
                switch (FindPlayerDirection(manager.player.Location))
                {
                    case Direction.Up:
                        newLocation.Y -= 1;
                        break;

                    case Direction.Down:
                        newLocation.Y += 1;
                        break;

                    case Direction.Left:
                        newLocation.X -= 1;
                        break;

                    case Direction.Right:
                        newLocation.X += 1;
                        break;
                }
            }

            location = FormSizeInfo.IsInGround(newLocation) ? newLocation : location;

        }
    }
}
