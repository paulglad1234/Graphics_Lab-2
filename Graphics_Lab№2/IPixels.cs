using System.Drawing;

namespace Graphics_Lab_2
{
    interface IPixels
    {
        void FillOrSetEllpsePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc);
        void FillOrSetPiePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn);
    }
}
