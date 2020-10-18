using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kfc_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            /*var timer = new Timer();
            timer.Interval = 700;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            */
            InitializeComponent();
            home1.BringToFront();
        }


        /*private int caseSwitch = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            caseSwitch++;
            switch(caseSwitch)
            {
                case 1:
                    button2.ForeColor = Color.Yellow;
                    break;
                case 2:
                    button2.ForeColor = Color.Silver;
                    break;
            }
            if (caseSwitch == 2)
                caseSwitch = 0;
        }*/
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            home1.BringToFront();
        }

        private void home1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            order1.BringToFront();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            all_Record1.BringToFront();
        }
       
        private void order1_Load(object sender, EventArgs e)
        {
            

        }

        private void all_Record1_Load(object sender, EventArgs e)
        {

        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            menu1.BringToFront();
        }

        private void AboutUsBtn_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {
            employees1.BringToFront();
        }
    }
}
