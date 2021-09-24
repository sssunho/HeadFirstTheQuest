using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Weapons
{
    class BluePotion : Weapon, IPotion
    {
        bool used = false;
        public bool Used { get => used; }

        public BluePotion(GameManager manager, Point location) : base(manager, location, "potion_blue")
        { }

        public override string Name { get { return "BluePotion"; } }

        public override void Attack(Direction direction, Random random)
        {
            used = true;
            manager.player.IncreaseHealth(10, random);
        }

        public override void ShowRange(Graphics g, Direction d)
        {
            manager.FillTile(g, manager.player.Location, Color.FromArgb(100, 0, 0, 255));
        }
    }
}
