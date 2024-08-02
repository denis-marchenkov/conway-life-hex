namespace UI
{
    public class HexCoords
    {
        public static PointF[] GetPoints(
            float hexHeight,
            float row,
            float col)
        {
            var width = (float)(4 * (hexHeight / 2 / Math.Sqrt(3)));
            float x = 0;
            var y = hexHeight / 2;

            y += row * hexHeight;

            if (col % 2 != 0) y += hexHeight / 2;

            x += col * (width * 0.75f);

            return
                [
                    new PointF(x, y),
                    new PointF(x + width * 0.25f, y - hexHeight / 2),
                    new PointF(x + width * 0.75f, y - hexHeight / 2),
                    new PointF(x + width, y),
                    new PointF(x + width * 0.75f, y + hexHeight / 2),
                    new PointF(x + width * 0.25f, y + hexHeight / 2),
                ];
        }
    }
}
