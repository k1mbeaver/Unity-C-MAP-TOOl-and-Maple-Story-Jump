﻿
namespace winformtest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btTileSelect = new System.Windows.Forms.Button();
            this.TileListBox = new System.Windows.Forms.ListBox();
            this.btGroundSelect = new System.Windows.Forms.Button();
            this.cbTile = new System.Windows.Forms.ComboBox();
            this.cbBackGround = new System.Windows.Forms.ComboBox();
            this.lbTile = new System.Windows.Forms.Label();
            this.lbWorld = new System.Windows.Forms.Label();
            this.PreviewBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.btLoad);
            this.groupBox1.Controls.Add(this.btNew);
            this.groupBox1.Location = new System.Drawing.Point(15, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "파일";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(107, 62);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(87, 31);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "저장하기";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(9, 63);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(87, 31);
            this.btLoad.TabIndex = 1;
            this.btLoad.Text = "불러오기";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(9, 21);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(185, 35);
            this.btNew.TabIndex = 0;
            this.btNew.Text = "새로 만들기";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btTileSelect);
            this.groupBox3.Controls.Add(this.TileListBox);
            this.groupBox3.Controls.Add(this.btGroundSelect);
            this.groupBox3.Controls.Add(this.cbTile);
            this.groupBox3.Controls.Add(this.cbBackGround);
            this.groupBox3.Controls.Add(this.lbTile);
            this.groupBox3.Controls.Add(this.lbWorld);
            this.groupBox3.Controls.Add(this.PreviewBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(15, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 588);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "객체";
            // 
            // btTileSelect
            // 
            this.btTileSelect.Cursor = System.Windows.Forms.Cursors.Default;
            this.btTileSelect.Location = new System.Drawing.Point(6, 274);
            this.btTileSelect.Name = "btTileSelect";
            this.btTileSelect.Size = new System.Drawing.Size(185, 34);
            this.btTileSelect.TabIndex = 8;
            this.btTileSelect.Text = "타일 검색";
            this.btTileSelect.UseVisualStyleBackColor = true;
            this.btTileSelect.Click += new System.EventHandler(this.btTileSelect_Click);
            // 
            // TileListBox
            // 
            this.TileListBox.FormattingEnabled = true;
            this.TileListBox.ItemHeight = 12;
            this.TileListBox.Location = new System.Drawing.Point(6, 314);
            this.TileListBox.Name = "TileListBox";
            this.TileListBox.Size = new System.Drawing.Size(185, 268);
            this.TileListBox.TabIndex = 7;
            this.TileListBox.SelectedIndexChanged += new System.EventHandler(this.TileListBox_SelectedIndexChanged);
            // 
            // btGroundSelect
            // 
            this.btGroundSelect.Location = new System.Drawing.Point(6, 170);
            this.btGroundSelect.Name = "btGroundSelect";
            this.btGroundSelect.Size = new System.Drawing.Size(185, 38);
            this.btGroundSelect.TabIndex = 6;
            this.btGroundSelect.Text = "배경 지정";
            this.btGroundSelect.UseVisualStyleBackColor = true;
            this.btGroundSelect.Click += new System.EventHandler(this.btGroundSelect_Click);
            // 
            // cbTile
            // 
            this.cbTile.FormattingEnabled = true;
            this.cbTile.Items.AddRange(new object[] {
            "Normal",
            "Incline"});
            this.cbTile.Location = new System.Drawing.Point(57, 240);
            this.cbTile.Name = "cbTile";
            this.cbTile.Size = new System.Drawing.Size(137, 20);
            this.cbTile.TabIndex = 5;
            this.cbTile.SelectedIndexChanged += new System.EventHandler(this.cbTile_SelectedIndexChanged);
            // 
            // cbBackGround
            // 
            this.cbBackGround.FormattingEnabled = true;
            this.cbBackGround.Items.AddRange(new object[] {
            "Ulu City",
            "Blossom Castle",
            "Halloween"});
            this.cbBackGround.Location = new System.Drawing.Point(57, 214);
            this.cbBackGround.Name = "cbBackGround";
            this.cbBackGround.Size = new System.Drawing.Size(137, 20);
            this.cbBackGround.TabIndex = 4;
            // 
            // lbTile
            // 
            this.lbTile.AutoSize = true;
            this.lbTile.Location = new System.Drawing.Point(12, 243);
            this.lbTile.Name = "lbTile";
            this.lbTile.Size = new System.Drawing.Size(39, 12);
            this.lbTile.TabIndex = 3;
            this.lbTile.Text = "- 발판";
            this.lbTile.Click += new System.EventHandler(this.lbTile_Click);
            // 
            // lbWorld
            // 
            this.lbWorld.AutoSize = true;
            this.lbWorld.Location = new System.Drawing.Point(12, 217);
            this.lbWorld.Name = "lbWorld";
            this.lbWorld.Size = new System.Drawing.Size(39, 12);
            this.lbWorld.TabIndex = 2;
            this.lbWorld.Text = "- 배경";
            // 
            // PreviewBox
            // 
            this.PreviewBox.BackColor = System.Drawing.Color.Gray;
            this.PreviewBox.Location = new System.Drawing.Point(6, 37);
            this.PreviewBox.Name = "PreviewBox";
            this.PreviewBox.Size = new System.Drawing.Size(185, 127);
            this.PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviewBox.TabIndex = 1;
            this.PreviewBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "<미리보기>";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("맑은 고딕", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbName.Location = new System.Drawing.Point(24, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(169, 30);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Jump Map Tool";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::winformtest.Properties.Resources.Black_1000x1500;
            this.pictureBox1.Location = new System.Drawing.Point(260, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 750);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 811);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox PreviewBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.ComboBox cbBackGround;
        private System.Windows.Forms.Label lbTile;
        private System.Windows.Forms.Label lbWorld;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.ComboBox cbTile;
        private System.Windows.Forms.Button btGroundSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btTileSelect;
        private System.Windows.Forms.ListBox TileListBox;
    }
}

