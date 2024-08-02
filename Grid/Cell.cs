namespace Grid
{
    public class Cell(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public CellType Type { get; set; } = CellType.UNDEFINED;
        public CellState State { get; set; } = CellState.DEAD;
        public List<Cell> Neighbours { get; set; } = [];

        public bool IsAlive => State == CellState.ALIVE;


        // Any live cell with less than two live neighbours dies of underpopulation.
        public bool IsUnderpopulated()
        {
            return IsAlive && Neighbours.Count < 2;
        }


        // Any live cell with more than three live neighbours dies of overpopulation.
        public bool IsOverpopulated()
        {
            return IsAlive && Neighbours.Count > 3;
        }


        // Any live cell with two or three neighbours of the same type survives to the next generation
        public bool IsSurvivor()
        {
            var neighbours = Neighbours.Where(x => x.Type == Type).ToList();

            return IsAlive && neighbours.Count is not 0 and (2 or 3);
        }


        // Any dead cell with three live neighbours of the same type becomes live cell.
        // If it's a tie between two groups of three cells of two different types - it stays dead.
        public void Reproduce()
        {
            if(State == CellState.ALIVE) return;

            var grp = Neighbours.GroupBy(x => x.Type).Where(x => x.Key != CellType.UNDEFINED)
                .Select(x => new
                {
                    Type = x.Key,
                    Count = x.Count()
                })
                .Where(x => x.Count == 3);

            if (!grp.Any() || grp.Count() == 2) return;

            State = CellState.ALIVE;

            Type = grp.First().Type;

        }

    }
}
