namespace Grid
{
    public class NeighbourCoordinates : INeighbourCoordinates
    {
        public List<(int, int)> GetNeighbourCoordinates(int y, int x, int rows, int cols)
        {
            if (y < 1) y = 1;
            if (x < 1) x = 1;

            if (y + 1 >= rows) y = rows - 2;
            if (x + 2 >= cols) x = cols - 3;

            return [
                (y, x + 1),
                (y, x + 2),
                (y - 1, x),

                (y + 1, x - 1),
                (y + 1, x),
                (y + 1, x + 2)
            ];
        }
    }
}
