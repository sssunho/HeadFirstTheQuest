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
        Bitmap bitmap = new Bitmap(600, 400);
        Graphics bitmapGraphics;
        Direction input = Direction.NONE;
        public Direction Input { get => input; }
        Keys invenSelection = Keys.None;
        UpdateGame update;
        public static Random random = new Random();
        private bool keyDown = false;

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
            manager.NewLevel(random);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            manager.Input = input;
            manager.Update();
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
                    manager.Input = input;
                    keyDown = true;
                    break;

                case Keys.Down:
                    input = Direction.Down;
                    manager.Input = input;
                    keyDown = true;
                    break;

                case Keys.Left:
                    input = Direction.Left;
                    manager.Input = input;
                    keyDown = true;
                    break;

                case Keys.Right:
                    input = Direction.Right;
                    manager.Input = input;
                    keyDown = true;
                    break;

                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                    update = UseItem;
                    invenSelection = e.KeyCode;
                    break;

                case Keys.Space:
                case Keys.Escape:
                    invenSelection = e.KeyCode;
                    break;

                default:
                    input = Direction.NONE;
                    break;
            }
        }

        private void PlayerTurn()
        {
            if (keyDown)
            {
                manager.Move(input, random);
                keyDown = false;
            }
        }

        private void UseItem()
        {
            int i = 0;
            switch(invenSelection)
            {
                case Keys.D1:
                    i = 0;
                    break;
                case Keys.D2:
                    i = 1;
                    break;
                case Keys.D3:
                    i = 2;
                    break;
                case Keys.D4:
                    i = 3;
                    break;
                case Keys.D5:
                    i = 4;
                    break;
                case Keys.D6:
                    i = 5;
                    break;
                case Keys.D7:
                    i = 6;
                    break;
                case Keys.D8:
                    i = 7;
                    break;
                case Keys.Escape:
                    EndItemUse();
                    return;
                case Keys.Space:
                    manager.Attack(input, random);
                    EndItemUse();
                    return;
            }

            if (i >= manager.player.Weapons.Count)
            {
                EndItemUse();
                return;
            }

            manager.Equip(manager.player.Weapons[i]);


        }

        private void EndItemUse()
        {
            update = PlayerTurn;
            manager.player.Disarm();
            keyDown = false;
        }

        //private void 

        private void EnemyTurn()
        {

        }
    }
}
