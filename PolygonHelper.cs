using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dIplom3
{
    internal class PolygonHelper
    {
        public static bool IsPointInRoom(List<Point> polygonPoints, Point testPoint)
        {
            return IsPointInPolygon(polygonPoints, testPoint) || IsPointOnBorder(polygonPoints, testPoint);
        }

        private static bool IsPointInPolygon(List<Point> polygonPoints, Point point)
        {
            bool result = false;
            int j = polygonPoints.Count - 1;
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                if (polygonPoints[i].Y < point.Y && polygonPoints[j].Y >= point.Y ||
                    polygonPoints[j].Y < point.Y && polygonPoints[i].Y >= point.Y)
                {
                    if (polygonPoints[i].X + (point.Y - polygonPoints[i].Y) /
                        (polygonPoints[j].Y - polygonPoints[i].Y) *
                        (polygonPoints[j].X - polygonPoints[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        private static bool IsPointOnBorder(List<Point> polygonPoints, Point point)
        {
            for (int i = 0; i < polygonPoints.Count - 1; i++)
            {
                if (IsPointOnLineSegment(polygonPoints[i], polygonPoints[i + 1], point))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsPointOnLineSegment(Point p1, Point p2, Point p)
        {
            // Check if the point p is on the line segment p1p2
            double crossProduct = (p.Y - p1.Y) * (p2.X - p1.X) - (p.X - p1.X) * (p2.Y - p1.Y);
            if (Math.Abs(crossProduct) > 1e-6) // Tolerance for floating point comparison
            {
                return false;
            }

            double dotProduct = (p.X - p1.X) * (p2.X - p1.X) + (p.Y - p1.Y) * (p2.Y - p1.Y);
            if (dotProduct < 0)
            {
                return false;
            }

            double squaredLengthP1P2 = (p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y);
            if (dotProduct > squaredLengthP1P2)
            {
                return false;
            }

            return true;
        }
    }
}
