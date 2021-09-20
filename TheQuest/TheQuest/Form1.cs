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

        public TheQuest()
        {
            InitializeComponent();
            manager = new GameManager(new Rectangle(0, 0, FormSizeInfo.GroundNumsTileX, FormSizeInfo.GroundNumsTileY));
            manager.test(this.test);
        }
    }
}
