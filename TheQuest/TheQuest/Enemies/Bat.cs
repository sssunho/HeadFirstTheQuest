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

        }
    }

}
