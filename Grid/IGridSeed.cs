namespace Grid
{
    public interface IGridSeed
    {
        // Generate initial greed with a certain percent of live cells with different neighbours
        public Cell[,] Seed(int rows, int cols);
    }
}
