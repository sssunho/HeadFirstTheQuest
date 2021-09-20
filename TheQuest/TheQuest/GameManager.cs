using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    class GameManager
    {
        public List<Enemy> Enemies;
        public Weapon WeaponInRoom;

        private Player player;
        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public List<string> PlayerWeapons { get { return player.Weapons; } }

        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }

        public GameManager (Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(this, new Point(11, 2));
        }

        public void Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }

        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }

        private Point GetRandomLocation (Random random)
        {
            return new Point(random.Next(FormSizeInfo.GroundNumsTileX, FormSizeInfo.GroundNumsTileY));
        }

        public void NewLevel(Random random)
        {
            level++;
            switch(level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Enemies.Bat(this, GetRandomLocation(random)));
                    WeaponInRoom = new Weapons.Sword(this, GetRandomLocation(random));
                    break;
            }
        }

    }
}
