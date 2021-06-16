using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class Enemy : Animate
    {
        private int delay;
        public Enemy(int x, int y, Bitmap[] bitmap, int maxFrame) : base(x, y, bitmap, maxFrame)
        {
            this.bitmap = bitmap;
            curFrame = 0;
            this.maxFrame = maxFrame;
        }
        public int GetDelay()
        {
            return delay;
        }
        public void Move()
        {
            y += 3;
            if (delay < 100) { delay++; }
            else delay = 0;
        }
    }
}
