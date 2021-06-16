using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace On_The_Wing
{
    class Static : Base
    {
        public Bitmap bitmap { get; set; }


        public Static(int x, int y, Bitmap bitmap) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.bitmap = bitmap;
        }


    }
}
