namespace Grid
{
    // Populate initial grid with a random percent of live cells
    public class GridSeed : IGridSeed
    {
        private ICellCoordinates _cellCoordinates;

        private int _livePercent;
        public GridSeed(ICellCoordinates cellCoordinates, int livePercent)
        {
            _cellCoordinates = cellCoordinates;
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

            HashSet<string> seededCells = [];

            Random rng = new();
            for (int i = 0; i < amount; i++)
            {
                var rx = rng.Next(0, cols - 1);
                var ry = rng.Next(0, rows - 1);

                if (seededCells.Contains(_cellCoordinates.ToString(ry, rx)))
                {
                    continue;
                }

                seededCells.Add($"{ry}_{rx}");

                var cell = grid[ry, rx];
                cell.State = CellState.ALIVE;
                cell.Type = Cell.GetRandomType();

                var neighbourCoords = _cellCoordinates.GetNeighbourCoordinates(ry, rx);

                foreach (var nc in neighbourCoords.Take(rng.Next(neighbourCoords.Count)))
                {
                    var ny = nc.Item1;
                    var nx = nc.Item2;

                    seededCells.Add(_cellCoordinates.ToString(ny, nx));
                    if (_cellCoordinates.IsOutOfBounds(ny, nx, rows, cols))
                    {
                        continue;
                    }

                    var neighbour = grid[ny, nx];
                    neighbour.State = CellState.ALIVE;
                    neighbour.Type = Cell.GetRandomType();
                }
            }
            return grid;
        }
    }
}

