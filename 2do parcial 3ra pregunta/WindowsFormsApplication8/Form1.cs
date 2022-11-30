using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int x, y, w=0;
        int[] p, q;
        string[] t = {"Fuchsia","Aquamarine","Yellow"};
        

        int mR = 0, mG = 0, mB = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            c = bmp.GetPixel(10, 10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for(int i=0;i<bmp.Width;i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i,j, Color.FromArgb(c.R,0,0));
                }
            pictureBox1.Image = bmp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox1.Image = bmp2;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            x = e.X;
            y = e.Y;
            textBox4.Text = x.ToString();
            textBox5.Text = y.ToString();
            Color c = new Color();
            mR = 0; mG = 0; mB = 0;
            for (int i = x; i < x + 10; i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Color cleido = new Color();
            cleido = bmp.GetPixel(x, y);

            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmp2.SetPixel(i, j, Color.FromName(t[w]));
                    }
                    else
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmp2;
            bmp = bmp2;
            if (w == 2)
            {
                w = 0;
            }
            else
                w++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width-10; i=i+10)
                for (int j = 0; j < bmp.Height-10; j=j+10)
                {

                    for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }
                    mRn = mRn/100;
                    mGn = mGn/100;
                    mBn = mBn/100;

                    if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                        ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                        ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.Fuchsia);
                            }
                    }
                    else
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                    

                }
            pictureBox1.Image = bmp2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
