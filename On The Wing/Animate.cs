using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace On_The_Wing
{
    public class Animate : Base
    {
        protected Bitmap[] bitmap = new Bitmap[100];
        private Bitmap bitmap1;

        public int curFrame { get; set; }
        public int maxFrame { get; set; }

        public Animate(int x, int y, Bitmap[] bitmap, int maxFrame) : base(x, y)
        {
            this.bitmap = bitmap;
            curFrame = 0;
            this.maxFrame = maxFrame;
        }

      

        public virtual void NextFrame()
        {
            if (curFrame < maxFrame)
            {
                curFrame++;
            }
            else { curFrame = 0; }
        }
        public void SetBitmap(Bitmap[] bitmap)
        {
            this.bitmap = bitmap;
        }
        public Bitmap GetBitmap()
        {
            return bitmap[curFrame];
        }




    }
}
