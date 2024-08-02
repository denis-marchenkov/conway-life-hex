namespace Grid
{
    public class CellGrid
    {
        public int Rows { get; set; }
        public int Cols { get; set; }

        public Cell[,] Grid;

        private IGridSeed _seed;
        private INeighbourCoordinates _neighbourCoordinates;
        public CellGrid(int rows, int cols, IGridSeed seed, INeighbourCoordinates neighbourCoordinates)
        {
            Rows = rows;
            Cols = cols;

            _seed = seed;
            _neighbourCoordinates = neighbourCoordinates;

            if (_seed != null)
            {
                Grid = _seed.Seed(rows, cols);
            }
            else
            {
                Grid = new Cell[Rows, Cols];
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Cols; col++)
                    {
                        Grid[row, col] = new Cell(row, col);
                    }
                }
            }
        }

        public void UpdateGrid()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    var cell = Grid[row, col];

                    MutateCell(cell);
                }
            }
        }

        private void MutateCell(Cell cell)
        {
            cell.Neighbours = [];

            if(_neighbourCoordinates == null)
            {
                return;
            }

            foreach (var c in _neighbourCoordinates.GetNeighbourCoordinates(cell.Y, cell.X, Rows, Cols))
            {
                var ny = c.Item1;
                var nx = c.Item2;

                if (nx < 0 || ny < 0) continue;

                var neighbour = Grid[ny, nx];

                if (neighbour.State == CellState.DEAD) continue;

                cell.Neighbours.Add(neighbour);
            }

            if(cell.IsAlive && (cell.IsOverpopulated() || cell.IsUnderpopulated()))
            {
                cell.State = CellState.DEAD;
                return;
            }

            if (cell.IsSurvivor())
            {
                return;
            }

            cell.Reproduce();
        }
    }
}
