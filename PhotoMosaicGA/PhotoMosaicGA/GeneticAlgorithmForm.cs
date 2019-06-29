using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace PhotoMosaicGA
{
    public partial class GeneticAlgorithmForm : Form
    {

        string targetString = "To be, or not to be, that is the question.";
        string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,.|!#$%&/()=? ";
        int populationSize = 400; //200;
        float mutationRate = 0.005f;
        int elitism = 40;
        int scale =20;

        //  private GeneticAlgorithm<char> ga;
        private GeneticAlgorithm<Pixel> ga;
        private Random random;

        Bitmap goal;
        Pixel[] validPixels;
        Pixel[] bitmapPixels;
        int height;
        int width;
        int size;
        float[] avgFitness;
        public GeneticAlgorithmForm(Bitmap goal, Pixel[] validPixels, int height, int width)
        {
            this.goal = goal;
            this.height = height;
            this.width = width;
            random = new Random();
            InitializeComponent();
            setBitmapPixelArray();
            if (bitmapPixels == null) MessageBox.Show("ssssss");
           // this.validPixels = bitmapPixels;
            this.validPixels = validPixels;
           // size = 400;

            size = height * width;
            //MessageBox.Show(height.ToString()+" : "+width.ToString());
          //  bitmapPixels = validPixels;
            //  setBitmapPixelArray();
            pictureBox1.Image = goal;
            pixBestMosaic.Image = getMap(bitmapPixels);
           // pixBestMosaic.Image = createBitmap(bitmapPixels);
        }

        private void btnRunGA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(targetString)) { return; }

            //   ga = new GeneticAlgorithm<char>(populationSize, targetString.Length, random, GetRandomCharacter, FitnessFunction, elitism, mutationRate);
            ga = new GeneticAlgorithm<Pixel>(populationSize, size, random, GetRandomPixel, FitnessFunction, elitism, mutationRate);

            avgFitness = new float[10000];
            int counter = 0;
            ga.NewGeneration();
            UpdateText();
            while (ga.BestFitness > 1000 && ga.Generation <10000)
            {
                ga.NewGeneration();
                UpdateText();
                avgFitness[counter] = ga.avgfitness;
                counter++;
            }
            UpdateText();
            string s = "";
            for(int i=0; i<10000;i++)
            {
                s += i.ToString() + "\t" + avgFitness[i].ToString() + "\n";
            }
            redStats.Text += "\n\n\n"+s;
            Bitmap temp = getMap(ga.BestGenes);
            temp.Save(@"image.png", ImageFormat.Png);
        }
     
        public Pixel[] getBest()
        {
            return ga.BestGenes;
        }

        private void UpdateText()
        {
            redStats.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Target Text:\t"+targetString);
         //   sb.AppendLine("Best Text:\t" +CharArrayToString(ga.BestGenes));
            sb.AppendLine("Best Fitness:\t" + ga.BestFitness.ToString());
            sb.AppendLine("Generation:\t" + ga.Generation.ToString());
            sb.AppendLine("Using Population: " + ga.Population.Count.ToString());
            redStats.Text = sb.ToString();
            picColors.Image = getMap(ga.BestGenes);
            pixBestMosaic.Image = createBest(ga.BestGenes);
            pixBestMosaic.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            Update();
        }

        private Bitmap createBest(Pixel[] genes)
        {
            string[] files = new string[genes.Length];
            string t = "";
            for(int i=0; i < files.Length; i++)
            {
                files[i] = genes[i].fileLocation;
                t += genes[i].fileLocation + "\n";
            }
            return CombineBitmap(files);
        }

        private Bitmap createBitmap(Pixel[] genes)
        {
            Bitmap bitmap = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Pixel rnd = GetRandomPixel();

                    Color col = Color.FromArgb(rnd.R, rnd.G, rnd.B);
                    bitmap.SetPixel(i, j, col);
                }
            }
            return bitmap;
        }

       private Bitmap getMap(Pixel[] genes)
       {
            Bitmap bitmap = new Bitmap(width, height);
            Color temp;
            Pixel rnd;
            int count = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    temp = Color.FromArgb(genes[count].R, genes[count].G, genes[count].B);
                    rnd = new Pixel(temp);
                    count++;
                    Color col = Color.FromArgb(rnd.R, rnd.G, rnd.B);
                    bitmap.SetPixel(i, j, col);
                }
            }
            return bitmap;
       }


        private void setBitmapPixelArray()
        {
            int count = 0;
            bitmapPixels = new Pixel[ goal.Height * goal.Width];
            for (int i = 0; i < goal.Width; i++)
            {
                for (int j = 0; j < goal.Height; j++)
                {
                        Color pix = goal.GetPixel(i, j);
                        bitmapPixels[count] = new Pixel();
                        bitmapPixels[count].R = pix.R;
                        bitmapPixels[count].G = pix.G;
                        bitmapPixels[count].B = pix.B;
                        count++;
                }
            }
        }

        private float FitnessFunction(int index)
        {
            float score = 0;
            DNA<Pixel> dna = ga.Population[index];
            Color temp = new Color() ;
            for (int i = 0; i < dna.Genes.Length; i++)
            {
                 double value = lowCostApproximation(dna.Genes[i], bitmapPixels[i]); //THe OG
                                                                                     //  double value = regularColourDistance(dna.Genes[i], bitmapPixels[i]);
                                                                                     //    double value = weightedEuclidDistance(dna.Genes[i], bitmapPixels[i]);
                                                                                     //  float value = randomPaper(dna.Genes[i], bitmapPixels[i]);
               // if (shouldDouble(dna, i))
                 //   value *= 2;
                score += (float)value;
            }
            return score;
        }

        private bool shouldDouble(DNA<Pixel> dna, int index)
        {
            try
            {
                //left
                if (dna.Genes[index].fileLocation == dna.Genes[index - 1].fileLocation)
                    return true;
            }catch(Exception ee) { }
            try
            {
                //right
                if (dna.Genes[index].fileLocation == dna.Genes[index + 1].fileLocation)
                    return true;
            }
            catch (Exception ee) { }
            try
            {
                //up
                if (dna.Genes[index].fileLocation == dna.Genes[index + scale].fileLocation)
                    return true;
            }
            catch (Exception ee) { }
            try
            {
                //down
                if (dna.Genes[index].fileLocation == dna.Genes[index - scale].fileLocation)
                    return true;
            }
            catch (Exception ee) { }
            return false;
        }

        #region different fitness Choices
        private float randomPaper(Pixel p1, Pixel p2)
        {
            float deltaR = p1.R - p2.R;
            float deltaG = p1.G - p2.G;
            float deltaB = p1.B - p2.B;
            return (3 * (deltaR * deltaR)) + (4 * (deltaG * deltaG)) + (2 * (deltaB * deltaB)); 
        }

        private double regularColourDistance(Pixel p1, Pixel p2)
        {
            double deltaR = p1.R - p2.R;
            double deltaG = p1.G - p2.G;
            double deltaB = p1.B - p2.B;
            return Math.Sqrt((deltaR * deltaR) + (deltaG * deltaG) + (deltaB * deltaB));
        }

        private double weightedEuclidDistance(Pixel p1, Pixel p2)
        {
            double deltaR = Math.Abs(p1.R - p2.R);
            double deltaG = Math.Abs(p1.G - p2.G);
            double deltaB = Math.Abs(p1.B - p2.B);
            return Math.Sqrt((3*(deltaR * deltaR)) + (4*(deltaG * deltaG)) + (2*(deltaB * deltaB)));
        }
        #endregion

        #region The Do not changeables
        //This will be get random pixel
        private char GetRandomCharacter()
        {
            int i = random.Next(validCharacters.Length);
            return validCharacters[i];
        }

        private Pixel GetRandomPixel()
        {
            int i = random.Next(validPixels.Length);
            return validPixels[i];
        }

        private double lowCostApproximation(Pixel p1, Pixel p2)
        {
            long rmean = (p1.R + (long)p2.R) / 2;
            long r = p1.R - p2.R;
            long g = p1.G - (long)p2.G;
            long b = p1.B - (long)p2.B;
            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }

        private string CharArrayToString(char[] charArray)
        {
            var sb = new StringBuilder();
            foreach(var c in charArray)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
      
        public Bitmap CombineBitmap(string[] files)
        {

            //read all images into memory
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;
            int c = 0;
            int b = 0;
            try
            {
                foreach (string image in files)
                {
                    //create a Bitmap from the file and add it to the list
                    Bitmap bitmap = new Bitmap(image);
                    images.Add(bitmap);
                }
              //  MessageBox.Show("W:" + width.ToString() + " H:" + height.ToString());
                //create a bitmap to hold the combined image
                finalImage = new System.Drawing.Bitmap(400,400);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.Black);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    int count = 0;
                    foreach (Bitmap image in images)
                    {
                        if (c >= scale)
                        {
                            b+=scale;
                            c = 0;
                            offset = 0;
                        }
                        
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(offset, b, image.Width, image.Height));
                        offset += image.Width;
                        c++;
                        count++;
                    }
               //     MessageBox.Show(files.Length.ToString());
                }
                return finalImage;
            }
            catch (Exception ee)
            {
                if (finalImage != null)
                    finalImage.Dispose();
                //throw ex;
                MessageBox.Show(ee.Message.ToString());
                throw;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }
        #endregion
    }
}
