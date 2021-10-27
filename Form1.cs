using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            public Rectangle rec;
            public String strTileNumber;
        }

        bool bFileAccess = false; // 현재 맵 정보가 등록되어있는지

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

            if (e.Button == MouseButtons.Left)
            {
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;

                //Graphics grp = pictureBox1.CreateGraphics();
                //grp.DrawImage(PreviewBox.Image, pntMouseClick);

                for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                {
                    for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                    {
                        if(myNewTileList[TileWidth, TileHeight].rec.Contains(pntMouseClick) == true)
                        {
                            if (PreviewBox.Image == null)
                            {
                                MessageBox.Show("타일을 선택하여 주세요", "타일 선택 오류", MessageBoxButtons.OK);
                                return;
                            }
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(PreviewBox.Image);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = TileListBox.Text;
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                    }
                }
            }

            
            if (e.Button == MouseButtons.Right)
            {
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;

                //Graphics grp = pictureBox1.CreateGraphics();
                //grp.DrawImage(PreviewBox.Image, pntMouseClick);
                for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                {
                    for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                    {
                        if (myNewTileList[TileWidth, TileHeight].rec.Contains(pntMouseClick) == true)
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "";
                            pictureBox1.Controls.Remove(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                    }
                }
            }
            
        }
        /*
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            if(e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                blsClick = true;
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;
            }
           
          

            if (e.Button == MouseButtons.Left)
            {
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;

                //Graphics grp = pictureBox1.CreateGraphics();
                //grp.DrawImage(PreviewBox.Image, pntMouseClick);

                for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                {
                    for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                    {
                        if (myNewTileList[TileWidth, TileHeight].rec.Contains(pntMouseClick) == true)
                        {
                            if (PreviewBox.Image == null)
                            {
                                MessageBox.Show("타일을 선택하여 주세요", "타일 선택 오류", MessageBoxButtons.OK);
                                return;
                            }
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(PreviewBox.Image);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = TileListBox.Text;
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;

                //Graphics grp = pictureBox1.CreateGraphics();
                //grp.DrawImage(PreviewBox.Image, pntMouseClick);
                for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                {
                    for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                    {
                        if (myNewTileList[TileWidth, TileHeight].rec.Contains(pntMouseClick) == true)
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "";
                        }
                    }
                }
            }
        }
        */
        private void myTileBoxList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pntMouseClick.X = e.X;
                pntMouseClick.Y = e.Y;

                //Graphics grp = pictureBox1.CreateGraphics();
                //grp.DrawImage(PreviewBox.Image, pntMouseClick);
                for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                {
                    for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                    {
                        if (myNewTileList[TileWidth, TileHeight].rec.Contains(pntMouseClick) == true)
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "";
                            pictureBox1.Controls.Remove(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                    }
                }
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void cbTile_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == false)
            {
                MessageBox.Show("배경 이미지를 먼저 선택하여 주세요", "오류", MessageBoxButtons.OK);
                return;
            }

            if (bFileAccess == false) // 맨 처음에 눌렀을 때
            {
                bFileAccess = true;
            }

            String file_path = null;
            openFileDialog1.InitialDirectory = "C:\\"; // 시작 위치를 C:\\로 설정
            if(openFileDialog1.ShowDialog() == DialogResult.OK) // 파일을 정하고 열기를 누르면
            {
                file_path = openFileDialog1.FileName; // 선택된 파일의 풀 경로를 불러와 저장
                //이제 여기서 불러온거를 오른쪽 픽쳐박스에 띄우기? Json 파일
                pictureBox1.Controls.Clear();
                string strReturnValue = System.IO.File.ReadAllText(file_path);
                JObject root = JObject.Parse(strReturnValue);

                int i = 0;
                JToken arr_data = root["Tiles"];
                JArray Tile_array = (JArray)arr_data;

                for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                {
                    for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                    {
                        // 기본값
                        myNewTileList[TileWidth, TileHeight].Tilebox = new PictureBox();
                        myNewTileList[TileWidth, TileHeight].Tilebox.Left = (TileWidth * 26);
                        myNewTileList[TileWidth, TileHeight].Tilebox.Top = (TileHeight * 26);
                        myNewTileList[TileWidth, TileHeight].Tilebox.Enabled = false;
                        myNewTileList[TileWidth, TileHeight].Tilebox.BackColor = Color.Transparent;
                        myNewTileList[TileWidth, TileHeight].Tilebox.Width = 25;
                        myNewTileList[TileWidth, TileHeight].Tilebox.Height = 25;
                        myNewTileList[TileWidth, TileHeight].Tilebox.SizeMode = PictureBoxSizeMode.StretchImage;
                        // 놓아질 타일(switch문 써서 해당 타일 설치)
                        myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                        if(Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1-1")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_1);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "UluCity_Tile1-1";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if(Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1-2")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_2);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "UluCity_Tile1-2";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1-3")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_3);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "UluCity_Tile1-3";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1-4")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_4);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "UluCity_Tile1-4";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1-5")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_5);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "UluCity_Tile1-5";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1-6")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_6);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "UluCity_Tile1-6";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1-1")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_1);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Halloween_Tile1-1";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1-2")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_2);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Halloween_Tile1-2";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1-3")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_3);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Halloween_Tile1-3";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1-4")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_4);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Halloween_Tile1-4";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1-5")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_5);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Halloween_Tile1-5";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1-6")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_6);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Halloween_Tile1-6";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1-1")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_1);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Blossom_Tile1-1";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1-2")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_2);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Blossom_Tile1-2";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1-3")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_3);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Blossom_Tile1-3";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1-4")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_4);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Blossom_Tile1-4";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1-5")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_5);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Blossom_Tile1-5";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else if (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1-6")
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_6);
                            myNewTileList[TileWidth, TileHeight].strTileNumber = "Blossom_Tile1-6";
                            pictureBox1.Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        }
                        else
                        {
                            myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                        }
                        //myNewTileList[TileWidth, TileHeight].rec = new Rectangle(TileWidth * 25, TileHeight * 25, 25, 25);
                        myNewTileList[TileWidth, TileHeight].nX = Convert.ToInt32(Tile_array[i]["X"].ToString());
                        myNewTileList[TileWidth, TileHeight].nY = Convert.ToInt32(Tile_array[i]["Y"].ToString());


                        //g.DrawRectangle(p, myNewTileList[TileWidth, TileHeight].rec);
                        //Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);
                        i++; // json내부 "Tile"에 있는 []
                    }
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(bFileAccess == false)
            {
                MessageBox.Show("파일을 새로 만들거나 불러오기를 사용하여 적용시켜 주세요", "파일 오류", MessageBoxButtons.OK);
                return;
            }
            // json 파일로 저장하기
            var json = new JObject();
            var jfriends = new JArray();
            for (int TileHeight = 0; TileHeight < 30; TileHeight++)
            {
                for (int TileWidth = 0; TileWidth < 20; TileWidth++)
                {
                    var myTile = new JObject();
                    myTile.Add("X", myNewTileList[TileWidth, TileHeight].nX);
                    myTile.Add("Y", myNewTileList[TileWidth, TileHeight].nY);
                    myTile.Add("TileNum", myNewTileList[TileWidth, TileHeight].strTileNumber);

                    jfriends.Add(myTile);
                }
            }
            json.Add("Tiles", jfriends);
            String strRoot = json.ToString();
            //json.Add("Tiles",)

            // 저장하기
            String file_path = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Json File(*.json)|*.json";

            if(saveFileDialog.ShowDialog() == DialogResult.OK) // 저장 위치를 정하고 저장을 누르면
            {
                file_path = saveFileDialog.FileName; // 저장 경로
                System.IO.File.WriteAllText(file_path, strRoot);             
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            //Graphics g = this.pictureBox1.CreateGraphics();
            //Pen p = new Pen(Color.White, 1);
            if(pictureBox1.Visible == false)
            {
                MessageBox.Show("배경 이미지를 먼저 선택하여 주세요", "오류", MessageBoxButtons.OK);
                return;
            }

            if(bFileAccess == false) // 맨 처음에 눌렀을 때
            {
                bFileAccess = true;
            }
            pictureBox1.Controls.Clear();

            for (int TileHeight = 0; TileHeight < 30; TileHeight++)
            {
                for(int TileWidth = 0; TileWidth < 20; TileWidth++)
                {
                    myNewTileList[TileWidth, TileHeight].Tilebox = new PictureBox();
                    myNewTileList[TileWidth, TileHeight].Tilebox.Left = (TileWidth * 26);
                    myNewTileList[TileWidth, TileHeight].Tilebox.Top = (TileHeight * 26);
                    myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Enabled = false;
                    myNewTileList[TileWidth, TileHeight].Tilebox.BackColor = Color.Transparent;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Width = 25;
                    myNewTileList[TileWidth, TileHeight].Tilebox.Height = 25;
                    myNewTileList[TileWidth, TileHeight].Tilebox.SizeMode = PictureBoxSizeMode.StretchImage;
                   // myNewTileList[TileWidth, TileHeight].Tilebox.MouseDown += new System.Windows.Forms.MouseEventHandler(myTileBoxList_MouseDown);
                    myNewTileList[TileWidth, TileHeight].rec = new Rectangle(TileWidth * 26, TileHeight * 26, 26, 26);
                    myNewTileList[TileWidth, TileHeight].nX = TileWidth;
                    myNewTileList[TileWidth, TileHeight].nY = TileHeight;
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
                image = new Bitmap(winformtest.Properties.Resources.UluCity_520x780);
                pictureBox1.Image = image;
            }
            else if(cbBackGround.Text == "Blossom Castle")
            {
                image = new Bitmap(winformtest.Properties.Resources.Blossom_520x780);
                pictureBox1.Image = image;
            }
            else if(cbBackGround.Text == "Halloween")
            {
                image = new Bitmap(winformtest.Properties.Resources.Halloween_520x780);
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

        private void lbWorld_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
