using System;
using System.Collections.Generic;

namespace test_taks_itech
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int m = 5;
            Console.Write("Количество точек: ");
            int countPoints = Convert.ToInt32(Console.ReadLine());

            List<Point> points = new List<Point>();

            for (int i= 0;i<countPoints;i++)
            {
                Console.WriteLine(i + 1 + " - точка");
                Point point = new Point();

                Console.Write("Введите x:");
                point.X = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите y:");
                point.Y = Convert.ToInt32(Console.ReadLine());

                points.Add(point);
            }

            points = sort(points);

            Point currentPoint = new Point(0, 0);

            string str = "";
            for (int i = 0; i < points.Count; i++)
            {
                if (currentPoint.X > points[i].X)
                {
                    str += addSymbol('W', currentPoint.X - points[i].X);
                }
                if (currentPoint.X < points[i].X)
                {
                    str += addSymbol('E', points[i].X - currentPoint.X);
                }

                if (currentPoint.Y > points[i].Y)
                {
                    str += addSymbol('S', currentPoint.Y - points[i].Y);
                }
                if (currentPoint.Y < points[i].Y)
                {
                    str += addSymbol('N', points[i].Y - currentPoint.Y);
                }

                str += addSymbol('D', 1);
                currentPoint = points[i];
            }

            Console.WriteLine();
            Console.WriteLine(str);
            Console.WriteLine();

            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine(points[i].X + " " + points[i].Y);
            }
        }
        static string addSymbol(char symbol, int count)
        {
            string str = "";
            for(int i = 0; i < count; i++)
            {
                str += symbol;
            }
            return str;
        }
        static List<Point> sort(List<Point> points)
        {
            for(int i=0; i<points.Count-1;i++)
            {
                for(int j=i+1;j<points.Count; j++)
                {
                    if((points[i].X + points[i].Y) >= (points[j].X + points[j].Y))
                    {
                        Point p = points[i];
                        points[i] = points[j];
                        points[j] = p;
                    }
                }
            }

            return points;
        }
    }
}
