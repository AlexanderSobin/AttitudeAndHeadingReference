using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AttitudeAndHeadingReference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // GLOBALS
        bool flag1 = false;
        bool flag2 = false;
        //bool flag3 = false;
        float kurcopy = 0;
        float mkcopy = 0;
        float fmcopy = 0;
        float[] range12 = { 0 };
        float[] range13 = { 0 };

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*String strelka = Application.StartupPath.ToString() + "\\Resources\\strelka.png";
            String komp = Application.StartupPath.ToString() + "\\Resources\\Kruriiii.png";
            String fmp = Application.StartupPath.ToString() + "\\Resources\\Pryamougolnichek.png";
            //textBox1.Text = "0";
            //textBox2.Text = "0";
            //textBox3.Text = "0";
            Image strel = new Bitmap(strelka);
            Image kompas = new Bitmap(komp);
            Image fmpu = new Bitmap(fmp);
            Graphics g = e.Graphics;
            g.DrawImage(kompas, 0.0f, 0.0f, 551, 561);
            g.DrawImage(strel, 0.0f, 0.0f, 551, 561);
            g.DrawImage(fmpu, 0.0f, 0.0f, 551, 561);*/
            Graphics g = e.Graphics;
            String strelka = Application.StartupPath.ToString() + "\\Resources\\img3.png";
            String komp = Application.StartupPath.ToString() + "\\Resources\\img1.png";
            String fmp = Application.StartupPath.ToString() + "\\Resources\\img2.png";
            Image strel = new Bitmap(strelka);
            Image kompas = new Bitmap(komp);
            Image fmpu = new Bitmap(fmp);
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.TranslateTransform(kompas.Width / 2.0f, kompas.Height / 2.0f);
            g.RotateTransform(-mkcopy);
            g.DrawImage(kompas, -kompas.Width / 2.0f, -kompas.Height / 2.0f, 551, 561);
            g.RotateTransform(fmcopy);
            g.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
            g.RotateTransform(-fmcopy);
            g.RotateTransform(range12[0]);
            g.DrawImage(strel, -strel.Width / 2.0f, -strel.Height / 2.0f, 551, 561);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String strelka = Application.StartupPath.ToString() + "\\Resources\\img3.png";
                String komp = Application.StartupPath.ToString() + "\\Resources\\img1.png";
                String fmp = Application.StartupPath.ToString() + "\\Resources\\img2.png";

                Image strel = new Bitmap(strelka);
                Image kompas = new Bitmap(komp);
                Image fmpu = new Bitmap(fmp);
                Graphics g1 = pictureBox1.CreateGraphics();
                g1.InterpolationMode = InterpolationMode.Bicubic;
                int mk = int.Parse(textBox1.Text);
                if (mk > 360 || mk < 0)
                {
                    MessageBox.Show("Значение должно быть в переделах от 0 до 360");
                    textBox1.Text = "0";
                }
                else
                {
                    while (mk > 360)
                        mk -= 360;
                    while (mk < -360)
                        mk += 360;
                    textBox1.Text = Convert.ToString(mk);
                    flag1 = true;
                    mkcopy = mk;
                    if (!flag2)
                    {
                        g1.TranslateTransform(kompas.Width / 2.0f, kompas.Height / 2.0f);
                        g1.RotateTransform(-mk);
                        g1.DrawImage(kompas, -kompas.Width / 2.0f, -kompas.Height / 2.0f, 551, 561);
                        g1.DrawImage(strel, -strel.Width / 2, -strel.Height / 2, 551, 561);
                        g1.RotateTransform(fmcopy);
                        g1.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        g1.RotateTransform(-fmcopy);
                        //g1.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        float text_b2 = 360 - mk;
                        textBox2.Text = (Convert.ToString(text_b2));
                    }
                    else
                    {
                        g1.TranslateTransform(kompas.Width / 2.0f, kompas.Height / 2.0f);
                        g1.RotateTransform(-mkcopy);
                        g1.DrawImage(kompas, -kompas.Width / 2.0f, -kompas.Height / 2.0f, 551, 561);
                        g1.RotateTransform(fmcopy);
                        g1.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        g1.RotateTransform(-fmcopy);
                //      g1.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        g1.RotateTransform(range12[0]);
                        g1.DrawImage(strel, -strel.Width / 2.0f, -strel.Height / 2.0f, 551, 561);
                        kurcopy = 360 - mkcopy + range12[0];
                        if (kurcopy > 360)
                            kurcopy -= 360;
                        if (kurcopy < -360)
                            kurcopy += 360;
                        textBox2.Text = (Convert.ToString(kurcopy));
                        //flag2 = false;
                    }
                    label4.Text = (Convert.ToString(mk)) + "°";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода, попробуйте еще раз");
                textBox1.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //sad
        }

        private void label1_Click(object sender, EventArgs e)
        {
            /*nothing to do here*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String strelka = Application.StartupPath.ToString() + "\\Resources\\img3.png";
                String komp = Application.StartupPath.ToString() + "\\Resources\\img1.png";
                String fmp = Application.StartupPath.ToString() + "\\Resources\\img2.png";
                Image strel = new Bitmap(strelka);
                Image kompas = new Bitmap(komp);
                Image fmpu = new Bitmap(fmp);
                Graphics g2 = pictureBox1.CreateGraphics();
                g2.InterpolationMode = InterpolationMode.Bicubic;
                int kur = int.Parse(textBox2.Text);
                if (kur > 360 || kur < 0)
                {
                    MessageBox.Show("Значение должно быть в переделах от 0 до 360");
                    textBox2.Text = "0";
                }
                else
                {
                    while (kur > 360)
                        kur -= 360;
                    while (kur < -360)
                        kur += 360;
                    textBox2.Text = Convert.ToString(kur);
                    int i = 0;
                    range12[i] = kur + mkcopy;
                    while (range12[0] > 360)
                        range12[0] -= 360;
                    while (range12[0] < -360)
                        range12[0] += 360;
                    //label1.Text = Convert.ToString(range[i]);
                    i++;
                    flag2 = true;
                    kurcopy = kur;
                    if (!flag1)
                    {
                        //Refresh();
                        g2.DrawImage(kompas, 0, 0, 551, 561);
                        g2.TranslateTransform(strel.Width / 2.0f, strel.Height / 2.0f);
                        g2.RotateTransform(kur);
                        g2.DrawImage(strel, -strel.Width / 2.0f, -strel.Height / 2.0f, 551, 561);
                        g2.TranslateTransform(0, 0);
                        g2.RotateTransform(-kur);
                        g2.RotateTransform(fmcopy);
                        g2.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        g2.RotateTransform(-fmcopy);
                        //g2.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                    }
                    else
                    {
                        g2.TranslateTransform(kompas.Width / 2.0f, kompas.Height / 2.0f);
                        g2.RotateTransform(-mkcopy);
                        g2.DrawImage(kompas, -kompas.Width / 2.0f, -kompas.Height / 2.0f, 551, 561);
                        g2.RotateTransform(fmcopy);
                        g2.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        g2.RotateTransform(-fmcopy);
                     // g2.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                        g2.RotateTransform(kurcopy + mkcopy);
                        g2.DrawImage(strel, -strel.Width / 2.0f, -strel.Height / 2.0f, 551, 561);
                        //flag1 = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода, попробуйте еще раз");
                textBox2.Text = "0";
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String strelka = Application.StartupPath.ToString() + "\\Resources\\img3.png";
                String komp = Application.StartupPath.ToString() + "\\Resources\\img1.png";
                String fmp = Application.StartupPath.ToString() + "\\Resources\\img2.png";
                Image strel = new Bitmap(strelka);
                Image kompas = new Bitmap(komp);
                Image fmpu = new Bitmap(fmp);
                Graphics g3 = pictureBox1.CreateGraphics();
                g3.InterpolationMode = InterpolationMode.Bicubic;
                // float text3 = Convert.ToSingle(textBox3.Text);
                int fm = int.Parse(textBox3.Text);
                int j = 0;
                range13[j] = fm + mkcopy;
                //label1.Text = Convert.ToString(range13[j]);
                j++;
                fmcopy = fm;
                if (fm > 360 || fm < 0)
                {
                    MessageBox.Show("Значение должно быть в переделах от 0 до 360");
                    textBox3.Text = "0";
                    fmcopy = 0;
                }
                else
                {
                    /* g3.DrawImage(kompas, 0, 0, 551, 561);
                     g3.TranslateTransform(fmpu.Width / 2.0f, fmpu.Height / 2.0f);
                     g3.RotateTransform(fm);
                     g3.DrawImage(fmpu, -fmpu.Width / 2.0f, -fmpu.Height / 2.0f, 551, 561);
                     g3.TranslateTransform(0, 0);
                     g3.RotateTransform(-fm);
                     g3.DrawImage(strel, -strel.Width / 2, -strel.Height / 2, 551, 561);*/

                    g3.TranslateTransform(kompas.Width / 2.0f, kompas.Height / 2.0f);
                    g3.RotateTransform(-mkcopy);
                    g3.DrawImage(kompas, -kompas.Width / 2.0f, -kompas.Height / 2.0f, 551, 561);
                    g3.RotateTransform(fmcopy);
                    g3.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                    g3.RotateTransform(-fmcopy);
                    g3.RotateTransform(range12[0]);
                    g3.DrawImage(strel, -strel.Width / 2.0f, -strel.Height / 2.0f, 551, 561);
                    textBox3.Text = (Convert.ToString(fm));
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода, попробуйте еще раз");
                textBox3.Text = "0";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            string NullText = "0";
            label4.Text = "0°";
            textBox1.Text = NullText;
            textBox2.Text = NullText;
            textBox3.Text = NullText;
            range12[0] = 0;
            range13[0] = 0;
            fmcopy = 0;
            mkcopy = 0;
            kurcopy = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // flag2 = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           /* String strelka = Application.StartupPath.ToString() + "\\Resources\\strelka.png";
            String komp = Application.StartupPath.ToString() + "\\Resources\\Kruriiii.png";
            String fmp = Application.StartupPath.ToString() + "\\Resources\\Pryamougolnichek.png";
            Image strel = new Bitmap(strelka);
            Image kompas = new Bitmap(komp);
            Image fmpu = new Bitmap(fmp);
            Graphics g4 = pictureBox1.CreateGraphics();
            g4.InterpolationMode = InterpolationMode.Bicubic;
                g4.TranslateTransform(kompas.Width / 2.0f, kompas.Height / 2.0f);
                g4.RotateTransform(-mkcopy);
                g4.DrawImage(kompas, -kompas.Width / 2.0f, -kompas.Height / 2.0f, 551, 561);
                g4.RotateTransform(fmcopy);
                g4.DrawImage(fmpu, -fmpu.Width / 2, -fmpu.Height / 2, 551, 561);
                g4.RotateTransform(-fmcopy);
                g4.RotateTransform(range12[0]);
                g4.DrawImage(strel, -strel.Width / 2.0f, -strel.Height / 2.0f, 551, 561);*/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
