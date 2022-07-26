using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Osxy
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Osxy(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Osxy(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
