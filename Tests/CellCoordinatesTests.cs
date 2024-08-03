using Grid;

namespace Tests
{
    [TestFixture]
    public class CellCoordinatesTests
    {

        [Test]
        [TestCase(10,10)]
        [TestCase(11,11)]
        public void GetNeighboursCoords_Test(int y, int x)
        {
            List<List<(int, int)>> neighbours = [
                // even cols
                [(y, x + 1), (y - 1, x + 1), (y - 1, x),
                 (y - 1,x - 1), (y, x - 1), (y + 1, x)],

                // odd cols
                [(y + 1, x + 1), (y, x + 1), (y - 1, x),
                 (y, x - 1), (y + 1, x - 1), (y + 1, x)],
            ];

            var nc = new CellCoordinates();

            var actual = nc.GetNeighbourCoordinates(y, x);

            for (int i = 0; i < neighbours[y%2].Count; i++)
            {
                Assert.That(actual[i].Item1, Is.EqualTo(neighbours[y % 2][i].Item1));
                Assert.That(actual[i].Item2, Is.EqualTo(neighbours[y % 2][i].Item2));
            }
        }

        [Test]
        [TestCase(-1, 0, 2, 2, true)]
        [TestCase(0, -1, 2, 2, true)]
        [TestCase(2, 0, 2, 2, true)]
        [TestCase(0, 2, 2, 2, true)]
        [TestCase(1, 0, 2, 2, false)]
        [TestCase(0, 1, 2, 2, false)]
        public void IsOutOfBounds_Test(int y, int x, int rows, int cols, bool expected)
        {
            var nc = new CellCoordinates();
            var actual = nc.IsOutOfBounds(y, x, rows, cols);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
