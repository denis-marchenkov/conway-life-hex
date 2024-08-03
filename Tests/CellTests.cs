using Grid;

namespace Tests
{
    [TestFixture]
    public class CellTests
    {

        private Cell _cell;

        [SetUp]
        public void SetUp()
        {
           _cell = new Cell(0, 0) { State = CellState.ALIVE };
        }

        [Test]
        public void IsUnderpopulated_Test()
        {
            Assert.That(_cell.IsUnderpopulated(), Is.True);
        }

        [Test]
        public void IsUnderpopulated_True_Test()
        {
            _cell.Neighbours = [new Cell(0, 0) { Type = CellType.RED }];

            Assert.That(_cell.IsUnderpopulated(), Is.True);
        }

        [Test]
        public void IsUnderpopulated_False_Test()
        {
            _cell.Type = CellType.RED;
            _cell.Neighbours =
                [
                    new Cell(0, 0) { Type = CellType.RED },
                    new Cell(0, 0) { Type = CellType.RED },
                    new Cell(0, 0) { Type = CellType.RED }
                ];

            Assert.That(_cell.IsUnderpopulated(), Is.False);
        }

        [Test]
        public void IsOverpopulated_Test()
        {
            Assert.That(_cell.IsOverpopulated(), Is.False);
        }

        [Test]
        public void IsOverpopulated_True_Test()
        {
            _cell.Neighbours =
                [
                    new Cell(0, 0) { Type = CellType.RED },
                    new Cell(0, 0) { Type = CellType.RED },
                    new Cell(0, 0) { Type = CellType.RED },
                    new Cell(0, 0) { Type = CellType.RED }
                ];

            Assert.That(_cell.IsOverpopulated(), Is.True);
        }

        [Test]
        public void IsOverpopulated_False_Test()
        {
            _cell.Neighbours = [new Cell(0, 0) { Type = CellType.RED }];

            Assert.That(_cell.IsOverpopulated(), Is.False);
        }

        [Test]
        public void Reproduce_False_Test()
        {
            var actual = _cell.Reproduce();
            Assert.That(actual.Type, Is.EqualTo(CellType.UNDEFINED));
        }

        [Test]
        public void Reproduce_Tie_Test()
        {
            _cell.State = CellState.DEAD;
            _cell.Neighbours =
            [
                new Cell(0, 0) { Type = CellType.RED },
                new Cell(0, 0) { Type = CellType.RED },
                new Cell(0, 0) { Type = CellType.RED },

                new Cell(0, 0) { Type = CellType.GREEN },
                new Cell(0, 0) { Type = CellType.GREEN },
                new Cell(0, 0) { Type = CellType.GREEN },
            ];

            var actual = _cell.Reproduce();

            Assert.That(actual.State, Is.EqualTo(CellState.DEAD));
            Assert.That(actual.Type, Is.EqualTo(CellType.UNDEFINED));
        }

        [Test]
        public void Reproduce_Competitor_Test()
        {
            _cell.State = CellState.DEAD;
            _cell.Neighbours =
            [
                new Cell(0, 0) { Type = CellType.RED },
                new Cell(0, 0) { Type = CellType.RED },
                new Cell(0, 0) { Type = CellType.RED },

                new Cell(0, 0) { Type = CellType.GREEN },
                new Cell(0, 0) { Type = CellType.GREEN },
            ];

            var actual = _cell.Reproduce();

            Assert.That(actual.State, Is.EqualTo(CellState.DEAD));
            Assert.That(actual.Type, Is.EqualTo(CellType.UNDEFINED));
        }

        [Test]
        public void Reproduce_True_Test()
        {
            _cell.State = CellState.DEAD;
            _cell.Neighbours =
            [
                new Cell(0, 0) { Type = CellType.GREEN },
                new Cell(0, 0) { Type = CellType.GREEN },
            ];

            var actual = _cell.Reproduce();

            Assert.That(actual.State, Is.EqualTo(CellState.ALIVE));
            Assert.That(actual.Type, Is.EqualTo(CellType.GREEN));
        }

        [Test]
        public void GetRandomType_Test()
        {
            var actual = Cell.GetRandomType();
            Assert.That(actual, Is.InstanceOf<CellType>());
        }
    }
}