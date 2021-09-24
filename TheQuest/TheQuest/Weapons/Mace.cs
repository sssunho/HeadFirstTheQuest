using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Weapons
{
    class Mace : Weapon
    {

        public Mace(GameManager manager, Point location) : base(manager, location, "mace")
        { }

        public override string Name { get { return "Mace"; } }

        public override void Attack(Direction direction, Random random)
        {
            foreach (Enemy enemy in manager.Enemies)
            {
                if (Math.Abs(manager.player.Location.X - enemy.Location.X) <= 1 &&
                    Math.Abs(manager.player.Location.Y - enemy.Location.Y) <= 1)
                    enemy.Hit(6, random);
            }
        }

        public override void ShowRange(Graphics g, Direction d)
        {
            Point target = manager.player.Location.Add(new Point(1, 0));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(0, 1));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(-1, 0));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(-1, 0));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(0, -1));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(0, -1));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(1, 0));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = target.Add(new Point(1, 0));
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
        }
    }
}
