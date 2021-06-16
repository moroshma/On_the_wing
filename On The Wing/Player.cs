using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    class Player : Animate
    {
        public int health {get; set;}
        public int delay;
        public Player(int x, int y, Bitmap[] bitmap, int maxFrame) : base(x, y, bitmap, maxFrame)
        {
            this.bitmap = bitmap;
            curFrame = 0;
            this.maxFrame = maxFrame;
            health = 100;
            delay = 0;
        }
        public int GetX() { return x; }
        public int GetY() { return y; }
        public void MoveLeft() 
        { x -= 5; }
        public void MoveRight()
        { x += 5; }
        public override void NextFrame() 
        { if(delay < 3) { delay++; }
          else
            {
                delay = 0;
                if (curFrame < maxFrame)
                {
                    curFrame++;
                }
                else curFrame = 0;
            }
        }
    }
}
