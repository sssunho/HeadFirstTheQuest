using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    abstract class Weapon : Mover
    {
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } }

        public Weapon(GameManager manager, Point location, string imageName) : base(manager, location, imageName)
        {
            pickedUp = false;
        }

        public void PickUpWeapon() { pickedUp = true; }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);
        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = manager.PlayerLocation;
            for(int distance = 0; distance < radius; distance++)
            {
                foreach(Enemy enemy in manager.Enemies)
                {
                    if(Nearby(enemy.Location, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, manager.Boundaries);
            }
            return false;
        }
    }
}
