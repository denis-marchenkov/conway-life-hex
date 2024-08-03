namespace Grid
{
    public class CellGrid
    {
        public int Rows { get; set; }
        public int Cols { get; set; }

        public Cell[,] Grid;
        public Cell[,] _nextGen;

        private IGridSeed _seed;
        private ICellCoordinates _cellCoordinates;
        public CellGrid(int rows, int cols, IGridSeed seed, ICellCoordinates cellCoordinates)
        {
            Rows = rows;
            Cols = cols;

            _seed = seed;
            _cellCoordinates = cellCoordinates;

            if (_seed != null)
            {
                Grid = _seed.Seed(rows, cols);
            }
            else
            {
                Grid = FreshGrid(rows, cols);
            }
        }

        public void UpdateGrid()
        {
            _nextGen = FreshGrid(Rows, Cols);

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    var cell = Grid[row, col];

                    MutateCell(cell);
                }
            }

            Grid = _nextGen;

        }

        private void MutateCell(Cell cell)
        {
            cell.Neighbours = [];

            if(_cellCoordinates == null)
            {
                return;
            }

            _nextGen[cell.Y, cell.X].Type = cell.Type;

            foreach (var c in _cellCoordinates.GetNeighbourCoordinates(cell.Y, cell.X))
            {
                var ny = c.Item1;
                var nx = c.Item2;

                if (_cellCoordinates.IsOutOfBounds(ny, nx, Rows, Cols))
                {
                    cell.State = CellState.DEAD;
                  
                    continue;
                }

                var neighbour = Grid[ny, nx];

                if (neighbour.State == CellState.DEAD) continue;

                cell.Neighbours.Add(neighbour);
            }

            if(cell.IsOverpopulated() || cell.IsUnderpopulated())
            {
                cell.State = CellState.DEAD;
                _nextGen[cell.Y, cell.X].State = CellState.DEAD;
                return;
            }

            if (cell.IsSurvivor())
            {
                _nextGen[cell.Y, cell.X].State = CellState.ALIVE;
               return;
            }


            var newCell = cell.Reproduce();

            _nextGen[cell.Y, cell.X] = newCell;
        }

        private Cell[,] FreshGrid(int rows, int cols)
        {
            var grid = new Cell[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = new Cell(row, col);
                }
            }

            return grid;
        }
    }
}
