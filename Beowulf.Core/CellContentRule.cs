using Beowulf.Core.Models;
using System.Globalization;

namespace Beowulf.Core
{
    public abstract class CellContentRule : ICellContentRule
    {
        public abstract List<CellContent> Get(double[] subvector);
        public abstract double[] Get(List<CellContent> subcontents);


        /// <summary> разделяет число с точкой на два целых числа: целая часть, дробная </summary>
        protected static (int code, int? subcode) GetCode(double fullcode)
        {
            var strs = fullcode.ToString("G", CultureInfo.InvariantCulture).Split('.');
            return ((int)fullcode, (strs.Length > 1 ? Convert.ToInt32(strs[1]) - 1 : null));
        }

        /// <summary> собирает дробное число </summary>
        protected static double GetCode(int code, int? subcode)
            => code + (double)(subcode != null ? subcode * Math.Pow(0.1, subcode!.ToString()!.Length) : 0);
    }
}
