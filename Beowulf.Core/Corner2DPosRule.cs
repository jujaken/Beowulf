using Beowulf.Core.Math;

namespace Beowulf.Core
{
    public class Corner2DPosRule : ICellPosRule
    {
        public int E => 2;

        private bool isX = true;

        private readonly Vector vector = new(0, 0);
        private int level = 0;

        public double[] Next()
        {
            if (vector[0] == level)
            {
                if (vector[1] == level)
                {
                    level++;
                    vector[1] = 0;
                }
                else
                {
                    vector[1] = level;
                    return vector.Coordinates;
                }
            }

            if (isX)
            {
                vector[0]++;
                isX = false;
            }
            else
            {
                (vector[0], vector[1]) = (vector[1], vector[0]);
                isX = true;
            }

            return vector.Coordinates;
        }
    }
}
