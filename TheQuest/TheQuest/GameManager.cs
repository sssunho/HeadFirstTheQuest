using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TheQuest
{
    class GameManager
    {
        public List<Enemy> Enemies;
        public Weapon WeaponInRoom;
        public Dictionary<string, Bitmap> ImageTable = new Dictionary<string, Bitmap>();

        public Player player;
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
            player = new Player(this, new Point(11, 2), "player");
            InitImages();
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
                    WeaponInRoom = new Weapons.Sword(this, GetRandomLocation(random), "sword");
                    break;
            }
        }

        private void InitImages()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"Images");
            foreach(System.IO.FileInfo file in di.GetFiles())
            {
                int i;
                string fileName = file.Name;
                for (i = fileName.Length - 1; i >= 0 && fileName[i] != '.'; i--) ;
                if(i >= 0)
                {
                    if (fileName.Substring(i + 1) == "png")
                    {
                        string name = fileName.Substring(0, i);
                        Bitmap image = new Bitmap(@"Images\" + fileName);
                        ImageTable.Add(name, image);
                    }
                }
            }
        }

        public void DrawImage(Graphics g, string name, Point p, bool alignment = false) // alignment가 false면 좌상단, true면 중심을 기준으로 그립니다.
        {
            if (alignment)
            {
                Bitmap bitmap = ImageTable[name];
                p.X -= bitmap.Width / 2;
                p.Y -= bitmap.Height / 2;
            }
            g.DrawImage(ImageTable[name], p);
        }

        public Bitmap LoadImage(string name)
        {
            return ImageTable[name];
        }

        public void DrawEnemies(Graphics g)
        {
            if (Enemies == null)
                return;

            foreach(Enemy enemy in Enemies)
            {
                enemy.Draw(g);
            }
        }

        public void DrawPlayer(Graphics g)
        {
            if (player == null)
                return;
            player.Draw(g);
        }

        public void DrawItems(Graphics g)
        {
            if (WeaponInRoom == null)
                return;
            WeaponInRoom.Draw(g);
        }

        public void DrawObjects(Graphics g)
        {
            DrawItems(g);
            DrawEnemies(g);
            DrawPlayer(g);
        }
    }
}
