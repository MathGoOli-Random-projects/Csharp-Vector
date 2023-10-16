using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v0 = new Vector(1, 2, 3);
            Vector v1 = new Vector(3, 4, 0);

            Vector zero = new Vector();
            Vector newVector = v1;
            Console.WriteLine(v1);

            Console.WriteLine(zero);
            Console.WriteLine("v0 lenght: " + v0.Length);
            Console.WriteLine("v1 lenght: " + v1.Length);
            Console.WriteLine("zero lenght: " + zero.Length);

            //// reverse v1
            //
            //Console.WriteLine("reverse v1 " + v1.Reverse);
            //
            //// scale
            //v1.Scale(2);
            //Console.WriteLine("v1 scaled: " + v1.Length);
            //
            //// unitize
            //v1.Unitize();
            //Console.WriteLine(v1);
            //Console.WriteLine("v1 lenght: " + v1.Length);
            //
            //// add
            //zero.Add(v0);
            //zero.Add(v1);
            //Console.WriteLine("zero : " + zero);
            //Console.WriteLine("zero lenght: " + zero.Length);
            //
            //// addition
            //Vector v2 = Vector.Addition(v0, v1);
            //Console.WriteLine(v2);

            //double dot = Vector.DotProduct(v0, v1);
            //Console.WriteLine("DotProduct " + dot);
            //
            Vector vx = Vector.XAxis;
            Vector vy = Vector.YAxis;
            
            Vector vz = Vector.CrossProduct(vx, vy);
            
            Console.WriteLine($"vx {vx}, vy {vy}, vz {vz}");
            
            Console.ReadKey();
        }
    }

    /// <summary>
    ///  Represents a three dimentional vector
    /// </summary>
    public class Vector
    {
        // properties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Length 
        {
            get
            {
                return GetLenght();
            }
        }
        public Vector Reverse
        {   
            get
            {
                return new Vector(-X, -Y, -Z);
            }

        }

        public static Vector XAxis
        {
            get => new Vector(1, 0, 0);
        }
        public static Vector YAxis
        {
            get => new Vector(0, 1, 0);
        }
        public static Vector ZAxis
        {
            get => new Vector(0, 0, 1);
        }
        // Indexer
        public double this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return X;
                }
                else if (i == 1)
                {
                    return Y;
                }
                else if (i == 2)
                {
                    return Z;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (i == 0)
                {
                    X = value;
                }
                else if (i == 1)
                {
                    Y = value;
                }
                else if (i == 2)
                {
                    Z = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                
            }
        }
        //constructors
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

        }

        public Vector(Vector other)
        {
            this.X = other.X;
            this.Y = other.Y;
            this.Z = other.Z;
        }

        // methods
        private double GetLenght()
        {
            double square_lenght = X * X + Y * Y + Z * Z;
            double lenght = Math.Sqrt(square_lenght);

            return lenght;
        }



        public void Scale(double factor)
        {
            X *= factor;
            Y *= factor;
            Z *= factor;
        }

        // overrides
        public override string ToString() 
        {
            return $"Vector [{X}, {Y}, {Z}]";
        }

        public bool Unitize()
        {
            double len = GetLenght();
            if (len <= 0) 
            {
                return false;
            }
            X /= len;
            Y /= len;
            Z /= len;
            return true;
        }

        public void Add(Vector other)
        {
            this.X += other.X;
            this.Y += other.Y;
            this.Z += other.Z;
        }

        // Operator overloads
        public static Vector operator + (Vector a, Vector b)
        {
            return Vector.Addition(a, b);
        }

        public static double operator * (Vector a, Vector b)
        {
            return Vector.DotProduct(a, b);
        }

        public static Vector operator * (double a, Vector b)
        {
            Vector v = new Vector(b);
            v.Scale(a);
            return v;
        }

        // static methods
        public static Vector Addition(Vector a, Vector b)
        {
            double newX = a.X + b.X;
            double newY = a.Y + b.Y;
            double newZ = a.Z + b.Z;

            return new Vector(newX, newY, newZ);
        }

        public static double DotProduct(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector CrossProduct(Vector a, Vector b)
        {
            double x = a.Y * b.Z - a.Z * b.Y;
            double y = a.Z * b.X - a.X * b.Z;
            double z = a.X * b.Y - a.Y * b.X;

            return new Vector(x, y, z);
        }

    }
}
