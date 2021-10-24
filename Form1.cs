using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace winformtest
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private Point pntCurrentPicbox;
        private Point pntMouseClick;
        String[] myTiles = { "UluCity_Tile1-1", "UluCity_Tile1-2", "UluCity_Tile1-3", "UluCity_Tile1-4", "UluCity_Tile1-5", "UluCity_Tile1-6", 
            "Blossom_Tile1-1", "Blossom_Tile1-2", "Blossom_Tile1-3", "Blossom_Tile1-4", "Blossom_Tile1-5", "Blossom_Tile1-6", 
            "Halloween_Tile1-1", "Halloween_Tile1-2", "Halloween_Tile1-3", "Halloween_Tile1-4", "Halloween_Tile1-5", "Halloween_Tile1-6" };
        private bool blsClick = false;

        int nPictureBoxX;
        int nPictureBoxY;

        public struct TIle
        {
            public PictureBox Tilebox;
            //public Rectangle rec;
            public int nX;
            public int nY;
            public String strBackground;
            public String strTile;
            public String strTileNumber;
        }

        public struct Vector2
        {
            int nX;
            int nY;
        }

        Vector2 TileXY;

        TIle[,] myNewTileList = new TIle[20, 30];


        public Form1()
        {
            InitializeComponent();
        }

        private void dirListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(winformtest.Properties.Resources.Black_1000x1500);

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
            /*
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, pntCurrentPicbox);
            pictureBox1.Focus();
            */
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            if(e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                blsClick = true;

                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;
            }
            */

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;

                //Graphics grp = pictureBox1.CreateGraphics();
                //grp.DrawImage(PreviewBox.Image, pntMouseClick);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            /*
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
            */
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //blsClick = false;
        }

        private void cbTile_SelectedIndexChanged(object sender, EventArgs e)
        {
         
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
            //Graphics g = this.pictureBox1.CreateGraphics();
            //Pen p = new Pen(Color.White, 1);
            pictureBox1.Controls.Clear();

            for (int TileHeight = 0; TileHeight < 30; TileHeight++)
            {
                for(int TileWidth = 0; TileWidth < 20; TileWidth++)
                {
                    myNewTileList[TileWidth, TileHeight].Tilebox = new PictureBox();
                    myNewTileList[TileWidth, TileHeight].Tilebox.Left = TileWidth * 25;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Top = TileHeight * 25;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                    myNewTileList[TileWidth, TileHeight].Tilebox.BackColor = Color.Transparent;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Width = 25;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Height = 25;
                    myNewTileList[TileWidth, TileHeight].Tilebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //myNewTileList[TileWidth, TileHeight].rec = new Rectangle(TileWidth * 25, TileHeight * 25, 25, 25);
                    myNewTileList[TileWidth, TileHeight].nX = TileWidth;
                    myNewTileList[TileWidth, TileHeight].nY = TileHeight;
                    myNewTileList[TileWidth, TileHeight].strBackground = "";
                    myNewTileList[TileWidth, TileHeight].strTile = "";
                    myNewTileList[TileWidth, TileHeight].strTileNumber = "";

                    //g.DrawRectangle(p, myNewTileList[TileWidth, TileHeight].rec);
                    //Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                }
            }
        }

        private void btGroundSelect_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
            }

            if (cbBackGround.Text == "Ulu City")
            {
                image = new Bitmap(winformtest.Properties.Resources.Ulucity_1000x1500);
                pictureBox1.Image = image;
            }
            else if(cbBackGround.Text == "Blossom Castle")
            {
                image = new Bitmap(winformtest.Properties.Resources.Blossom_1000x1500);
                pictureBox1.Image = image;
            }
            else if(cbBackGround.Text == "Halloween")
            {
                image = new Bitmap(winformtest.Properties.Resources.Halloween_1000x1500);
                pictureBox1.Image = image;
            }
        }

        private void btTileSelect_Click(object sender, EventArgs e)
        {
            if (cbTile.Text == "Normal")
            {
                TileListBox.Items.Clear();
                for (int index = 0; index < myTiles.Length; index++)
                {
                    TileListBox.Items.Add(myTiles[index]);
                }
            }
        }

        private void TileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTile.Text == "Normal")
            {
                switch (TileListBox.Text)
                {
                    case "UluCity_Tile1-1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_1);
                        return;
                    case "UluCity_Tile1-2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_2);
                        return;
                    case "UluCity_Tile1-3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_3);
                        return;
                    case "UluCity_Tile1-4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_4);
                        return;
                    case "UluCity_Tile1-5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_5);
                        return;
                    case "UluCity_Tile1-6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_6);
                        return;
                    case "Halloween_Tile1-1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_1);
                        return;
                    case "Halloween_Tile1-2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_2);
                        return;
                    case "Halloween_Tile1-3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_3);
                        return;
                    case "Halloween_Tile1-4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_4);
                        return;
                    case "Halloween_Tile1-5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_5);
                        return;
                    case "Halloween_Tile1-6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_6);
                        return;
                    case "Blossom_Tile1-1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_1);
                        return;
                    case "Blossom_Tile1-2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_2);
                        return;
                    case "Blossom_Tile1-3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_3);
                        return;
                    case "Blossom_Tile1-4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_4);
                        return;
                    case "Blossom_Tile1-5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_5);
                        return;
                    case "Blossom_Tile1-6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_6);
                        return;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btPlace_Click(object sender, EventArgs e)
        {
            if (tbWidth.Text == "" || tbHeight.Text == "")
            {
                MessageBox.Show("값을 입력하여 주세요", "입력 오류", MessageBoxButtons.OK);
                return;
            }

            else if (Convert.ToInt32(tbWidth.Text) > 19 || Convert.ToInt32(tbWidth.Text) < 0)
            {
                MessageBox.Show("0 ~ 19사이의 숫자를 입력하여 주세요", "가로 칸", MessageBoxButtons.OK);
                tbWidth.Text = "";
                return;
            }

            else if (Convert.ToInt32(tbHeight.Text) > 29 || Convert.ToInt32(tbHeight.Text) < 0)
            {
                MessageBox.Show("0 ~ 29사이의 숫자를 입력하여 주세요", "세로 칸", MessageBoxButtons.OK);
                tbHeight.Text = "";
                return;
            }

            int nWidth, nHeight;

            nWidth = Convert.ToInt32(tbWidth.Text);
            nHeight = Convert.ToInt32(tbHeight.Text);

            if (PreviewBox.Image == null)
            {
                MessageBox.Show("타일을 선택하여 주세요", "타일 선택 오류", MessageBoxButtons.OK);
                return;
            }
            myNewTileList[nWidth, nHeight].Tilebox.Image = new Bitmap(PreviewBox.Image);
            pictureBox1.Controls.Add(myNewTileList[nWidth, nHeight].Tilebox);
        }

        private void btTileDelete_Click(object sender, EventArgs e)
        {
            if (tbWidth.Text == "" || tbHeight.Text == "")
            {
                MessageBox.Show("값을 입력하여 주세요", "입력 오류", MessageBoxButtons.OK);
                return;
            }

            else if (Convert.ToInt32(tbWidth.Text) > 19 || Convert.ToInt32(tbWidth.Text) < 0)
            {
                MessageBox.Show("0 ~ 19사이의 숫자를 입력하여 주세요", "가로 칸", MessageBoxButtons.OK);
                tbWidth.Text = "";
                return;
            }

            else if (Convert.ToInt32(tbHeight.Text) > 29 || Convert.ToInt32(tbHeight.Text) < 0)
            {
                MessageBox.Show("0 ~ 29사이의 숫자를 입력하여 주세요", "세로 칸", MessageBoxButtons.OK);
                tbHeight.Text = "";
                return;
            }

            int nWidth, nHeight;

            nWidth = Convert.ToInt32(tbWidth.Text);
            nHeight = Convert.ToInt32(tbHeight.Text);

            myNewTileList[nWidth, nHeight].Tilebox.Image = null;
        }

        private void lbWorld_Click(object sender, EventArgs e)
        {

        }
    }
}
