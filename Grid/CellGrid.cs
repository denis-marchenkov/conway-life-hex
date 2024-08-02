namespace Grid
{
    public class CellGrid
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Cell[,] Grid;

        public CellGrid(int height, int width)
        {
            Height = height;
            Width = width;

            Grid = new Cell[Height, Width];

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++) 
                {
                    Grid[row, col] = new Cell(row, col);
                }
            }
        }

        public static List<(int, int)> GetNeighboursCoords(int y, int x)
        {
            return [
                (y, x + 1),
                (y, x + 2),
                (y - 1, x),

                (y + 1, x - 1),
                (y + 1, x),
                (y + 1, x + 2)
            ];
        }

        public void UpdateGrid()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    var cell = Grid[row, col];

                    MutateCell(cell);
                }
            }
        }

        private void MutateCell(Cell cell)
        {
            cell.Neighbours = [];

            foreach (var c in GetNeighboursCoords(cell.Y, cell.X))
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
