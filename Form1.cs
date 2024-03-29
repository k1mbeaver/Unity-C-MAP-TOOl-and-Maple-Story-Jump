﻿using System;
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
        String[] myTiles = { "UluCity_Tile1_1", "UluCity_Tile1_2", "UluCity_Tile1_3", "UluCity_Tile1_4", "UluCity_Tile1_5", "UluCity_Tile1_6", 
            "Blossom_Tile1_1", "Blossom_Tile1_2", "Blossom_Tile1_3", "Blossom_Tile1_4", "Blossom_Tile1_5", "Blossom_Tile1_6", 
            "Halloween_Tile1_1", "Halloween_Tile1_2", "Halloween_Tile1_3", "Halloween_Tile1_4", "Halloween_Tile1_5", "Halloween_Tile1_6",
            };
        String[] myInclineTiles = {"UluCity_Incline_Tile1_1", "UluCity_Incline_Tile1_2", "UluCity_Incline_Tile1_3", "UluCity_Incline_Tile1_4", "UluCity_Incline_Tile1_5",
            "UluCity_Incline_Tile2_1", "UluCity_Incline_Tile2_2", "UluCity_Incline_Tile2_3", "UluCity_Incline_Tile2_4", "UluCity_Incline_Tile2_5",
            "Blossom_Incline_Tile1_1", "Blossom_Incline_Tile1_2", "Blossom_Incline_Tile1_3", "Blossom_Incline_Tile1_4", "Blossom_Incline_Tile1_5",
            "Blossom_Incline_Tile2_1", "Blossom_Incline_Tile2_2", "Blossom_Incline_Tile2_3", "Blossom_Incline_Tile2_4", "Blossom_Incline_Tile2_5",
            "Halloween_Incline_Tile1_1", "Halloween_Incline_Tile1_2", "Halloween_Incline_Tile1_3", "Halloween_Incline_Tile1_4", "Halloween_Incline_Tile1_5",
            "Halloween_Incline_Tile2_1", "Halloween_Incline_Tile2_2", "Halloween_Incline_Tile2_3", "Halloween_Incline_Tile2_4", "Halloween_Incline_Tile2_5"};
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

                            if (cbBackGround.Text == "Ulu City" && !(TileListBox.Text == "UluCity_Tile1_1" || TileListBox.Text == "UluCity_Tile1_2" || TileListBox.Text == "UluCity_Tile1_3" || TileListBox.Text == "UluCity_Tile1_4" || TileListBox.Text == "UluCity_Tile1_5" || TileListBox.Text == "UluCity_Tile1_6" || TileListBox.Text == "UluCity_Incline_Tile1_1" || TileListBox.Text == "UluCity_Incline_Tile1_2" || TileListBox.Text == "UluCity_Incline_Tile1_3" || TileListBox.Text == "UluCity_Incline_Tile1_4" || TileListBox.Text == "UluCity_Incline_Tile1_5" || TileListBox.Text == "UluCity_Incline_Tile2_1" || TileListBox.Text == "UluCity_Incline_Tile2_2" || TileListBox.Text == "UluCity_Incline_Tile2_3" || TileListBox.Text == "UluCity_Incline_Tile2_4" || TileListBox.Text == "UluCity_Incline_Tile2_5"))
                            {
                                MessageBox.Show("배경에 맞는 타일을 선택하여 주세요", "타일 선택 오류", MessageBoxButtons.OK);
                                return;
                            }

                            else if (cbBackGround.Text == "Blossom Castle" && !(TileListBox.Text == "Blossom_Tile1_1" || TileListBox.Text == "Blossom_Tile1_2" || TileListBox.Text == "Blossom_Tile1_3" || TileListBox.Text == "Blossom_Tile1_4" || TileListBox.Text == "Blossom_Tile1_5" || TileListBox.Text == "Blossom_Tile1_6" || TileListBox.Text == "Blossom_Incline_Tile1_1" || TileListBox.Text == "Blossom_Incline_Tile1_2" || TileListBox.Text == "Blossom_Incline_Tile1_3" || TileListBox.Text == "Blossom_Incline_Tile1_4" || TileListBox.Text == "Blossom_Incline_Tile1_5" || TileListBox.Text == "Blossom_Incline_Tile2_1" || TileListBox.Text == "Blossom_Incline_Tile2_2" || TileListBox.Text == "Blossom_Incline_Tile2_3" || TileListBox.Text == "Blossom_Incline_Tile2_4" || TileListBox.Text == "Blossom_Incline_Tile2_5"))
                            {
                                MessageBox.Show("배경에 맞는 타일을 선택하여 주세요", "타일 선택 오류", MessageBoxButtons.OK);
                                return;
                            }

                            else if (cbBackGround.Text == "Halloween" && !(TileListBox.Text == "Halloween_Tile1_1" || TileListBox.Text == "Halloween_Tile1_2" || TileListBox.Text == "Halloween_Tile1_3" || TileListBox.Text == "Halloween_Tile1_4" || TileListBox.Text == "Halloween_Tile1_5" || TileListBox.Text == "Halloween_Tile1_6" || TileListBox.Text == "Halloween_Incline_Tile1_1" || TileListBox.Text == "Halloween_Incline_Tile1_2" || TileListBox.Text == "Halloween_Incline_Tile1_3" || TileListBox.Text == "Halloween_Incline_Tile1_4" || TileListBox.Text == "Halloween_Incline_Tile1_5" || TileListBox.Text == "Halloween_Incline_Tile2_1" || TileListBox.Text == "Halloween_Incline_Tile2_2" || TileListBox.Text == "Halloween_Incline_Tile2_3" || TileListBox.Text == "Halloween_Incline_Tile2_4" || TileListBox.Text == "Halloween_Incline_Tile2_5"))
                            {
                                MessageBox.Show("배경에 맞는 타일을 선택하여 주세요", "타일 선택 오류", MessageBoxButtons.OK);
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
                        myNewTileList[TileWidth, TileHeight].rec = new Rectangle(TileWidth * 26, TileHeight * 26, 26, 26); // 수정
                        // 놓아질 타일(switch문 써서 해당 타일 설치)
                        // 이부분에서 Json 파일에 있는 실 데이터의 X,Y값과 현재 TileWidth, TileHeight 값이 같고 타일의 이름이 일치할 때 배치하게하기
                        myNewTileList[TileWidth, TileHeight].Tilebox.Image = null;
                        myNewTileList[TileWidth, TileHeight].strTileNumber = "";
                        myNewTileList[TileWidth, TileHeight].nX = TileWidth;
                        myNewTileList[TileWidth, TileHeight].nY = TileHeight;                   
                        //myNewTileList[TileWidth, TileHeight].rec = new Rectangle(TileWidth * 25, TileHeight * 25, 25, 25);
                        //g.DrawRectangle(p, myNewTileList[TileWidth, TileHeight].rec);
                        //Controls.Add(myNewTileList[TileWidth, TileHeight].Tilebox);       
                    }
                }
                for (i = 0; i < arr_data.Count(); i++)
                {
                    if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != ""  && (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Tile1_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Tile1_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Tile1_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Tile1_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Tile1_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Tile1_6"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_6);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Tile1_6";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Tile1_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Tile1_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Tile1_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Tile1_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Tile1_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Tile1_6"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_6);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Tile1_6";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Tile1_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Tile1_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Tile1_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Tile1_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Tile1_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Tile1_6"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_6);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Tile1_6";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile1_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile1_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile1_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile1_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile1_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile1_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile1_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile1_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile1_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile1_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile2_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile2_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile2_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile2_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile2_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile2_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile2_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile2_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "UluCity_Incline_Tile2_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "UluCity_Incline_Tile2_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile1_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile1_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile1_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile1_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile1_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile1_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile1_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile1_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile1_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile1_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile2_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile2_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile2_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile2_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile2_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile2_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile2_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile2_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Blossom_Incline_Tile2_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Blossom_Incline_Tile2_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile1_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile1_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile1_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile1_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile1_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile1_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile1_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile1_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile1_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile1_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile2_1"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_1);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile2_1";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile2_2"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_2);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile2_2";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile2_3"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_3);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile2_3";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile2_4"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_4);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile2_4";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
                    }
                    else if (Tile_array[i]["X"].ToString() != "" && Tile_array[i]["Y"].ToString() != "" && (Tile_array[i]["TileNum"].ToString() == "Halloween_Incline_Tile2_5"))
                    {
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_5);
                        myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].strTileNumber = "Halloween_Incline_Tile2_5";
                        pictureBox1.Controls.Add(myNewTileList[Convert.ToInt32(Tile_array[i]["X"]), Convert.ToInt32(Tile_array[i]["Y"])].Tilebox);
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
                    // 이부분에서 이미지가 없는 칸이면 Json 파일에서는 없는 취급하고 있는 데이터만 저장
                    if(myNewTileList[TileWidth, TileHeight].strTileNumber != "")
                    {
                        var myTile = new JObject();
                        myTile.Add("X", myNewTileList[TileWidth, TileHeight].nX);
                        myTile.Add("Y", myNewTileList[TileWidth, TileHeight].nY);
                        myTile.Add("TileNum", myNewTileList[TileWidth, TileHeight].strTileNumber);

                        jfriends.Add(myTile);
                    }
                    
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
            if (pictureBox1.Visible == true)
            {
                if(MessageBox.Show("배치했던 타일이 초기화 됩니다", "배경화면 바꾸기", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pictureBox1.Controls.Clear();

                    for (int TileHeight = 0; TileHeight < 30; TileHeight++)
                    {
                        for (int TileWidth = 0; TileWidth < 20; TileWidth++)
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
                else
                {
                    return;
                }
            }

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

            else if (cbTile.Text == "Incline")
            {
                TileListBox.Items.Clear();
                for (int index = 0; index < myInclineTiles.Length; index++)
                {
                    TileListBox.Items.Add(myInclineTiles[index]);
                }
            }
        }

        private void TileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTile.Text == "Normal")
            {
                switch (TileListBox.Text)
                {
                    case "UluCity_Tile1_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_1);
                        return;
                    case "UluCity_Tile1_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_2);
                        return;
                    case "UluCity_Tile1_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_3);
                        return;
                    case "UluCity_Tile1_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_4);
                        return;
                    case "UluCity_Tile1_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_5);
                        return;
                    case "UluCity_Tile1_6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Tile1_6);
                        return;
                    case "Halloween_Tile1_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_1);
                        return;
                    case "Halloween_Tile1_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_2);
                        return;
                    case "Halloween_Tile1_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_3);
                        return;
                    case "Halloween_Tile1_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_4);
                        return;
                    case "Halloween_Tile1_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_5);
                        return;
                    case "Halloween_Tile1_6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Tile1_6);
                        return;
                    case "Blossom_Tile1_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_1);
                        return;
                    case "Blossom_Tile1_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_2);
                        return;
                    case "Blossom_Tile1_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_3);
                        return;
                    case "Blossom_Tile1_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_4);
                        return;
                    case "Blossom_Tile1_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_5);
                        return;
                    case "Blossom_Tile1_6":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_TIle1_6);
                        return;
                }
            }
            else if (cbTile.Text == "Incline")
            {
                switch (TileListBox.Text)
                {
                    case "UluCity_Incline_Tile1_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_1);
                        return;
                    case "UluCity_Incline_Tile1_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_2);
                        return;
                    case "UluCity_Incline_Tile1_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_3);
                        return;
                    case "UluCity_Incline_Tile1_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_4);
                        return;
                    case "UluCity_Incline_Tile1_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile1_5);
                        return;
                    case "UluCity_Incline_Tile2_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_1);
                        return;
                    case "UluCity_Incline_Tile2_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_2);
                        return;
                    case "UluCity_Incline_Tile2_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_3);
                        return;
                    case "UluCity_Incline_Tile2_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_4);
                        return;
                    case "UluCity_Incline_Tile2_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.UluCity_Incline_Tile2_5);
                        return;
                    case "Blossom_Incline_Tile1_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_1);
                        return;
                    case "Blossom_Incline_Tile1_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_2);
                        return;
                    case "Blossom_Incline_Tile1_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_3);
                        return;
                    case "Blossom_Incline_Tile1_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_4);
                        return;
                    case "Blossom_Incline_Tile1_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile1_5);
                        return;
                    case "Blossom_Incline_Tile2_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_1);
                        return;
                    case "Blossom_Incline_Tile2_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_2);
                        return;
                    case "Blossom_Incline_Tile2_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_3);
                        return;
                    case "Blossom_Incline_Tile2_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_4);
                        return;
                    case "Blossom_Incline_Tile2_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Blossom_Incline_Tile2_5);
                        return;
                    case "Halloween_Incline_Tile1_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_1);
                        return;
                    case "Halloween_Incline_Tile1_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_2);
                        return;
                    case "Halloween_Incline_Tile1_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_3);
                        return;
                    case "Halloween_Incline_Tile1_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_4);
                        return;
                    case "Halloween_Incline_Tile1_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile1_5);
                        return;
                    case "Halloween_Incline_Tile2_1":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_1);
                        return;
                    case "Halloween_Incline_Tile2_2":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_2);
                        return;
                    case "Halloween_Incline_Tile2_3":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_3);
                        return;
                    case "Halloween_Incline_Tile2_4":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_4);
                        return;
                    case "Halloween_Incline_Tile2_5":
                        PreviewBox.Image = new Bitmap(winformtest.Properties.Resources.Halloween_Incline_Tile2_5);
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
