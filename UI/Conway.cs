using Grid;

namespace UI
{
    public partial class Conway : Form
    {
        private System.Windows.Forms.Timer _redrawTimer;

        private int _redrawIntervalMs = 100;

        private float _hexHeight = 20;
        private int _rows = 50;
        private int _cols = 50;
        private int _livePercent = 10;

        private Dictionary<CellType, SolidBrush> _typeBrushes = new Dictionary<CellType, SolidBrush>()
        {
            { CellType.RED, new SolidBrush(Color.Red) },
            { CellType.GREEN, new SolidBrush(Color.Green) },
            { CellType.BLUE, new SolidBrush(Color.Blue) },
            { CellType.YELLOW, new SolidBrush(Color.Yellow) },
        };

        private SolidBrush _deadBrush = new SolidBrush(Color.Black);

        CellGrid _grid;
        public Conway()
        {
            InitializeComponent();
            InitGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _redrawTimer = new System.Windows.Forms.Timer
            {
                Interval = _redrawIntervalMs
            };
            _redrawTimer.Tick += RedrawTimer_Tick;

            LivePercentTb.TextChanged += LivePercentTb_TextChanged;
            DelayTb.TextChanged += DelayTb_TextChanged;
        }

        private void InitGrid()
        {
            var cellCoords = new CellCoordinates();
            var seed = new GridSeed(cellCoords, _livePercent);

            _grid = new CellGrid(_rows, _cols, seed, cellCoords);
        }

        private void GridCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var cell in _grid.Grid)
            {
                var brush = cell.IsAlive ? _typeBrushes[cell.Type] : _deadBrush;

                var points = HexCoords.GetPoints(_hexHeight, cell.Y, cell.X);

                e.Graphics.FillPolygon(brush, points);
                e.Graphics.DrawPolygon(Pens.LightGray, points);
            }
        }

        private void GridCanvas_Resize(object sender, EventArgs e)
        {
            GridCanvas.Refresh();
        }

        private void RedrawTimer_Tick(object? sender, EventArgs e)
        {
            GridCanvas.Refresh();
            _grid.UpdateGrid();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (_redrawTimer.Enabled)
            {
                StartBtn.Text = "Start";
                _redrawTimer.Stop();
            }
            else
            {
                StartBtn.Text = "Stop";
                if (!_redrawTimer.Enabled)
                {
                    _redrawTimer.Start();
                }
            }
        }

        private void DelayTb_TextChanged(object? sender, EventArgs e)
        {
            if (int.TryParse(DelayTb.Text, out int delay))
                _redrawIntervalMs = delay;

            _redrawTimer.Interval = _redrawIntervalMs;
        }
        private void LivePercentTb_TextChanged(object? sender, EventArgs e)
        {
            if (int.TryParse(LivePercentTb.Text, out int percent))
                _livePercent = percent;

            InitGrid();
            GridCanvas.Refresh();
        }
    }
}
