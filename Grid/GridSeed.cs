namespace Grid
{
    public class GridSeed : IGridSeed
    {
        private INeighbourCoordinates _neighbourCoordinates;

        private int _livePercent;
        public GridSeed(INeighbourCoordinates neighbourCoordinates, int livePercent)
        {
            _neighbourCoordinates = neighbourCoordinates;
            _livePercent = livePercent;
        }

        public Cell[,] Seed(int rows, int cols)
        {
            var grid = new Cell[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = new Cell(row, col);
                }
            }

            if (_livePercent < 0 || _livePercent > 100)
            {
                return grid;
            }


            var amount = rows * cols * _livePercent / 100;

            Random rng = new();
            for (int i = 0; i < amount; i++)
            {
                var rx = rng.Next(0, cols - 1);
                var ry = rng.Next(0, rows - 1);

                var cell = grid[ry, rx];
                cell.State = CellState.ALIVE;
                cell.Type = GetRandomType();

                var neighbourCoords = _neighbourCoordinates.GetNeighbourCoordinates(ry, rx, rows, cols);

                foreach(var nc in neighbourCoords)
                {
                    var neighbour = grid[nc.Item1, nc.Item2];
                    neighbour.State = CellState.ALIVE;
                    neighbour.Type = GetRandomType();
                }
            }

            return grid;
        }

        private CellType GetRandomType()
        {
            Random rng = new();
            var cellTypes = Enum.GetValues<CellType>().ToList();
            cellTypes.Remove(CellType.UNDEFINED);
            CellType type = cellTypes[rng.Next(cellTypes.Count)];

            return type;
        }
    }
}
