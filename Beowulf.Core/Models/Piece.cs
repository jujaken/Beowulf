namespace Beowulf.Core.Models
{
    public abstract class Piece(PieceContentRule contentRule, Cell? cell = null) : Unit(contentRule, cell)
    {
        public abstract string Name { get; set; }

        private Faction? faction;
        public Faction? Faction
        {
            get => faction;
            set
            {
                if (faction != null)
                    Attributes.Remove(faction);

                if (value != null)
                    Attributes.Add(value);

                faction = value;
            }
        }

        public virtual bool CanMove(Cell cell) => true;
        public virtual bool CanAttack(Piece piece) =>
            piece.IsAlive && CanMove(piece.Cell!);
    }
}
