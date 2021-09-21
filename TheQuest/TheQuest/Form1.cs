using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheQuest
{

    public partial class TheQuest : Form
    {
        GameManager manager;
        Timer gameLoopTimer = new Timer();
        Point testPoint = new Point(0, 0);
        PictureBox ttt = new PictureBox();

        public TheQuest()
        {
            InitializeComponent();
            DoubleBuffered = true;
            gameLoopTimer.Interval = 17;
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();
            manager = new GameManager(new Rectangle(0, 0, FormSizeInfo.GroundNumsTileX, FormSizeInfo.GroundNumsTileY));

            ttt.Image = manager.LoadImage("bat");
            ttt.Location = testPoint;
            ttt.Size = ttt.Image.Size;
            Ground.Controls.Add(ttt);
        }

        public void RegisterPictureBox(PictureBox pictureBox)
        {
        }

        private void GameLoop(object sender, EventArgs e)
        {
            Point oldPoint = ttt.Location;
            oldPoint.X += 1;
            ttt.Location = oldPoint;
        }
    }
}
