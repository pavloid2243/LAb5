using Lab5.Materials;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp3.Objects;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        NewRectangle rect;
        Player player;
        Marker marker;
        Enemy enemy;
        public Form1()
        {
            InitializeComponent();
            player = new Player(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            enemy = new Enemy(30, 30, 0);
            objects.Add(player);
            objects.Add(enemy);

            player.OnOverlap += (p, obj) =>
            {
                txtlog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtlog.Text;
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            enemy.OnTimeLeft += (l) =>
            {
                objects.Remove(l);
                enemy = null;
            };
            player.OnEnemyOverlap += (e) =>
            {
                objects.Remove(e);
                enemy = null;
            };

            

            marker = new Marker(pictureBox1.Width / 2 + 50, pictureBox1.Height / 2 + 50, 0);
            objects.Add(marker);
          // enemy = new Enemy(pictureBox1.Width / 2 + 90, pictureBox1.Height / 2 + 90, 0);
           // objects.Add(enemy);
            
           





        }
        
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            
            SmollEnemy();
            

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }
            }

            
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
                
            }

        } 
       
        private void UpdatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.x - player.x;
                float dy = marker.y - player.y;
                float lenght = MathF.Sqrt(dx * dx + dy * dy);
                dx /= lenght;
                dy /= lenght;
                player.vx += dx * 0.5f;
                player.vy += dy * 0.5f;
                player.angle = 90 - MathF.Atan2(player.vx, player.vy) * 180 / MathF.PI;
                player.vx += -player.vx * 0.1f;
                player.vy += -player.vy * 0.1f;
                player.x += player.vx;
                player.y += player.vy;

                pictureBox1.Invalidate();
            }
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            UpdatePlayer();
            
            pictureBox1.Invalidate();
            
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); // и главное не забыть пололжить в objects
            }
            marker.x = e.X;
            marker.y = e.Y;
        }

       private void SmollEnemy()
        {

            if (enemy != null) enemy.Smolling(enemy);
            else
            {
                var rnd = new Random();
                int i = rnd.Next(300);
                enemy = new Enemy(i, i, 0);
                objects.Add(enemy);
                enemy.x = i;
                enemy.y = i;
                
            }
            
        }
    }
    }

