using Beowulf.Core.Exceptions;

namespace Beowulf.Core.Math
{
    public class Trace2D(Vector start, Vector end, double? dist = null)
    {
        public Vector Start { get; } = start;
        public Vector End { get; } = end;
        public double? Distance { get; } = dist;

        public Vector? Shoot(Trace2D other, bool twoSided = false)
        {
            if (Start.Size != End.Size)
                throw new VectorSizeException();

            if (ToVector() == other.ToVector())
                throw new DisjointVectorsException();

            var x = (other.GetB() - GetB()) / (GetA() - other.GetA());
            var y = GetY(x);

            return new Vector(x, y);
        }

        public double GetA()
        {
            var y1 = Start[0];
            var x1 = Start[1];

            var y2 = End[0];
            var x2 = End[1];

            return (x2 - x1) / (y2 - y1);
        }

        public double GetB()
            => Start[0];

        public double GetY(double x)
        {
            var y1 = Start[0];
            var x1 = Start[1];

            var y2 = End[0];
            var x2 = End[1];

            return (x2 - x1) / (y2 - y1) * x + y1;
        }

        public Vector ToVector()
            => Start - End;
    }
}
