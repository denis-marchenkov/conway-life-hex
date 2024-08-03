namespace Grid
{
    // Brilliant article covering hex grids coordinate system
    // https://www.redblobgames.com/grids/hexagons/#neighbors-offset
    public class CellCoordinates : ICellCoordinates
    {
        public List<(int, int)> GetNeighbourCoordinates(int y, int x)
        {
            List<List<(int, int)>> neighbours = [
                // even cols
                [(y, x + 1), (y - 1, x + 1), (y - 1, x),
                 (y - 1,x - 1), (y, x - 1), (y + 1, x)],

                // odd cols
                [(y + 1, x + 1), (y, x + 1), (y - 1, x),
                 (y, x - 1), (y + 1, x - 1), (y + 1, x)],
            ];

            return neighbours[x % 2];
        }

        public bool IsOutOfBounds(int y, int x, int rows, int cols)
        {
            if (y < 0       ||
                x < 0       ||
                x >= cols   ||
                y >= rows
                )
                return true;

            return false;
        }

        public string ToString(int y, int x)
        {
            return $"{y}_{x}";
        }
    }
}
