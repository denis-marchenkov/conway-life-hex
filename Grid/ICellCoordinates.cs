namespace Grid
{
    public interface ICellCoordinates
    {
        // get coordinates of six cell neighbours
        public List<(int, int)> GetNeighbourCoordinates(int y, int x);

        // check if cell coordinates is in grid bounds
        public bool IsOutOfBounds(int y, int x, int rows, int cols);

        // return string key for coordinates pair
        public string ToString(int y, int x);
    }
}
