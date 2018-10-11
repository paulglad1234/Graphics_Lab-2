using System.Drawing;

namespace Graphics_Lab_2
{
    class Set: IPixels
    {
        public void FillOrSetEllpsePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc)
        {
            DrawAlgoritms.SetFourPixels(bmp, color, x, y, xc, yc);
        }
        public void FillOrSetPiePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn)
        {
            DrawAlgoritms.SetArcPixels(bmp, color, x, y, xc, yc, stAn, destAn);
        }
    }
}
