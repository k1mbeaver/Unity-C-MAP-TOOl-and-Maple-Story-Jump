using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dirListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbTile_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBackGround.Text == "Halloween" && cbTile.Text == "Normal")
            {
                String[] aa = { "Halloween Tile1-1", "Halloween Tile1-2", "Halloween Tile1-3", "Halloween Tile1-4", "Halloween Tile1-5" };
                for(int index = 0; index < aa.Length; index++)
                {
                    listView1.Items.Add(aa[index]);
                }
            }
        }
    }
}
