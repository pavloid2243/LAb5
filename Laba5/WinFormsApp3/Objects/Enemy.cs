using Lab5.Materials;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormsApp3.Objects
{
    class Enemy:BaseObject
    {
        public Action<Enemy> OnTimeLeft;
        public float height=30;
        public float weight=30;
        
        public Enemy(float x,float y,float angle):base(x,y,angle)
        {
           
        }
        public void Smolling(BaseObject enemy)
        {
            
                if (this.height > 5 && this.weight > 5)
                {
                    this.height *= 0.9f;
                    this.weight *= 0.9f;
                }
                else
                {
                OnTimeLeft( enemy as Enemy);
            }
            



        }
        
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.BlueViolet), -15, -15, this.height, this.weight);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }
    }
}
