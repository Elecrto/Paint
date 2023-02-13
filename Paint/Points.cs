using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    internal class Points
    {
        private int count = 0;
        public int Count => count;
        private Point[] points;
        
        public Points(int size)
        {
            points = new Point[size];
        }
        public void Add(int x, int y)
        {
            if(count >= points.Length)
            {
                count = 0;
            }
            points[count] = new Point(x, y);
            count++;
        }
        public void Reset()
        {
            count = 0;
        }
        public Point[] GetPoints()
        {
            return points;
        }
    }
}
