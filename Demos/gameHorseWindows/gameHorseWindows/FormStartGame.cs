using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gameSticksWindows
{
    public partial class FormStartGame : Form
    {
        public string result = "";
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 
        public FormStartGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = "1";
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = "2";
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = "3";
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = "4";
            this.Hide();
        }

        private void FormStartGame_Load(object sender, EventArgs e)
        {

        }
    }
}
