using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class Explode : Animate
    {
        public Explode(int x, int y, Bitmap[] bitmap, int maxFrame) : base(x, y, bitmap, maxFrame)
        {
            this.bitmap = bitmap;
            curFrame = 0;
            this.maxFrame = maxFrame;
        }
    }
}
