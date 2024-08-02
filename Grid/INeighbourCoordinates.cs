namespace Grid
{
    public interface INeighbourCoordinates
    {
        // get coordinates of six cell neighbours
        public List<(int, int)> GetNeighbourCoordinates(int y, int x, int rows, int cols);
    }
}
