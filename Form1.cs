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
        private Bitmap image;
        private Point pntCurrentPicbox;
        private Point pntMouseClick;

        private bool blsClick = false;

        int nPictureBoxX;
        int nPictureBoxY;

        public Form1()
        {
            InitializeComponent();
        }

        private void dirListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(winformtest.Properties.Resources.Black_1000x2000);

            nPictureBoxX = pictureBox1.Size.Width;
            nPictureBoxY = pictureBox1.Size.Height;
        }

        private void lbTile_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, pntCurrentPicbox);
            pictureBox1.Focus();
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            blsClick = true;

            pntMouseClick.X = e.X;
            pntMouseClick.Y = e.Y;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blsClick)
            {
                pntCurrentPicbox.X = pntCurrentPicbox.X + e.X - pntMouseClick.X;
                pntCurrentPicbox.Y = pntCurrentPicbox.Y + e.Y - pntMouseClick.Y;

                if (pntCurrentPicbox.X > 0)
                {
                    pntCurrentPicbox.X = 0;
                }
                if (pntCurrentPicbox.Y > 0)
                {
                    pntCurrentPicbox.Y = 0;
                }

                if (pntCurrentPicbox.X + image.Width < nPictureBoxX)
                {
                    pntCurrentPicbox.X = nPictureBoxX - image.Width;
                }
                if (pntCurrentPicbox.Y + image.Height < nPictureBoxY)
                {
                    pntCurrentPicbox.Y = nPictureBoxY - image.Height;
                }

                pntMouseClick = e.Location;

                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            blsClick = false;
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

        private void btLoad_Click(object sender, EventArgs e)
        {
            String file_path = null;
            openFileDialog1.InitialDirectory = "C:\\"; // 시작 위치를 C:\\로 설정
            if(openFileDialog1.ShowDialog() == DialogResult.OK) // 파일을 정하고 열기를 누르면
            {
                file_path = openFileDialog1.FileName; // 선택된 파일의 풀 경로를 불러와 저장
                //이제 여기서 불러온거를 오른쪽 픽쳐박스에 띄우기? Json 파일
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            String file_path = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Json File(*.json)|*.json";

            if(saveFileDialog.ShowDialog() == DialogResult.OK) // 저장 위치를 정하고 저장을 누르면
            {
                file_path = saveFileDialog.FileName; // 저장 경로
                pictureBox1.Image.Save(file_path);// 이제 픽쳐박스에서 만든거를 저장 예: pb.Image.Save(file_path) pb는 픽쳐박스
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
           
        }

        private void btGroundSelect_Click(object sender, EventArgs e)
        {
            if(cbBackGround.Text == "Ulu City")
            {
                image = new Bitmap(winformtest.Properties.Resources.Ulucity_Grid);
            }
            else if(cbBackGround.Text == "Blossom Castle")
            {
                image = new Bitmap(winformtest.Properties.Resources.Blossom_Grid);
            }
            else if(cbBackGround.Text == "Halloween")
            {
                image = new Bitmap(winformtest.Properties.Resources.Halloween_Grid);
            }
            pictureBox1.Image = image;
        }
    }
}
