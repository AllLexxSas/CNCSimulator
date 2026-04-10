using System;
using System.Collections.Generic;
using System.Drawing;
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
        private PointF center;

        public Circle(Point _start, Point _end, Int16 _direct, double _radius)
        {
            Start = _start;
            End = _end;
            directRotation = _direct;
            radius = _radius;
            var c = GetCenter();
            center = new PointF((float)c.x, (float)c.y);

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

        public override void Draw(System.Drawing.Graphics g)
        {
            if (center == PointF.Empty) return;
            float startAngle = (float)(Math.Atan2(Start.y - center.Y, Start.x - center.X) * 180 / Math.PI);
            float endAngle = (float)(Math.Atan2(End.y - center.Y, End.x - center.X) * 180 / Math.PI);
            float sweepAngle = endAngle - startAngle;

            if (directRotation == 2) // По часовой (G02)
            {
                if (sweepAngle < 0) sweepAngle += 360;
            }
            else // Против часовой (G03)
            {
                if (sweepAngle > 0) sweepAngle -= 360;
            }
            float rectX = (float)(center.X - radius);
            float rectY = (float)(center.Y - radius);
            float rectSize = (float)(radius * 2);
            RectangleF rect = new RectangleF(rectX, rectY, rectSize, rectSize);
            Pen pen = new Pen(Color.Red, 2.0f);
            g.DrawArc(pen, rect, startAngle, sweepAngle);
        }
    }
}
