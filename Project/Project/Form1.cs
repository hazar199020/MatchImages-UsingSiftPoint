using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.ComponentData;
using System.IO;
using EngMATLib;
using Pro;



namespace Project
{

    public partial class Form1 : Form
    {


        private String I_name;
        private Bitmap image;
        private String s = null, s1 = null;
        private ConnectDB db = null;
        private String[] images = new String[21];
        private PictureBox[] boxes = new PictureBox[6];
        private Label[] labels = new Label[6];
        private int j = 0;
        private String x;

        public Form1()
        {
            InitializeComponent();

            boxes[0] = this.pictureBox2;
            boxes[1] = this.pictureBox3;
            boxes[2] = this.pictureBox4;
            boxes[3] = this.pictureBox5;
            boxes[4] = this.pictureBox6;
            boxes[5] = this.pictureBox7;


            labels[0] = this.label1;
            labels[1] = this.label2;
            labels[2] = this.label3;
            labels[3] = this.label4;
            labels[4] = this.label5;
            labels[5] = this.label6;

            for (int i = 0; i < images.Length; i++)
            {
                images[i] = null;
            }
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.openFileDialog1.ShowDialog();
            I_name = this.openFileDialog1.FileName.ToString();
            image = new Bitmap(I_name);
            this.pictureBox1.Image = image;
            s = this.openFileDialog1.FileName.ToString();
            openFileDialog1.Filter = "*.jpg|*.*";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                this.boxes[i].Image = null;
                this.labels[i].Text = " ";
            }
            j = 0;
            this.progressBar1.Value = 0;
            this.progressBar1.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label7.Text = Convert.ToString(0);

            try
            {
                Pro.Matlab m = new Pro.Matlab();
                MWArray mw = null,w1=null,w2=null;

                if (s == null)
                {
                    MessageBox.Show("لم تختر صورة بعد");
                }
                else
                {
                   db = new ConnectDB();
                    images=db.ConnectHere(this.s);
                    this.label9.Visible = true;
                    this.label9.Text +=Convert.ToString(db.get_Keypoint());
                    int k = db.get_Keypoint();
                    int h = 0;


                   w1= m.sift(s.ToString());

             
                    for (int i = 0; i < 21; i++)
                    {

                        x = db.get_The_Closest_KeyPoint();
                        if (x != null)
                        {
                            w2 = m.sift(x.ToString());
                            mw = m.match(w1, w2);

                            h = Convert.ToInt16(mw.ToString());

                            this.label7.Text = Convert.ToString(i + 1);
                            this.Refresh();
                            if (h > 4)
                            {

                                boxes[j].Image = new Bitmap(x);
                                labels[j].Visible = true;
                                labels[j].Text = Convert.ToString("عدد نقاط التطابق" + h + "\n and the path is" + x);
                                this.labels[j].Refresh();
                                this.Refresh();
                                boxes[j].Refresh();
                                j++;




                            }
                        }
                        this.label7.Text = Convert.ToString(i + 1);
                        this.progressBar1.Value += 100 / 21;

                    }
                


                }

            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }
            this.progressBar1.Value = 100;
            MessageBox.Show("انتهى البحث");
            this.label9.Text ="keypoint:";
        }

      





    }
}



