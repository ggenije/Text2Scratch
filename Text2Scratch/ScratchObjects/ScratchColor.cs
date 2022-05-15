using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal struct ScratchColor
    {
        int r, g, b,a;
        public ScratchColor(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 255;
        }

        public ScratchColor(int r, int g, int b,int a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }


        public static ScratchColor ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return new ScratchColor(v, t, p);
            else if (hi == 1)
                return new ScratchColor(q, v, p);
            else if (hi == 2)
                return new ScratchColor( p, v, t);
            else if (hi == 3)
                return new ScratchColor( p, q, v);
            else if (hi == 4)
                return new ScratchColor(t, p, v);
            else
                return new ScratchColor(v, p, q);
        }


        public override string ToString()
        {
            return "#" +
                (a==255?string.Empty:a.ToString("X"))+
                r.ToString("X") + 
                g.ToString("X") +
                b.ToString("X");
        }
    }
}
