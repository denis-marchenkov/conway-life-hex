using Grid;

namespace UI
{
    public partial class Conway : Form
    {
        private float _hexHeight = 15;
        private int _rows = 50;
        private int _cols = 50;

        private Dictionary<CellType, SolidBrush> _typeBrushes = new Dictionary<CellType, SolidBrush>()
        {
            { CellType.RED, new SolidBrush(Color.Red) },
            { CellType.GREEN, new SolidBrush(Color.Green) },
            { CellType.BLUE, new SolidBrush(Color.Blue) },
        };

        private SolidBrush _deadBrush = new SolidBrush(Color.Black);

        CellGrid grid;
        public Conway()
        {
            InitializeComponent();
            var neighbourCoords = new NeighbourCoordinates();
            var seed = new GridSeed(neighbourCoords, 1);

            grid = new CellGrid(_rows, _cols, seed, neighbourCoords);

            //grid.Grid[10,10].State = CellState.ALIVE;
            //grid.Grid[10,10].Type = CellType.RED;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GridCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var cell in grid.Grid)
            {
                var brush = cell.IsAlive ? _typeBrushes[cell.Type] : _deadBrush;

                var points = HexCoords.GetPoints(_hexHeight, cell.Y, cell.X);
                e.Graphics.FillPolygon(brush, points);
            }
        }

        private void GridCanvas_Resize(object sender, EventArgs e)
        {
            GridCanvas.Refresh();
        }
    }
}
