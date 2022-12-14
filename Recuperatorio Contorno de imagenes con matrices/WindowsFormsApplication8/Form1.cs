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
        Bitmap resultante;
        int x, y;
        int mR = 0, mG = 0, mB = 0;
        int[,] matriz3x3 = new int[3, 3];
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
            for (int i=x; i<x+10; i++)
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
                        bmp2.SetPixel(i, j, Color.Fuchsia);
                    }
                    else
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                    
                }
            pictureBox1.Image = bmp2;
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

        private void button8_Click(object sender, EventArgs e)
        {
            int p = 0;
            int q = 0;
            resultante = new Bitmap(bmp.Width, bmp.Height);
            Color rColor = new Color();
            Color oColor = new Color();

            float g = 0;

            for ( p = 0; p < bmp.Width; p++)
            {
                for ( q = 0; q < bmp.Height; q++)
                {
                    
                    oColor = bmp.GetPixel(p, q);

                    g = oColor.R * 0.299f + oColor.G * 0.587f + oColor.B * 0.114f;
                    rColor = Color.FromArgb((int)g, (int)g, (int)g);
                    resultante.SetPixel(p, q, rColor);
                }
            }
            pictureBox1.Image = resultante;
            this.Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            matriz3x3 = new int[,] { { -1, 0, -1 }, { 0, 4, 0 }, { -1, 0 ,- 1 } };

            //poner la imagen en tono de grises
            button8_Click( sender, e);
            Bitmap intermedio = (Bitmap)resultante.Clone();
            ConvergerGris(matriz3x3, intermedio, 32, 64);
            
            this.Invalidate();
        }

        private void ConvergerGris(int[,] pMatriz, Bitmap pImagen, int pInferior, int pSuperior) { 
        
            int x1=0;
            int y1 = 0;
            int a = 0;
            int b = 0;
            Color oColor;

            int suma = 0;

            for ( x1 = 1; x1 < pImagen.Width-1; x1++)
            {
                for ( y1 = 1; y1 < pImagen.Height-1; y1++)
                {
                    suma = 0;
                    for ( a = -1; a < 2; a++)
                    {
                        for ( b = -1; b < 2; b++)
                        {
                            oColor = pImagen.GetPixel(x1 + a, y1 + b);
                            suma = suma + (oColor.R * pMatriz[a + 1, b + 1]);

                        }
                    }
                    if (suma < pInferior)
                        suma = 0;
                    else if (suma > pSuperior)
                        suma = 255;
                    resultante.SetPixel(x1, y1, Color.FromArgb(suma, suma, suma));
                }
            }
            pictureBox1.Image = resultante;

        
        
        }


    }
}
