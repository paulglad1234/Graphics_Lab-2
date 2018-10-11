using System.Drawing;

namespace Graphics_Lab_2
{
    class Fill: IPixels
    {
        public void FillOrSetEllpsePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc)
        {
            DrawAlgoritms.FillPixels(bmp, color, x, y, xc, yc);
        }
        public void FillOrSetPiePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn)
        {
            DrawAlgoritms.FillPiePixels(bmp, color, x, y, xc, yc, stAn, destAn);
        }
    }
}
