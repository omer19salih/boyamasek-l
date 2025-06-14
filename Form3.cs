using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace SekilBoyamaApp
{
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
      
        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 yeniForm = new Form1();
            yeniForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 yeniForm = new Form2();
            yeniForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 yeniForm = new Form5();
            yeniForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 yeniForm = new Form6();
            yeniForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 yeniForm = new Form7();
            yeniForm.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 yeniForm = new Form8();
            yeniForm.Show();
            this.Hide();
        }
    }
}
