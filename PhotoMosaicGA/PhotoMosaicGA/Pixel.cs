using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMosaicGA
{
    public class Pixel
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int index { get; set; }
        public string fileLocation { get; set; }
        public Pixel() { }

        public Pixel(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }
    }
}
