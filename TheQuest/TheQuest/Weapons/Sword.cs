using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Weapons
{
    class Sword : Weapon
    {
        public Sword(GameManager manager, Point location, string imageName) : base(manager, location, imageName)
        { }

        public override string Name { get { return "Sword"; } }
        public override void Attack(Direction direction, Random random)
        {
        }
    }
}
