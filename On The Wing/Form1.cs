using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace On_The_Wing
{
    public partial class Form1 : Form
    {
        Sound sn = new Sound();
        private bool MoveL = false;
        private bool MoveR = false;
        private bool Shoot = false;
        private bool SpEn = true;
        private bool WinGame = false;

        private int delay = 0;
        private int score = 0;
        private int CountTime = 0;
        private int TCountTime = 0;
        private int Wave = 1;
        private int countBonus = 0;

        //graphics
        private Bitmap[] plPic = new Bitmap[3];
        private Bitmap[] isPic = new Bitmap[3];
        private Bitmap[] enPic = new Bitmap[3];
        private Bitmap[] exPic = new Bitmap[6];
        private Bitmap bulPic;
        private Bitmap seePic;
        private Bitmap enBulPic;
        private Bitmap bonusPic;
        private Bitmap HPic;



        //object
        private Sea[] sea = new Sea[2];
        private Island[] island = new Island[3];
        private Bullet[] bullets = new Bullet[100];
        private Enemy[] enemy = new Enemy[100];
        private Explode[] explode = new Explode[100];
        private EnBullet[] enBullets = new EnBullet[100];
        private HeaLIsland heaLIsland;



        private Player player1;
        Random rnd;

        public Form1()
        {
            Sound sound = new Sound();

            rnd = new Random();
            //load graphics for player 
            plPic[0] = Resource1.player0;
            plPic[1] = Resource1.player1;
            plPic[2] = Resource1.player2;
            seePic =   Resource1.sea;

            //load graphics for island
            isPic[0] = Resource1.island0;
            isPic[1] = Resource1.island1;
            isPic[2] = Resource1.island2;
            HPic = Resource1.island3;


            //load graphics for bonus
            bonusPic = Resource1.bonus;

            //load graphics for enemy
            enPic[0] = Resource1.enemy0;
            enPic[1] = Resource1.enemy1;
            enPic[2] = Resource1.enemy2;

            //load graphics for explore
            exPic[0] = Resource1.explode0;
            exPic[1] = Resource1.explode1;
            exPic[2] = Resource1.explode2;
            exPic[3] = Resource1.explode3;
            exPic[4] = Resource1.explode4;
            exPic[5] = Resource1.explode5;

            //load graphics for bullet
            bulPic = Resource1.bullet;
            enBulPic = Resource1.bullet0;


            //make specimen
            sea[0] = new Sea(0, -300, seePic);
            sea[1] = new Sea(0, 300, seePic);

            player1 = new Player(300, 500, plPic, 2);
            island[0] = new Island(rnd.Next(600), rnd.Next(600) - 50, isPic, 2);
            island[1] = new Island(rnd.Next(600), rnd.Next(600) - 50, isPic, 2);
            island[2] = new Island(rnd.Next(600), rnd.Next(600) - 50, isPic, 2);
            heaLIsland = new HeaLIsland(rnd.Next(600), -rnd.Next(600) - 50, HPic);




            //form settings
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e) { }




        


        public void NewBullet()
        {
            int i = 0;
            int k = 0;
            while (k == 0)
            {
                if (i < 100)
                {
                    if (bullets[i] == null)
                    {
                        bullets[i] = new Bullet(player1.GetX() + 16, player1.GetY() - 32, bulPic);
                        k++;
                    }
                    i++;
                }
                else k++;

            }
        }
       
        public void NewEnemy()
        {
            int i = 0;
            int k = 0;

            while (k == 0)
            {
                if (i < 100)
                {
                    if (enemy[i] == null)
                    {
                        enemy[i] = new Enemy(rnd.Next(550), -rnd.Next(100) - 50, enPic, 2);
                        k++;
                    }
                    i++;
                }
                else k++;


            }
        }
        public void NewExplode(int x, int y)
        {
            int i = 0;
            int k = 0;

            while (k == 0)
            {
                if (i < 100)
                {
                    if (explode[i] == null)
                    {
                        explode[i] = new Explode(x, y, exPic, 5);
                        k++;
                    }
                    i++;
                }
                else k++;


            }
        }
        public void NewEnBullet(int x, int y)
        {
            int i = 0;
            int k = 0;

            while (k == 0)
            {
                if (i < 100)
                {
                    if (enBullets[i] == null)
                    {
                        enBullets[i] = new EnBullet(x, y, enBulPic);
                        k++;
                    }
                    i++;
                }
                else k++;


            }
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            CountTime++;
            if (Shoot)
            {
                if (delay < 15) { delay++; }
                else
                {
                    delay = 0;
                    NewBullet();
                }
            }

            this.Text = "\"On The Wing\"";



            if (player1.health < 5)
            {
                Application.Exit();
            }
            label1.ForeColor = System.Drawing.Color.Yellow;
            label1.Text = "Health: " + player1.health.ToString()+ "\n" + "Score: " + score.ToString()+"\n" + "Wave: " + Wave.ToString();

            //Logic game
            // Logic!
            if((CountTime > 3000) && (!WinGame))
            {
                label2.Visible = true;
                TCountTime++;
                if (Wave == 20) { WinGame = true; }
                if (TCountTime < 100 )
                {
                    
                    SpEn = false;
                    label2.Text = "Wave: " + Wave.ToString();
                    if (TCountTime == 99)
                    {
                        countBonus = rnd.Next(5);
                        Wave++;
                        timer2.Interval -= 50;
                        SpEn = true;
                        label2.Visible = false;
                        CountTime = 0;
                        TCountTime = 0;
                        player1.health = 100;
                        if (Wave == 10) { WinGame = true; }
                    }
                    

                }
            }
            if (WinGame) { label2.Text = "You are best " + "\n" + "You win!!!"; SpEn = false; label2.ForeColor = System.Drawing.Color.Yellow; label2.Visible = true;}
            Refresh();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {

            if (SpEn) { NewEnemy(); }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            //logic move 
            if (e.KeyValue == (char)Keys.Right) { MoveR = false; }
            if (e.KeyValue == (char)Keys.Left) { MoveL = false; }
            if (e.KeyValue == (char)Keys.Space) { Shoot = false; delay = 0; }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //logic move
            if (e.KeyValue == (char)Keys.Escape) { Application.Exit(); }
            if (e.KeyValue == (char)Keys.Right) { MoveR = true; }
            if (e.KeyValue == (char)Keys.Left) { MoveL = true; }
            if (e.KeyValue == (char)Keys.Space)
            {
                Shoot = true;
                NewBullet();
                sn.Pshoot();
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        
            {
                //if (!SetLab) { return; }
                Graphics g = e.Graphics;
                player1.NextFrame();
                
              
                
               

                //logic move
                if (MoveL == true) { player1.MoveLeft(); }
                if (MoveR == true) { player1.MoveRight(); }

                //Drawing object sea
                for (int i = 0; i <= 1; i++)
                {

                    sea[i].Move();
                    g.DrawImage(sea[i].bitmap, sea[i].x, sea[i].y);
                }


                //Drawing object heal island
                if (heaLIsland != null)
                {
                     heaLIsland.Move();
                     g.DrawImage(heaLIsland.bitmap, heaLIsland.x, heaLIsland.y);
                    if((heaLIsland.x + 32 > player1.GetX()) &
                      (heaLIsland.x < player1.GetX() + 32) &
                      (heaLIsland.y > player1.GetY()))
                    {
                        player1.health += 25;
                        sn.Heal();
                    heaLIsland = null;
                    }
                if (heaLIsland != null)
                {
                    if (heaLIsland.y > 600) heaLIsland = null;
                }

                 }
                
                if ((heaLIsland == null) & (rnd.Next(1000) == 1))
                 {
                     heaLIsland = new HeaLIsland(rnd.Next(600), (rnd.Next(600) - 50) * (-1), HPic);
                 }
                


                //Drawing object island
                for (int i = 0; i <= 2; i++)
                 {
                      island[i].Move();
                      g.DrawImage(island[i].GetBitmap(), island[i].x, island[i].y);
                    
                 }

                //Drawing object bullet
                for (int i = 0; i < 100; i++)
                {
                    if (bullets[i] != null)
                    {
                        bullets[i].Move();
                        g.DrawImage(bullets[i].bitmap, bullets[i].x - 6, bullets[i].y);
                        if (bullets[i].y < 0) { bullets[i] = null; }
                    }


                }


                //Drawing object enemy
                for (int i = 0; i < 100; i++)
                {
                    if (enemy[i] != null)
                    {
                        enemy[i].Move();
                        enemy[i].NextFrame();
                        g.DrawImage(enemy[i].GetBitmap(), enemy[i].x, enemy[i].y);

                        if (enemy[i].GetDelay() == 99) { NewEnBullet(enemy[i].x, enemy[i].y); }

                        if (enemy[i].y > 600) { enemy[i] = null; }
                        for (int j = 0; j < 100; j++)
                        {
                            //check for bullets hitting the enemy
                            if (bullets[j] != null & enemy[i] != null)
                            {
                                if ((bullets[j].x + 32 > enemy[i].x) &
                                   (bullets[j].x < enemy[i].x + 32) &
                                   (bullets[j].y < enemy[i].y + 32))
                                {
                                    bullets[j] = null;
                                    NewExplode(enemy[i].x, enemy[i].y);
                                    enemy[i] = null;
                                    score += 1;
                                    sn.Enhit();
                                    break;
                                }
                            }

                            //check for bullets hitting the player
                            if (enBullets[j] != null & enemy[i] != null)
                            {
                                if ((enBullets[j].x + 32 > player1.GetX()) &
                                   (enBullets[j].x < player1.GetX() + 32) &
                                   (enBullets[j].y > player1.GetY()))
                                {
                                    enBullets[j] = null;
                                    NewExplode(player1.x + rnd.Next(32), player1.y);
                                    player1.health -= 5;
                                    sn.Phit();
                                    break;
                                }
                            }

                        if (enemy[j] != null)
                        {
                            if ((enemy[j].x + 32 > player1.GetX()) &
                               (enemy[j].x < player1.GetX() + 32) &
                               (enemy[j].y > player1.GetY()))
                            {
                                enemy[j] = null;
                                NewExplode(player1.x + rnd.Next(32), player1.y);
                                player1.health -= 25;
                                sn.Phit();
                                break;
                            }
                        }
                    }
                    }
                }
                for (int j = 0; j < 4; j++) { 
                    
                    }
                if (player1.x < 0) { player1.x += 5; }
                if (player1.x > 500) { player1.x -= 5; }


                //Drawing object explode
                for (int i = 0; i < 100; i++)
                {
                    if (explode[i] != null)
                    {
                        if (explode[i].curFrame < explode[i].maxFrame)
                        {
                            explode[i].NextFrame();
                            g.DrawImage(explode[i].GetBitmap(), explode[i].x, explode[i].y);

                        }
                        else explode[i] = null;
                    }


                }
                //logic Bullets
                for (int i = 0; i < 100; i++)
                {
                    if (enBullets[i] != null)
                    {
                        if (enBullets[i].y < 550)
                        {
                            enBullets[i].Move();
                            g.DrawImage(enBullets[i].bitmap, enBullets[i].x, enBullets[i].y);

                        }
                        else enBullets[i] = null;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
              
                
            }

                //Droving object player 
                g.DrawImage(player1.GetBitmap(), player1.GetX() - 6, player1.GetY());

            }
        }
}
