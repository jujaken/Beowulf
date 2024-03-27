using Beowulf.Core.Math;

namespace Beowulf.Core
{
    public class Corner2DPosRule : ICellPosRule
    {
        public int E { get; } = 2;

        private Vector? lastVector;
        private int step = 1;

        private readonly Trace2D xTrace = new(new(0, 0), new(1, 0));
        private readonly Trace2D yTrace = new(new(0, 0), new(0, 1));

        private bool isX = true;
        private int lastX = 0;
        private int lastY = 0;

        public double[] Next()
        {
            if (lastVector == null)
            {
                lastVector = new Vector(0.5, 0.5);
                return [0, 0];
            }

            var copy = lastVector.Copy();
            copy[1] = -copy[1];
            var trace = new Trace2D(lastVector, copy);

            if (isX)
            {
                isX = false;
                return trace.Shoot(xTrace)!.Coordinates;
            }
            else
            {
                isX = true;
                return trace.Shoot(yTrace)!.Coordinates;
            }
        }
    }
}
