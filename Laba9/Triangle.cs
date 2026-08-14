using System;

namespace Laba9
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;
        private static int count = 0;

        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public double C
        {
            get { return c; }
            set { c = value; }
        }
        public static int Count
        {
            get { return count; }
        }

        public Triangle(double a, double b, double c)
        {
            this.a = a; 
            this.b = b;
            this.c = c;
            count++;
        }
        public Triangle() 
        {
            a = 0;
            b = 0;
            c = 0;
            count++;
        }

        public Triangle(Triangle tr)
        {
            A = tr.A;
            B = tr.B;
            C = tr.C;
            count++;
        }

        public bool Exist()
        {
            if (count == 0) return false;
            if (a + b > c && b + c > a && a + c > b) { return true; }
            else 
            {
                return false;
            }
        }

        public double CalculateSquare()
        {
            if (Exist())
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else
            {
                Console.WriteLine("Треугольника с заданными сторонами не существует");
                return -1;
            }
        }

        public static Triangle operator ++(Triangle tr)
        {
            tr.A++;
            tr.B++;
            tr.C++;
            return tr;
        }

        public static Triangle operator --(Triangle tr)
        {
            tr.A--;
            tr.B--;
            tr.C--;
            return tr;
        }

        public static explicit operator double(Triangle tr)
        {
            return tr.CalculateSquare();
        }

        public static implicit operator bool(Triangle tr)
        {
            return tr.Exist();
        }

        public static bool operator <=(Triangle tr1, Triangle tr2)
        {
            return (tr1.CalculateSquare() <= tr2.CalculateSquare());
        }

        public static bool operator >=(Triangle tr1, Triangle tr2)
        {
            return (tr1.CalculateSquare() >= tr2.CalculateSquare());
        }
    }
}
