using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class EnBullet : Static
    {
        public EnBullet(int x, int y, Bitmap bitmap) : base(x, y, bitmap)
        {
            this.x = x;
            this.y = y;
            this.bitmap = bitmap;
        }
        public void Move() { y += 5; }
    }
}
