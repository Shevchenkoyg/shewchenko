using System;

namespace Lab01
{
    class Program
    {
        delegate double F2Delegate(double x1, double x2);

        delegate double F1Delegate(double x1, double x2, out double res);

        private static double Func(double xMax, double xMin, out double res)
        {
            double x1,x2;
            x1 = Math.Cos(Math.Sqrt(xMin) + 34 * Math.Sin(xMax));
            x2 = 4 * Math.Sin(xMin);
            res = Math.Pow(x1, 3) * Math.Pow(x2, 3);

            return x1 - x2;
        }

        private static double Acc(double r, double x)
        {
            return r + x;
        }

        private static void EnterData(out double xMin, out double xMax, out double dx)
        {
            Console.Write("Enter xMin:");
            xMin = double.Parse(Console.ReadLine().Replace('.', ','));

            Console.Write("Enter xMax:");
            xMax = double.Parse(Console.ReadLine().Replace('.', ','));

            Console.Write("Enter dx:");
            dx = double.Parse(Console.ReadLine().Replace('.', ','));
        }

        private static void Tabulate(double xMin, double xMax, double dx, double init, F1Delegate func, F2Delegate acc)
        {
            double x = xMin;
            Console.WriteLine("Tabulate function");
            double countRes = 1;
            while (x <= xMax)
            {
                double x1 = x;
                double x2 = 3 * x;
                double y = func(xMax, xMin, out double res);
                Console.WriteLine("x={0}\t\ty={1}", x, y);
                if (x > xMin && x < xMax)
                {
                    init = acc(init, y);
                }
                x += dx;
                countRes *= res;
            }
            Console.WriteLine("*****************");
            if (acc != null)
            {
                Console.WriteLine("Middle results");
                Console.WriteLine(init);
                Console.WriteLine("================");

            }
            Console.WriteLine("The intermediate result is:" + countRes);
        }
        static void Main(string[] args)
        {
            EnterData(out double x1, out double x2, out double dx);
            Tabulate(x1, x2, dx, 0, Func, Acc);
            Console.ReadKey();
        }
    }
}

