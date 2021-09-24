using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Weapons
{
    class RedPotion : Weapon, IPotion
    {
        bool used = false;
        public bool Used { get => used; }

        public RedPotion(GameManager manager, Point location) : base(manager, location, "potion_red")
        { }

        public override string Name { get { return "RedPotion"; } }

        public override void Attack(Direction direction, Random random)
        {
            used = true;
            manager.player.IncreaseHealth(5, random);
        }

        public override void ShowRange(Graphics g, Direction d)
        {
            manager.FillTile(g, manager.player.Location, Color.FromArgb(100, 0, 0, 255));
        }
    }
}
