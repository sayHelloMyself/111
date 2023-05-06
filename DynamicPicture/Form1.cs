using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        Image imaGirl;
        Image[] imaGrass;
        Image[] imaCircle;
        Image[] imaEar;
        Image[] imaMoustache;
        int idx;
       
        public enum EffectStyle { None,Grass,CatEar};

        EffectStyle effect = new EffectStyle();



        /// <summary>
        /// 资源载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            imaGirl = Image.FromFile("girl2.jpeg");
            imaGrass = new Image[61];
            imaCircle = new Image[61];
            imaEar = new Image[80];
            imaMoustache = new Image[80];
            for(int i = 0;i < 61; i++)
            {
                imaGrass[i] = Image.FromFile("res/grass/grass_" + i.ToString("D3")+".png");
                imaCircle[i] = Image.FromFile("res/yuan/yuan_" + i.ToString("D3") + ".png");
            }
            for(int i = 0;i < 80; i++)
            {
                imaEar[i] = Image.FromFile("res/ear/ear_" + i.ToString("D3") + ".png");
                imaMoustache[i] = Image.FromFile("res/moustache/moustache_" + i.ToString("D3") + ".png");
            }
            timer1.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(imaGirl, 0, 0);

            if(effect==EffectStyle.Grass) //种草
            {
                g.DrawImage(imaGrass[idx%61], 65, -20);
                g.DrawImage(imaCircle[idx % 61], 130, 200);
            }
            else if(effect == EffectStyle.CatEar) //猫耳朵
            {
                g.DrawImage(imaEar[idx % 80], 70, 0);
                g.DrawImage(imaMoustache[idx % 80], 52, 175);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            idx++;

            pictureBox1.Invalidate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            effect = EffectStyle.CatEar;
            idx = 0;
            axWindowsMediaPlayer1.URL = "res/sound/dance_with_my_love.mp3";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            effect = EffectStyle.Grass;
            idx = 0;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
