using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheQuest
{
    class Player : Mover
    {
        private Weapon equippedWeapon;
        private int maxHitPoints;
        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }


        private List<Weapon> inventory = new List<Weapon>();
        public List<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public List<Weapon> Inventory { get => inventory; }

        public Player(GameManager manager, Point location, string imageName) : base(manager, location, imageName)
        {
            hitPoints = 10;
            maxHitPoints = 10;
        }

        public void MoveToStartPoint()
        {
            location = new Point(11, 2);
        }

        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            hitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach(Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Disarm()
        {
            equippedWeapon = null;
        }

        public bool Move(Direction direction)
        {
            Point newLocation = base.Move(direction, manager.Boundaries);
            if (newLocation == location)
                return false;
            location = newLocation;
            return true;
        }

        public void PickUpWeapon(Weapon weapon)
        {
            inventory.Add(weapon);
        }

        public void Attack(Direction direction, Random random)
        {
            if (equippedWeapon == null)
                return;
            equippedWeapon.Attack(direction, random);
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            Bitmap hpbar = manager.ImageTable["hp"];
            Point hpBarOrigin = FormSizeInfo.TileToLeftUpPixel(location).Add(new Point(0, -10));
            float hpRatio = hitPoints >= 0 ? hitPoints / (float)maxHitPoints : 0;
            Rectangle hpRect = new Rectangle(hpBarOrigin, new Size((int)(hpbar.Width * hpRatio), hpbar.Height));
            g.DrawImage(hpbar, hpRect);

            for (int i = 0; i < inventory.Count; i++)
            {
                inventory[i].Draw(g, i);
            }

            if (equippedWeapon != null)
                equippedWeapon.ShowRange(g, manager.Input);
        }

    }
}
