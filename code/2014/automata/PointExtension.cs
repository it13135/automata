using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public static class PointExtension
    {
        public static float Angle(this Point p1, Point p2)
        {
            float rotationAngle = 0;
            if (p2.Y == p1.Y)
            {
                if (p2.X <= p1.X)
                {
                    rotationAngle = 180;
                }
                else
                    rotationAngle = 0;
            }
            else
            {
                if (p2.X == p1.X)
                {
                    if (p2.Y <= p1.Y)
                    {
                        rotationAngle = -90;
                    }
                    else
                        rotationAngle = 90;
                }
                else
                {
                    double distance = p1.DistanceTo(p2);
                    rotationAngle = (Single)(Math.Acos(Math.Abs(p2.X - p1.X) / distance) * 180 / Math.PI);
                    if (p2.X > p1.X)
                    {
                        if (p2.Y < p1.Y)
                            rotationAngle = -rotationAngle;
                    }
                    else
                    {
                        if (p2.Y > p1.Y)
                            rotationAngle = 180 - rotationAngle;
                        if (p2.Y < p1.Y)
                            rotationAngle = 180 + rotationAngle;
                    }
                }
            }

            return rotationAngle;
        }
        public static double DistanceTo(this Point point1, Point point2)
        {
            var a = (double)(point2.X - point1.X);
            var b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(a * a + b * b);
        }

        public static void DrawCircle(this Graphics _graphics, Pen _pen, Point _center, float _radious)
        {
            _graphics.DrawEllipse(_pen, _center.X - _radious, _center.Y - _radious, 2 * _radious, 2 * _radious);
        }

        public static Point getPoint(this Graphics _graphics)
        {
            Point[] origin = { new Point(0, 0) };
            _graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page, System.Drawing.Drawing2D.CoordinateSpace.World, origin);
            return origin[0];
        }
    }
}
