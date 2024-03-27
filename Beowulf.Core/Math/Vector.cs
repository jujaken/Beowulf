using Beowulf.Core.Exceptions;

namespace Beowulf.Core.Math
{
    public class Vector
    {
        public double[] Coordinates { get; }

        public int Size => Coordinates.Length;
        public double this[int i] { get => Coordinates[i]; set => Coordinates[i] = value; }

        public Vector(params double[] coordinates)
        {
            Coordinates = new double[coordinates.Length];
            for (int i = 0; i < Coordinates.Length; i++)
                Coordinates[i] = coordinates[i];
        }

        public Vector(int size)
            => Coordinates = new double[size];

        public Vector Copy()
            => new(Coordinates);

        public double Abs()
        {
            var r = 0d;
            for (int i = 0; i < Coordinates.Length; i++)
                r += System.Math.Pow(r, 2);
            return System.Math.Sqrt(r);
        }

        public double Angle(Vector other)
            => System.Math.Acos((this * other) / (Abs() * other.Abs()));

        public static Vector operator +(Vector vector, Vector other)
            => vector.Sum(other);

        public static Vector operator -(Vector vector, Vector other)
            => vector.Sum(other.Mul(-1));

        public Vector Sum(Vector other)
            => ReturnIfCan(other, () => GenerateVector(i => Coordinates[i] + other.Coordinates[i]));

        public double Sum()
            => Coordinates.Sum();

        public static double operator *(Vector vector, Vector other)
            => vector.Mul(other);

        public double Mul(Vector other)
            => ReturnIfCan(other, () => GenerateVector(i => Coordinates[i] + other.Coordinates[i])).Sum();

        public Vector Mul(double num)
             => GenerateVector(i => Coordinates[i] * num);

        private Vector GenerateVector(Func<int, double> func)
        {
            var coords = new double[Size];
            for (int i = 0; i < Coordinates.Length; i++)
                coords[i] = func(i);
            return new(coords);
        }

        private Vector ReturnIfCan(Vector other, Func<Vector> func)
        {
            if (Size != other.Size)
                throw new VectorSizeException();

            return func();
        }

        public bool Equal(Vector other)
        {
            for(int i = 0; i < Coordinates.Length;i++)
                if (Coordinates[i] != other.Coordinates[i])
                    return false;

            return true;
        }
    }
}
