using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMosaicGA
{
    public partial class Form1 : Form
    {
        #region global variables
        string imagePath;
        string jsonPath;
        string imageDatabasePath;
        int arrWidth;
        int arrHeight;
        Bitmap bitmap;
        Pixel[] pixels;
        Bitmap newBitmap;
        #endregion

        #region constants
        const int SCALE = 20;
        #endregion

        public Form1()
        {
            InitializeComponent();
            btnMosaic.Enabled = false;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                    imagePath = ofd.FileName;
                else
                    return;
            }
            picBoxOG.Image = Image.FromFile(imagePath);
            bitmap = (Bitmap)picBoxOG.Image;
            arrWidth = bitmap.Width / SCALE;
            arrHeight = bitmap.Height / SCALE;
            btnMosaic.Enabled = true;
            bitmap = ResizeImage(picBoxOG.Image, arrWidth, arrHeight);

            //   MessageBox.Show(arrWidth.ToString() + "x" + arrHeight.ToString());
        }

        private void btnMosaic_Click(object sender, EventArgs e)
        {
           // picBoxMosaic.Image = bitmap;
            //  MessageBox.Show(arrWidth.ToString() + " : " + arrHeight.ToString() + "\n" + bitmap.Width.ToString() + " : " + bitmap.Height.ToString());
            //MessageBox.Show(bitmap.GetPixel(0, 0).ToString());
            pixels = getPixelArray(arrWidth, arrHeight);
          
            string s = "List:\n";
            int count = 0;
            newBitmap = new Bitmap(arrWidth, arrHeight, PixelFormat.Format24bppRgb);
            for (int i = 0; i < arrWidth; i++)
            {
                for (int j = 0; j < arrHeight; j++)
                {
                    newBitmap.SetPixel(i, j, Color.FromArgb(pixels[count].R, pixels[count].G, pixels[count].B));
                    count++;
                }
            }
            picBoxMosaic.Image = newBitmap;

                    //for(int i=0; i< 5; i++)
                    //int count = 0;

                    /*   try
                       {
                           while (pixels[count] != null)
                           {
                               int r = pixels[count].R;
                               int g = pixels[count].G;
                               int b = pixels[count].B;
                               s += string.Format("{0}) R: {1}, G: {2}, B: {3} \n", count, r, g, b);
                               count++;
                           }
                       }
                       catch (Exception ee) { }
                       Clipboard.SetText(s);*/

                }

        private Pixel[] getPixelArray(int width, int height)
        {
            Pixel[] pixs = new Pixel[width * height];
            int counter = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                        Color pix = bitmap.GetPixel(i, j);
                        pixs[counter] = new Pixel();
                        pixs[counter].R = pix.R;
                        pixs[counter].G = pix.G;
                        pixs[counter].B = pix.B;
                        counter++; 
                }
            }
            
            return pixs;
        }


                public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnSpawn_Click(object sender, EventArgs e)
        {
            //string json = File.ReadAllText(@"C:\Users\japie\Desktop\ObamaPics\newJson.json");
            string json = File.ReadAllText(@"C:\Users\japie\Desktop\Imagedb\newJson.json");
            var allThePixels = JsonConvert.DeserializeObject<List<Pixel>>(json);
            picBoxMosaic.Image = newBitmap;
         //   GeneticAlgorithmForm gaf = new GeneticAlgorithmForm(newBitmap, temp, arrHeight, arrWidth);
               GeneticAlgorithmForm gaf = new GeneticAlgorithmForm(newBitmap, allThePixels.ToArray(), arrHeight, arrWidth);
            //   GeneticAlgorithmForm gaf = new GeneticAlgorithmForm(newBitmap, pixels,arrHeight,arrWidth);
            gaf.Show();
        }

                Random random;
        private Pixel GetRandomPixel()
        {
            int i = random.Next(pixels.Length);
            return pixels[i];
        }

        #region Random image
        public Bitmap getRandomBitmap()
        {
            for (int i = 0; i < arrWidth; i++)
            {
                for (int j = 0; j < arrHeight; j++)
                {
                    Pixel rnd = GetRandomPixel();

                    Color col = Color.FromArgb(rnd.R, rnd.G, rnd.B);
                    bitmap.SetPixel(i, j, col);
                }
            }
            return bitmap;
        }
        #endregion

        private double colourDistance(Pixel p1, Pixel p2)
        {
            long rmean = (p1.R + (long)p2.R) / 2;
            long r = p1.R - p2.R;
            long g = p1.G - (long)p1.G;
            long b = p1.B - (long)p1.B;
            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
