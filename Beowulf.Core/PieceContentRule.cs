using Beowulf.Core.Exceptions;
using Beowulf.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Beowulf.Core
{
    public abstract class PieceContentRule(IServiceProvider services) : ICellContentRule
    {
        private readonly IServiceProvider services = services;

        public abstract int E { get; protected set; }
        public abstract int? MaxPieceNum { get; protected set; }
        public abstract List<Type> PieceTypes { get; protected set; }
        public abstract List<Type> FactionTypes { get; protected set; }

        public double[] Get(List<CellContent> vector)
        {
            throw new NotImplementedException();
        }

        public List<CellContent> Get(double[] vector)
        {
            var skiped = vector[0..E] ?? throw new ContentRuleException();

            if (MaxPieceNum == null)
                return skiped.Select(c => MakePiece(c)).ToList();

            return skiped[0..((int)MaxPieceNum + 1)].Select(c => MakePiece(c)).ToList();
        }

        protected CellContent MakePiece(double fullcode)
        {
            (var code, var subcode) = GetCode(fullcode);

            var piece = (Piece)services.GetRequiredService(PieceTypes[code]);
            piece.Faction = (Faction)services.GetRequiredService(FactionTypes[subcode]);

            return piece;
        }

        public static (int code, int subcode) GetCode(double fullcode)
        {
            var strs = fullcode.ToString("G", CultureInfo.InvariantCulture).Split('.');
            return ((int)fullcode, strs.Length > 1 ? Convert.ToInt32(strs[1]) : 0);
        }

        public static double GetCode(int code, int subcode)
            => code + subcode * Math.Pow(0.1, subcode.ToString().Length);
    }
}
