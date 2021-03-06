using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Enemies
{
    class Bat : Enemy
    {
        public Bat(GameManager manager, Point location) : base(manager, location, "bat", 6)
        {

        }

        public override void Move(Random random)
        {
            if (HitPoints <= 0)
                return;

            Point newLocation = location;

            if (NearPlayer())
            {
                manager.HitPlayer(2, TheQuest.random);
                return;
            }

            if(random.Next(2) == 0)
            {
                switch(random.Next(4))
                {
                    case 0:
                        newLocation.X += 1;
                        break;
                    case 1:
                        newLocation.X -= 1;
                        break;
                    case 2:
                        newLocation.Y += 1;
                        break;
                    case 3:
                        newLocation.Y -= 1;
                        break;
                }
            }
            else
            {
                switch(FindPlayerDirection(manager.player.Location))
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
