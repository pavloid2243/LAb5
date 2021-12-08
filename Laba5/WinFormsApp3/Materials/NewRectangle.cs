using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab5.Materials
{
    class NewRectangle : BaseObject
    {

      
        public NewRectangle(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.CadetBlue), -25, -15, 50, 30); // центр смещен в центр объекта
            
        }
    }
}
