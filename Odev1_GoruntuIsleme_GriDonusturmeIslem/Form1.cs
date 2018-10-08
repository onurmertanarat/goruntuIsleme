using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev1_GoruntuIsleme_GriDonusturmeIslem
{
    public partial class Form1 : Form
    {
        Bitmap kaynak, islem;
        public Form1()
        {
            InitializeComponent();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void renkAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bT709AlgoritmasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    double bt_709 = ((renk.R * 0.2125) + (renk.G * 0.7154) + (renk.B * 0.072));
                    int bt_709_int = Convert.ToInt32(bt_709);
                    Color gri = Color.FromArgb(bt_709_int, bt_709_int, bt_709_int);
                    islem.SetPixel(x, y, gri);
                }
                islemBox.Image = islem;
            }
        }

        private void ortalamaDeğerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen,yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x,y);
                    int ortalama_deger = ((renk.R + renk.G + renk.B) / 3);
                    Color gri = Color.FromArgb(ortalama_deger,ortalama_deger,ortalama_deger);
                    islem.SetPixel(x,y,gri);
                }
                islemBox.Image = islem;
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = openFileDialog1.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                kaynak = new Bitmap(openFileDialog1.FileName);
                kaynakBox.Image = kaynak;
            }
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islemBox.Image = kaynak;
        }

        private void kapatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lumaYöntemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    double luma_yontemi = ((renk.R * 0.3) + (renk.G * 0.59) + (renk.B * 0.11));
                    int luma_yontemi_int = Convert.ToInt32(luma_yontemi);
                    Color gri = Color.FromArgb(luma_yontemi_int,luma_yontemi_int,luma_yontemi_int);
                    islem.SetPixel(x, y, gri);
                }
                islemBox.Image = islem;
            }
        }

        private void açıklıkYöntemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x,y);                    
                    double aciklik_yontemi= (renk.R*0.25+renk.G*0.25+renk.B*0.25);
                    int aciklik_yontemi_int = Convert.ToInt32(aciklik_yontemi);
                    Color gri = Color.FromArgb(aciklik_yontemi_int,aciklik_yontemi_int,aciklik_yontemi_int);
                    islem.SetPixel(x,y,gri);
                }
                islemBox.Image = islem;
            }
        }

        private void kanalÇıkarımıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    Color renk_R = Color.FromArgb(renk.R,0,0);
                    islem.SetPixel(x, y, renk_R);
                }
                islemBox.Image = islem;
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    Color renk_G = Color.FromArgb(0,renk.G,0);
                    islem.SetPixel(x, y, renk_G);
                }
                islemBox.Image = islem;
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);
                    Color renk_B = Color.FromArgb(0,0,renk.B);
                    islem.SetPixel(x, y, renk_B);
                }
                islemBox.Image = islem;
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG|*.png";
            DialogResult sonuc = saveFileDialog1.ShowDialog();
            ImageFormat format = ImageFormat.Png;
            if (sonuc == DialogResult.OK)
            {
                islem.Save(saveFileDialog1.FileName, format);
            }
        }
    }
}
