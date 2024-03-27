using Beowulf.Core.Exceptions;
using Beowulf.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Beowulf.Core
{
    /// <summary>
    /// целая - тип фигуры, дробная - фракция
    /// </summary>
    public class PieceContentRule(IServiceProvider services, List<Type> pieceTypes, List<Type> factionTypes) : CellContentRule
    {
        protected IServiceProvider Services { get; } = services;
        protected List<Type> PieceTypes { get; } = pieceTypes;
        protected List<Type> FactionTypes { get; } = factionTypes;

        public override List<CellContent> Get(double[] subvector)
            => subvector.Select(coordinate =>
            {
                (var code, var subcode) = GetCode(coordinate);
                var piece = (Piece)Services.GetRequiredService(PieceTypes[code]);
                if (subcode != null)
                    piece.Faction = (Faction)Services.GetRequiredService(FactionTypes[(int)subcode]);

                return (CellContent)piece;
            }).ToList();

        public override double[] Get(List<CellContent> subcontents)
            => subcontents.Select(content =>
            {
                var piece = (Piece)content;

                var pieceId = PieceTypes.FindIndex(p => p == piece.GetType());
                if (pieceId == -1)
                    throw new ContentRuleException();

                var faction = piece.Faction;
                if (faction == null)
                    return GetCode(pieceId, null);

                var factionId = FactionTypes.FindIndex(f => f == faction.GetType());
                if (factionId == -1)
                    throw new ContentRuleException();

                return GetCode(pieceId, factionId);
            }).ToArray();
    }
}
