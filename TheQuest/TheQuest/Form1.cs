using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TheQuest
{
    delegate void UpdateGame();

    public partial class TheQuest : Form
    {
        GameManager manager;
        Timer gameLoopTimer = new Timer();
        Point testPoint = new Point(0, 0);
        Bitmap bitmap = new Bitmap(600, 400);
        Graphics bitmapGraphics;
        Direction input = Direction.NONE;
        UpdateGame update;

        public TheQuest()
        {
            InitializeComponent();

            update = PlayerTurn;

            bitmapGraphics = Graphics.FromImage(bitmap);
            bitmapGraphics.Clear(Color.White);
            this.Paint += Render;

            gameLoopTimer.Interval = 17;
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();

            this.KeyDown += GetKey;

            manager = new GameManager(FormSizeInfo.GroundRect);
        }

        public void RegisterPictureBox(PictureBox pictureBox)
        {
        }

        private void GameLoop(object sender, EventArgs e)
        {
            update();
            Invalidate();
        }
        private void Render(object sender, PaintEventArgs e)
        {
            manager.DrawImage(e.Graphics, "dungeon600x400", Point.Empty);
            manager.DrawObjects(e.Graphics);
        }

        private void GetKey(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    input = Direction.Up;
                    break;

                case Keys.Down:
                    input = Direction.Down;
                    break;

                case Keys.Left:
                    input = Direction.Left;
                    break;

                case Keys.Right:
                    input = Direction.Right;
                    break;

                default:
                    input = Direction.NONE;
                    break;
            }
        }

        private void PlayerTurn()
        {
            if(input != Direction.NONE)
            {
                manager.player.Move(input);
                input = Direction.NONE;
            }
        }

        private void EnemyTurn()
        {

        }
    }
}
