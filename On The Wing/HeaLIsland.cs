using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class HeaLIsland : Static
    {
        public HeaLIsland(int x, int y, Bitmap bitmap) : base(x, y, bitmap)
        {
            this.x = x;
            this.y = y;
            this.bitmap = bitmap;
        }

        //move image
        public void Move()
        {
            y = y + 2;
        }
    }
}

