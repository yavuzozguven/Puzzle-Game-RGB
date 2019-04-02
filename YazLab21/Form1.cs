using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace YazLab21
{
    public partial class Form1 : Form
    {
        string isim;
        Image image = null;
        PictureBox picturebox_hepsi = null;
        int[] cerceve;
        int score = 100;
        public Form1()
        {
            InitializeComponent();
            isim = Microsoft.VisualBasic.Interaction.InputBox("İsminiz:", "İsminiz","Örn:Ali");
            DosyaOku();
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog() == DialogResult.OK)
            {
                progress.Visible = true;
                progress.Value = 100;
                progress.Maximum = 100;
                progress.Minimum = 0;
                label1.Visible = true;
                label1.Text = "Skorunuz:100";
                FileInfo fi = new FileInfo(op.FileName);
                image = bmpOlustur(Image.FromFile(op.FileName));
                if (picturebox_hepsi == null)
                {
                    picturebox_hepsi = new PictureBox();
                    picturebox_hepsi.Width = groupBoxPuzzle.Width;
                    picturebox_hepsi.Height = groupBoxPuzzle.Height;
                    groupBoxPuzzle.Controls.Add(picturebox_hepsi);
                }
                //picturebox_hepsi.Image = image;
            }
        }


        private Bitmap bmpOlustur(Image image)
        {
            Bitmap bitmap = new Bitmap(groupBoxPuzzle.Width, groupBoxPuzzle.Height);
            Graphics gr = Graphics.FromImage(bitmap);
            gr.Clear(Color.White);
            gr.DrawImage(image, new Rectangle(0, 0, groupBoxPuzzle.Width, groupBoxPuzzle.Height));
            gr.Flush();
            return bitmap;
        }

        PictureBoxlar[] pb = null;
        Image[] imgs = null;

        private void bmpBol()
        {
            /*pb = new PictureBoxlar[16];
            imgs = new Image[16];*/
            if(picturebox_hepsi != null)
            {
                groupBoxPuzzle.Controls.Remove(picturebox_hepsi);
                picturebox_hepsi.Dispose();
                picturebox_hepsi = null;
            }
            if(pb == null)
            {
                pb = new PictureBoxlar[16];
                imgs = new Image[16];
            }

            int[] indisler = new int[16];
            int x = groupBoxPuzzle.Width / 4;
            int y = groupBoxPuzzle.Height/ 4;
            for (int i = 0; i < 16; i++)
            {
                indisler[i] = i;
                if(pb[i] == null)
                {
                    pb[i] = new PictureBoxlar();
                    pb[i].Click += new EventHandler(Puzzletiklama);
                }
                pb[i].Width = x;
                pb[i].Height = y;
                pb[i].Index = i;
                BitmapGorselOlustur(image, imgs, i, 4, 4, x, y);
                pb[i].Location = new Point(x * (i % 4), y * (i / 4));
                if (!groupBoxPuzzle.Controls.Contains(pb[i]))
                {
                    groupBoxPuzzle.Controls.Add(pb[i]);
                }
            }
            Karistir(ref indisler);
            for (int i = 0; i < 16; i++)
            {
                pb[i].Image = imgs[indisler[i]];
                pb[i].ImageIndex = indisler[i];
            }


            for (int i = 0; i < 2; i++)
            {
                pb[cerceve[i]].BorderStyle = BorderStyle.Fixed3D;
            }
            


        }

        private void ResimYerDegistir(PictureBoxlar pbl1 , PictureBoxlar pbl2)
        {
            if(EslesiyorMu(pbl1, pbl2))
            {
                int tmp = pbl2.ImageIndex;
                pbl2.Image = imgs[pbl1.ImageIndex];
                pbl2.ImageIndex = pbl1.ImageIndex;
                pbl1.Image = imgs[tmp];
                pbl1.ImageIndex = tmp;
                label1.Text = "Skorunuz:" + score;
            }
            else
            {
                score -= 5;
                if (score < 0)
                    score = 0;
                progress.Value = score;
                label1.Text = "Skorunuz:" + score;
            }
            if (BittiMi())
            {
                Microsoft.VisualBasic.Interaction.MsgBox("Oyun bitti.Skorunuz:"+score);
                DosyaYaz();
                Application.Exit();
            }
        }

        
        
        private bool BittiMi()
        {
            int kontrol = 0;
            Bitmap bmp=null;
            for (int z = 0; z < 16; z++)
            {
                int index = pb[z].ImageIndex;
                bmp = new Bitmap(pb[z].Image);
                Bitmap bmp2 = new Bitmap(imgs[z]);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color clr = bmp.GetPixel(i, j);
                        Color clr2 = bmp2.GetPixel(i, j);
                        if (clr == clr2)
                            kontrol++;
                    }
                }
            }
            if (kontrol == bmp.Width * bmp.Height * 16)
                return true;
            

            return false;
        }

        private bool EslesiyorMu(PictureBoxlar pbldegisen,PictureBoxlar pblgidilen)
        {
            Bitmap bmp = new Bitmap(pbldegisen.Image);
            Bitmap bmp2 = new Bitmap(imgs[pblgidilen.Index]);
            int kontrol = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color clr = bmp.GetPixel(i, j);
                    Color clr2 = bmp2.GetPixel(i,j);
                    if (clr == clr2)
                        kontrol++;
                }
            }
            if(kontrol == bmp.Width * bmp.Height)
            {
                return true;
            }
           
            return false;
        }

        private void DosyaOku()
        {
            string path = "C:\\Users\\Yavuz\\Desktop\\score.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            List<string> satirlar = new List<string>();
            List<int> dizi = new List<int>();
            if (File.Exists(path))
            {
                string oku="";
                while ((oku = file.ReadLine()) != null)
                {
                    string[] ayir = oku.Split(',');
                    dizi.Add(Convert.ToInt32(ayir[1]));
                    satirlar.Add(oku);
                }
                int index = dizi.IndexOf(dizi.Max());
                high_score.Text = "En yüksek skor:\n" + satirlar[index].Split(',')[0].ToUpper()+":"+ satirlar[index].Split(',')[1];
                file.Close();
            }


        }

        private void DosyaYaz()
        {
            string path = "C:\\Users\\Yavuz\\Desktop\\score.txt";
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(isim+","+score);
            sw.Close();
        }

        PictureBoxlar pb1;
        PictureBoxlar pb2;
        public void Puzzletiklama(object sender,EventArgs e)
        {
            if(pb1 == null)
            {
                pb1 = (PictureBoxlar)sender;
                pb1.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (pb2 == null)
            {
                pb2 = (PictureBoxlar)sender;
                pb1.BorderStyle = BorderStyle.FixedSingle;
                pb2.BorderStyle = BorderStyle.Fixed3D;
                ResimYerDegistir(pb1, pb2);
                pb1 = null;
                pb2 = null;
            }
            else
            {
                pb1 = pb2;
                pb1.BorderStyle = BorderStyle.FixedSingle;
                pb2 = (PictureBoxlar)sender;
                pb2.BorderStyle = BorderStyle.Fixed3D;
                ResimYerDegistir(pb1, pb2);
            }
        }

        private void Karistir(ref int[] arr)
        {
            Random r = new Random();
            int n = arr.Length;
            while (n > 1)
            {
                int k = r.Next(n);
                n--;
                int temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
            int kontrol = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr[i])
                    kontrol++;
            }
            cerceve = new int[16];
            while (kontrol != 2)
            {
                while (n > 1)
                {
                    int k = r.Next(n);
                    n--;
                    int temp = arr[n];
                    arr[n] = arr[k];
                    arr[k] = temp;
                }
                kontrol = 0;
                n = arr.Length;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == arr[i]) {
                        cerceve[kontrol] = i;
                        kontrol++;
                }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private void BitmapGorselOlustur(Image image,Image[] imgs,int index,int satir,int sutun,int x,int y)
        {
            imgs[index] = new Bitmap(x, y);

            Graphics gr = Graphics.FromImage(imgs[index]);
            gr.Clear(Color.White);
            gr.DrawImage(image, new Rectangle(0, 0, x, y), new Rectangle(x * (index % sutun), y * (index / sutun), x, y), GraphicsUnit.Pixel);
            gr.Flush();
        }

        private void shuffle_Click(object sender, EventArgs e)
        {
            bmpBol();
        }
    }
}
