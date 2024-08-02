using Grid;

namespace Tests
{
    [TestFixture]
    public class CellGridTests
    {

        [Test]
        public void GetNeighboursCoords_Test()
        {
            List<(int, int)> expected = [
                (10, 11),
                (10, 12),
                (9, 10),

                (11, 9),
                (11, 10),
                (11, 12)
            ];

            var nc = new NeighbourCoordinates();

            var actual = nc.GetNeighbourCoordinates(10, 10, 10, 10);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Item1, Is.EqualTo(expected[i].Item1));
                Assert.That(actual[i].Item2, Is.EqualTo(expected[i].Item2));
            }
        }


    }
}
