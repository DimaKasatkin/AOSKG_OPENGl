using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Osxy
    {
        public Single x { get; set; }
        public Single y { get; set; }
        public Single z { get; set; }
        public Osxy(Single x, Single y)
        {
            this.x = x;
            this.y = y;
        }

        public Osxy(Single x, Single y, Single z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
