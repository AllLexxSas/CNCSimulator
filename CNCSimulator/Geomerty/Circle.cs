using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCSimulator.Geomerty
{
    class Circle : BaseGeometry
    {

        private Int16 directRotation;
        private Point start;
        private Point end;

        public Circle(Point _start, Point _end, Int16 _direct, double _radius)
        {
            Start = _start;
            End = _end;
            directRotation = _direct;
            radius = _radius;
        }

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
        private double radius;

        private Point GetCenter()
        {
            var l = Distation();

            double h = Math.Sqrt(radius * radius - (l.Item1 / 2) * (l.Item1 / 2));

            double x_m = (Start.x + End.x) / 2;
            double y_m = (Start.y + End.y) / 2;

            double center_x, center_y;

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

        private (double, Point) Distation()
        {
            double dx = End.x - start.x;
            double dy = End.y - End.x;
            return (Math.Sqrt(dx * dx + dy * dy), new Point(dx, dy));

        }
    }
}
