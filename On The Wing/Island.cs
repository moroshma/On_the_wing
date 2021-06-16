using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class Island : Animate
    {
        static Random rnd = new Random();
       
        //private Bitmap bitmap_h;


        public Island(int x, int y, Bitmap[] bitmap, int maxFrame) : base(x, y, bitmap, maxFrame)
        {

            curFrame = rnd.Next(3);
        }

       
        
        public void Move()
        {
            y = y + 2;
            if (y >= 600)
            {
                y = -rnd.Next(600) - 50;
                x = rnd.Next(600);
                //NextFrame();
            }
        }

    }
}
