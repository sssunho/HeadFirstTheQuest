using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Weapons
{
    class Sword : Weapon
    {
        
        public Sword(GameManager manager, Point location) : base(manager, location, "sword")
        { }

        public override string Name { get { return "Sword"; } }
        public override void Attack(Direction direction, Random random)
        {
            Point dir = direction.ToVector();
            Point exception = dir.Negative();
            foreach(Enemy enemy in manager.Enemies)
            {
                if (enemy.Nearby(manager.player.Location, 1) &&
                    enemy.Location != exception)
                    enemy.Hit(3, random);
            }
        }

        public override void ShowRange(Graphics g, Direction d)
        {
            Point direction = d.ToVector();
            Point target = manager.player.Location.Add(direction);
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = manager.player.Location.Add(direction.GetClockwise());
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
            target = manager.player.Location.Add(direction.GetCounterClockwise());
            manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0)); ;
        }

    }
}