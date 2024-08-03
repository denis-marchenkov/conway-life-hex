namespace Grid
{
    public class Cell(int y, int x)
    {
        public int Y { get; set; } = y;
        public int X { get; set; } = x;
        public CellType Type { get; set; } = CellType.UNDEFINED;
        public CellState State { get; set; } = CellState.DEAD;
        public List<Cell> Neighbours { get; set; } = [];

        public bool IsAlive => State == CellState.ALIVE;


        #region rules
        // Any live cell with less than two live neighbours of its type dies of underpopulation.
        public bool IsUnderpopulated()
        {
            return IsAlive && Neighbours.Count(x => x.Type == Type) < 2;
        }


        // Any live cell with more than three live neighbours of any type dies of overpopulation.
        public bool IsOverpopulated()
        {
            return IsAlive && Neighbours.Count > 3;
        }


        // Any live cell with two or three neighbours of the same type survives to the next generation
        public bool IsSurvivor()
        {
            var neighbours = Neighbours.Where(x => x.Type == Type).ToList();

            return IsAlive && neighbours.Count is 2 or 3;
        }


        // Any dead cell with two live neighbours of the same type becomes live cell.
        // If there are other pairs (or more) cells with different types around it - it stays dead.
        public Cell Reproduce()
        {
            if(State == CellState.ALIVE) return this;

            var grp = Neighbours.GroupBy(x => x.Type).Where(x => x.Key != CellType.UNDEFINED)
                .Select(x => new
                {
                    Type = x.Key,
                    Count = x.Count()
                });

            if (!grp.Any(x => x.Count == 2) || grp.Any(x => x.Count > 2)) return this;

            return new Cell(Y, X) { State = CellState.ALIVE, Type = grp.First().Type, Neighbours = Neighbours };
        }
        #endregion rules

        public static CellType GetRandomType()
        {
            Random rng = new();
            var cellTypes = Enum.GetValues<CellType>().ToList();
            cellTypes.Remove(CellType.UNDEFINED);
            CellType type = cellTypes[rng.Next(cellTypes.Count)];

            return type;
        }

    }
}
