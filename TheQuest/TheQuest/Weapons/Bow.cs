using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest.Weapons
{
    class Bow : Weapon
    {

        public Bow(GameManager manager, Point location) : base(manager, location, "bow")
        { }

        public override string Name { get { return "Bow"; } }

        public override void Attack(Direction direction, Random random)
        {
            Point d = direction.ToVector();
            Point target = manager.player.Location.Add(d);
            bool hit = false;
            while (FormSizeInfo.IsInGround(target) && !hit)
            {
                foreach (Enemy enemy in manager.Enemies)
                    if (enemy.Location == target)
                    {
                        enemy.Hit(1, random);
                        hit = true;
                        break;
                    }
                target = target.Add(d);
            }
        }

        public override void ShowRange(Graphics g, Direction d)
        {
            Point direction = d.ToVector();
            Point target = manager.player.Location.Add(direction);
            bool hit = false;
            while(FormSizeInfo.IsInGround(target) && !hit)
            {
                manager.FillTile(g, target, Color.FromArgb(100, 255, 0, 0));
                foreach (Enemy enemy in manager.Enemies)
                    if (enemy.Location == target)
                    {
                        hit = true;
                        break;
                    }
                target = target.Add(direction);
            }
        }
    }
}
