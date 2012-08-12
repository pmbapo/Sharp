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
    public partial class UserDialog : Form
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
        public UserDialog()
        {
            InitializeComponent();
        }

        public UserDialog(List<string> msgLog)
        {
            InitializeComponent();

  
            int LoopCount = 0;
            while (LoopCount < msgLog.Count)
            {
                listBox1.Items.Add(msgLog[LoopCount]);
                LoopCount++;
            }

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
          //  listBox1.SelectedIndex = -;

 
        }
        

        private void UserDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = textBox1.Text;
            this.Hide();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                result = textBox1.Text;
                this.Hide();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
