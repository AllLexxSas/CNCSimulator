using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCSimulator.Geomerty
{
    class Point
    {
        public double x, y, z;
        public Point(double _x, double _y)
        {
            x = _x; y = _y; z = 0;
        }
    }
}
