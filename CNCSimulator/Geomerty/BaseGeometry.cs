using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCSimulator.Geomerty
{
    class BaseGeometry
    {
        internal double x, y, z;
    }
    class Point
    {
        public float x, y, z;
        public Point(float _x, float _y)
        {
            x = _x; y = _y; z = 0;
        }
    }


    class Circle :BaseGeometry
    {

        private Int16 directRotation;
        private Point start;
        private Point end;

        private Point Start
        {
            get => start;
            set => start = value;
        }

        private Point End
        {
            get => end;
            set => end = value;
        }
        private float radius;
            
       private Point   GetRadius()
        {
            var l = Distation();

            float h = (float)Math.Sqrt(radius * radius - (l.Item1 / 2) * (l.Item1 / 2));

            float x_m = (Start.x + Start.x) / 2;
            float y_m = (Start.y + Start.y) / 2;

            float center_x, center_y;

            if (directRotation == 3) // Против часовой (Counter-clockwise)
            {
                center_x = x_m - h * l.Item2.y / l.Item1;
                center_y = y_m + h * l.Item2.x / l.Item1;
            }
            else // По часовой (Clockwise)
            {
                center_x = x_m + h * l.Item2.y / l.Item1;
                center_y = y_m - h * l.Item2.x / l.Item1;
            }

            return new Point(center_x, center_y);

        }

        private (float,Point) Distation ()
        {
            float dx = End.x - start.x;
            float dy = End.y - End.y;
            return((float)Math.Sqrt(dx * dx + dy * dy) , new Point(dx,dy));
            
        }
    }


    
    

}
