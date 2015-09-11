using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static bool BI(int a)
        {
            if (a != 0) return true;
            else return false;
        }

        static int GCD(int a, int b)
        {
            return BI(b) ? GCD(b, a % b) : a;
        }

        static double NItem(double b1, double q, int n)
        {
            return (n != 1) ? q * NItem(b1, q, n - 1) : b1;
        }

        static double NSum(double b1, double q, int n)
        {
            return (n != 1) ? b1 + NSum(b1*q, q, n - 1) : b1;
        }

        static double NSum()
        {
            return 0;
        }

        static void Main_Prac5_V_2(string[] args)
        {
            double b1, q;
            int n;
            b1 = Double.Parse(Console.ReadLine());
            q = Double.Parse(Console.ReadLine());
            n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("N-item: {0}", NItem(b1, q, n));
            Console.WriteLine("N-sum: {0}", NSum(b1, q, n));
        }

        static void Main_Prac5_II_17(string[] args)
        {
            int a, b;
            a = Int32.Parse(Console.ReadLine());
            b = Int32.Parse(Console.ReadLine());
            int NOD = GCD(a, b);

            if (b / NOD != 1)
                Console.WriteLine("{0}/{1}", a / NOD, b / NOD);
            else
                Console.WriteLine("{0}", a / NOD);
        }

        static void Main_Prac4_VI_19(string[] args)
        {
            int a, b;
            a = Int32.Parse(Console.ReadLine());
            b = Int32.Parse(Console.ReadLine());

            int deva = Math.Min(a, 2), devb = Math.Min(b, 2);
            for (int i = 2; i * i <= a; i++)
            {
                if (a % i == 0) deva += 2;
            }
            for (int i = 2; i * i <= b; i++)
            {
                if (b % i == 0) devb += 2;
            }
            if (deva > devb)
                Console.WriteLine("First {0}", deva);
            else if (deva < devb)
                Console.WriteLine("Second {0}", devb);
            else
                Console.WriteLine("Equal {0} {1}", deva, devb);
        }

        static void Main_Prac4_VII_4(string[] args)
        {
            int a, b, c;
            a = Int32.Parse(Console.ReadLine());
            b = Int32.Parse(Console.ReadLine());
            c = Int32.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                int devsum = 1 + i;
                for (int j = 2; j * j <= i; j++)
                {
                    if (i % j == 0) devsum += j + i / j;
                    if (i / j == j) devsum -= j;
                }
                if (devsum % c == 0)
                    Console.Write("{0} ({1}) ", i, devsum);
            }
        }
    }
}
