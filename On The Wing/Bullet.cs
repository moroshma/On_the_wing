using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class Bullet : Static
    {
        public Bullet(int x, int y, Bitmap bitmap) : base(x, y, bitmap)
        {
            this.x = x;
            this.y = y;
            this.bitmap = bitmap;
        }
        public void Move() { y -= 5; }
    }
}
