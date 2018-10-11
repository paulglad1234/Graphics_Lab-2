using System;
using System.Drawing;

namespace Graphics_Lab_2
{
    public class DrawAlgoritms
    {
        /*public static void DrawHLine(Bitmap bmp, Color color, int x, int y, int w)
        {
            for (int i = 0; i < w; i++)
            {
                bmp.SetPixel(x + i, y, color);
            }
        }
        public static void DrawVLine(Bitmap bmp, Color color, int x, int y, int w)
        {
            for (int i = 0; i < w; i++)
            {
                bmp.SetPixel(x, y + i, color);
            }
        }*/
        /*public static void DrawLine(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x1; x1 = x2; x2 = tmp;
                tmp = y1; y1 = y2; y2 = tmp;
            }
            int diffx = x2 - x1;
            int diffy = y2 - y1;
            float dy = diffy / (float) diffx;
            for (int i = 0; i <= diffx; i++)
            {
                bmp.SetPixel(x1 + i, (int) (y1 + i * dy), color);
            }
        }*/
        /*public static void DDA(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            int diffx = x2 - x1;
            int diffy = y2 - y1;
            float L = Math.Max(Math.Abs(diffx), Math.Abs(diffy)) + 1;
            float dx = diffx / L;
            float dy = diffy / L;
            for (int i = 0; i <= L; i++)
            {
                bmp.SetPixel((int)(x1 + i * dx), (int)(y1 + i * dy), color);
            }
        }*/
        private static void SetPixel(Bitmap bmp, Color color, int x, int y)
        {
            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
                bmp.SetPixel(x, y, color);
        }
        //lvl 1: DrawLine, DrawPolygon x3
        private static void FirstLineCalculations(ref int x1, ref int y1, ref int x2, ref int y2,
            out int dX, out int dY, out int f, out int x, out int y)
        {
            if (y2 < y1)
            {
                int tmp = x1; x1 = x2; x2 = tmp;
                tmp = y1; y1 = y2; y2 = tmp;
            }
            dX = x2 - x1;
            dY = y2 - y1;
            f = 2 * dY - dX;
            x = x1;
            y = y1;
        }
        public static void BresenhamLine(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            //f = 2 * F(x, y);
            //F(x,y) = (x - x1) * Dy + (y - y1) * Dx;
            FirstLineCalculations(ref x1, ref y1, ref x2, ref y2,
                out int dX, out int dY, out int f, out int x, out int y);
            DrawLine(bmp, color, x, y, f, dX, dY);
        }
        private static void DrawLine(Bitmap bmp, Color color, int x, int y, int f, int dX, int dY)
        {
            if (dX > 0)
            {
                if (dX > dY)
                {
                    DrawLineLeftRight(bmp, color, x, y, f, dX, dY, 1);
                    return;
                }
                DrawLineDown(bmp, color, x, y, f, dX, dY, 1);
                return;
            }
            dX = Math.Abs(dX);
            if (dX > dY)
            {
                DrawLineLeftRight(bmp, color, x, y, f, dX, dY, -1);
                return;
            }
            DrawLineDown(bmp, color, x, y, f, dX, dY, -1);
        }
        private static void DrawLineLeftRight(Bitmap bmp, Color color, int x, int y, int f, int dX, int dY, int e)
        {
            for (int i = 0; i < dX; i++)
            {
                SetPixel(bmp, color, x, y);
                if (f < 0)
                    f += 2 * dY;
                else
                {
                    y++;
                    f += 2 * (dY - dX);
                }
                x += e;
            }
        }
        private static void DrawLineDown(Bitmap bmp, Color color, int x, int y, int f, int dX, int dY, int e)
        {
            for (int i = 0; i < dY; i++)
            {
                SetPixel(bmp, color, x, y);
                if (f < 0)
                    f += 2 * dX;
                else
                {
                    x += e;
                    f += 2 * (dX - dY);
                }
                y++;
            }
        }

        //lvl 2: DrawEllipse, DrawArc, DrawPie x2
        // Ellipse:
        private static void FirstCalculations(int x1, int y1, int x2, int y2, out int x, out int y,
            out int xc, out int yc, out int asqr, out int bsqr)
        {
            if (y2 < y1)
            {
                int tmp = x1; x1 = x2; x2 = tmp;
                tmp = y1; y1 = y2; y2 = tmp;
            }
            xc = (x1 + x2) / 2; yc = (y1 + y2) / 2;
            asqr = (xc - x1) * (xc - x1); bsqr = (yc - y1) * (yc - y1);
            x = xc; y = y2;
        }
        private static void FindNextPixel(ref int x, ref int y, int xc, int yc, int asqr, int bsqr)
        {
            int Dd = bsqr * (x + 1 - xc) * (x + 1 - xc) + asqr * (y - 1 - yc) * (y - 1 - yc) - asqr * bsqr;
            if (Dd == 0)
            {
                x++;
                y--;
            }
            else if (Dd < 0)
            {
                int Dh = Dd - asqr * (2 * (yc - y) + 1);
                if (Dh < 0)
                    x++;
                else
                {
                    int di = Math.Abs(Dh) - Math.Abs(Dd);
                    if (di < 0)
                        x++;
                    else
                    {
                        x++; y--;
                    }
                }
            }
            else
            {
                int Dv = Dd - bsqr * (2 * (x - xc) + 1);
                if (Dv < 0)
                    y--;
                else
                {
                    int si = Math.Abs(Dv) - Math.Abs(Dd);
                    if (si < 0)
                        y--;
                    else
                    {
                        x++; y--;
                    }
                }
            }
        }
        public static void SetFourPixels(Bitmap bmp, Color color, int x, int y, int xc, int yc)
        {
            SetPixel(bmp, color, x, y);
            SetPixel(bmp, color, 2 * xc - x, y);
            SetPixel(bmp, color, 2 * xc - x, 2 * yc - y);
            SetPixel(bmp, color, x, 2 * yc - y);
        }
        public static void FillPixels(Bitmap bmp, Color color, int x, int y, int xc, int yc)
        {
            for (int i = x; i >= 2 * xc - x; i--)
            {
                SetPixel(bmp, color, i, y);
                SetPixel(bmp, color, i, 2 * yc - y);
            }
        }
        private static void FillOrSetPixels(Bitmap bmp, Color color, int x, int y, int xc, int yc, bool fill)
        {
            if (fill)
                FillPixels(bmp, color, x, y, xc, yc);
            else
                SetFourPixels(bmp, color, x, y, xc, yc);
        }
        // Arc & Pie:
        private static bool CheckAngle(int x, int y, int xc, int yc, double stAn, double destAn)
        {
            double currentAngle;
            if ((x - xc) == 0)
            {
                if ((y - yc) > 0)
                    currentAngle = Math.PI / 2;
                else
                {
                    currentAngle = 3 * Math.PI / 2;
                }
            }
            currentAngle = Math.Atan((y - yc) / (double)(x - xc));
            if ((x - xc) < 0)
                currentAngle += Math.PI;
            if (currentAngle < 0)
                currentAngle += 2 * Math.PI;
            return stAn <= currentAngle && currentAngle <= destAn ||
                stAn <= currentAngle + 2 * Math.PI && currentAngle + 2 * Math.PI <= destAn;
        }
        private static void SetArcPxl(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn)
        {
            if (CheckAngle(x, y, xc, yc, stAn, destAn))
                SetPixel(bmp, color, x, y);
        }
        public static void SetArcPixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn)
        {
            SetArcPxl(bmp, color, x, y, xc, yc, stAn, destAn);
            SetArcPxl(bmp, color, 2 * xc - x, y, xc, yc, stAn, destAn);
            SetArcPxl(bmp, color, 2 * xc - x, 2 * yc - y, xc, yc, stAn, destAn);
            SetArcPxl(bmp, color, x, 2 * yc - y, xc, yc, stAn, destAn);
        }
        private static void DrawBorders(Bitmap bmp, Color color, int a, int b, int xc, int yc,
            double stAn, double destAn)
        {
            double an1 = Math.Atan2(a * Math.Sin(stAn), b * Math.Cos(stAn));
            double an2 = Math.Atan2(a * Math.Sin(destAn), b * Math.Cos(destAn));
            BresenhamLine(bmp, color, xc, yc, xc + (int)(a * Math.Cos(an1)), yc + (int)(b * Math.Sin(an1)));
            BresenhamLine(bmp, color, xc, yc, xc + (int)(a * Math.Cos(an2)), yc + (int)(b * Math.Sin(an2)));
        }
        public static void FillPiePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn)
        {
            for (int i = x; i >= 2 * xc - x; i--)
            {
                SetArcPxl(bmp, color, i, y, xc, yc, stAn, destAn);
                SetArcPxl(bmp, color, i, 2 * yc - y, xc, yc, stAn, destAn);
            }
        }

        /*interface IPixels {
            void Fill(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn);
        }
        class PiePixels : IPixels
        {
            public void Fill(Bitmap bmp, Color color, int x, int y, int xc, int yc, double stAn, double destAn)
            {
                FillPiePixels(bmp, color, x, y, xc, yc, stAn, destAn);
            }
        }
        class ArcPixels : IPixels
        {
            public void Fill(Bitmap bmp, Color color, int x, int y, int xc, int yc, double stAn, double destAn)
            {
                SetArcPixels(bmp, color, x, y, xc, yc, stAn, destAn);
            }
        }
        private static void SetOrFillPiePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn, IPixels fill)
        {
            fill.Fill(bmp, color, x, y, xc, yc, stAn, destAn);
        }*/
        private static void SetOrFillPiePixels(Bitmap bmp, Color color, int x, int y, int xc, int yc,
            double stAn, double destAn, bool fill)
        {
            if (fill)
                FillPiePixels(bmp, color, x, y, xc, yc, stAn, destAn);
            else
            {
                SetArcPixels(bmp, color, x, y, xc, yc, stAn, destAn);
            }
        }
        public static void BresenhamEllipse(Bitmap bmp, Color color, int x1, int y1, int x2, int y2, bool fill)
        {
            IPixels pixels;
            if (fill)
            { pixels = new Fill(); }
            else { pixels = new Set(); }
            FirstCalculations(x1, y1, x2, y2, out int x, out int y,
            out int xc, out int yc, out int asqr, out int bsqr);
            while (y >= yc)
            {
                pixels.FillOrSetEllpsePixels(bmp, color, x, y, xc, yc);
                FindNextPixel(ref x, ref y, xc, yc, asqr, bsqr);
            }
        }
        public static void BresenhamArc(Bitmap bmp, Color color, int x1, int y1, int x2, int y2,
            int startAngle, int sweepAngle)
        {
            double stAn = startAngle * Math.PI / 180;
            double swAn = sweepAngle * Math.PI / 180;
            double destAn = stAn + swAn;
            FirstCalculations(x1, y1, x2, y2, out int x, out int y,
            out int xc, out int yc, out int asqr, out int bsqr);
            while (y >= yc)
            {
                SetArcPixels(bmp, color, x, y, xc, yc, stAn, destAn);
                FindNextPixel(ref x, ref y, xc, yc, asqr, bsqr);
            }
        }
        public static void BresenhamPie(Bitmap bmp, Color color, int x1, int y1, int x2, int y2,
            int startAngle, int sweepAngle, bool fill)
        {
            IPixels pixels;
            if (fill)
            { pixels = new Fill(); }
            else { pixels = new Set(); }
            double stAn = startAngle * Math.PI / 180;
            double swAn = sweepAngle * Math.PI / 180;
            double destAn = stAn + swAn;
            FirstCalculations(x1, y1, x2, y2, out int x, out int y,
            out int xc, out int yc, out int asqr, out int bsqr);
            int a = Math.Abs(xc - x2);
            int b = Math.Abs(yc - y2);
            //IPixels xxx = (fill) ? (IPixels)new PiePixels() : (IPixels) new ArcPixels();
            while (y >= yc)
            {
                pixels.FillOrSetPiePixels(bmp, color, x, y, xc, yc, stAn, destAn);

                FindNextPixel(ref x, ref y, xc, yc, asqr, bsqr);
            }
            DrawBorders(bmp, color, a, b, xc, yc, stAn, destAn);
        }

        // АЛГОРИТМЫ ВУ

        public static void WuLine(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            FirstLineCalculations(ref x1, ref y1, ref x2, ref y2,
                out int dX, out int dY, out int f, out int x, out int y);
            DrawWuLine(bmp, color, x, y, f, dX, dY);
        }
        private static void DrawWuLine(Bitmap bmp, Color color, int x, int y, int f, int dX, int dY)
        {
            if (dX > 0)
            {
                if (dX > dY)
                {
                    DrawWuLineLeftRight(bmp, color, x, y, f, dX, dY, 1);
                    return;
                }
                DrawWuLineDown(bmp, color, x, y, f, dX, dY, 1);
                return;
            }
            dX = Math.Abs(dX);
            if (dX > dY)
            {
                DrawWuLineLeftRight(bmp, color, x, y, f, dX, dY, -1);
                return;
            }
            DrawWuLineDown(bmp, color, x, y, f, dX, dY, -1);
        }
        private static void DrawWuLineLeftRight(Bitmap bmp, Color color, int x, int y, int f, int dX, int dY, int e)
        {
            for (int i = 0; i < dX; i++)
            {
                if (f == 0)
                    SetPixel(bmp, color, x, y);
                if (f < 0)
                {
                    if (Math.Abs(f) < Math.Abs(f += 2 * dY))
                    {
                        SetPixel(bmp, Color.DarkGray, x, y);
                        SetPixel(bmp, Color.Gray, x, y + 1);
                    }
                    else
                    {
                        SetPixel(bmp, Color.Gray, x, y);
                        SetPixel(bmp, Color.DarkGray, x, y + 1);
                    }
                }
                else
                {
                    if (Math.Abs(f) < Math.Abs(f - 2 * dY))
                    {
                        SetPixel(bmp, Color.DarkGray, x, y);
                        SetPixel(bmp, Color.Gray, x, y - 1);
                    }
                    else
                    {
                        SetPixel(bmp, Color.Gray, x, y);
                        SetPixel(bmp, Color.DarkGray, x, y - 1);
                    }
                    y++;
                    f += 2 * (dY - dX);
                }
                x += e;
            }
        }
        private static void DrawWuLineDown(Bitmap bmp, Color color, int x, int y, int f, int dX, int dY, int e)
        {
            for (int i = 0; i < dY; i++)
            {
                if (f == 0)
                    SetPixel(bmp, color, x, y);
                if (f < 0)
                {
                    if (Math.Abs(f) < Math.Abs(f += 2 * dX))
                    {
                        SetPixel(bmp, Color.DarkGray, x, y);
                        SetPixel(bmp, Color.Gray, x + 1, y);
                    }
                    else
                    {
                        SetPixel(bmp, Color.Gray, x, y);
                        SetPixel(bmp, Color.DarkGray, x + 1, y);
                    }
                }
                else
                {
                    if (Math.Abs(f) < Math.Abs(f - 2 * dX))
                    {
                        SetPixel(bmp, Color.DarkGray, x, y);
                        SetPixel(bmp, Color.Gray, x - 1, y);
                    }
                    else
                    {
                        SetPixel(bmp, Color.Gray, x, y);
                        SetPixel(bmp, Color.DarkGray, x - 1, y);
                    }
                    x += e;
                    f += 2 * (dX - dY);
                }
                y++;
            }
        }
        public static void WuEllipse(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            FirstCalculations(x1, y1, x2, y2, out int x, out int y,
            out int xc, out int yc, out int asqr, out int bsqr);
            while (y >= yc)
            {
                //ошибка:
                int Dd = bsqr * (x + 1 - xc) * (x + 1 - xc) + asqr * (y - 1 - yc) * (y - 1 - yc) - asqr * bsqr;
                if (Dd == 0)
                {
                    SetFourPixels(bmp, color, x, y, xc, yc);
                    x++;
                    y--;
                }
                else if (Dd < 0)
                {
                    int Dh = Dd - asqr * (2 * (yc - y) + 1);
                    //Выбор между текущим и горизонтальным - какой закрасить насыщеннее
                    if (Math.Abs(Dd) < Math.Abs(Dh))
                    {
                        SetFourPixels(bmp, Color.DarkGray, x, y, xc, yc);
                        SetFourPixels(bmp, Color.Gray, x + 1, y, xc, yc);
                    }
                    else
                    {
                        SetFourPixels(bmp, Color.Gray, x, y, xc, yc);
                        SetFourPixels(bmp, Color.DarkGray, x + 1, y, xc, yc);
                    }
                    if (Dh < 0)
                        x++;
                    else
                    {
                        int di = Math.Abs(Dh) - Math.Abs(Dd);
                        if (di < 0)
                            x++;
                        else
                        {
                            x++; y--;
                        }
                    }
                }
                else
                {
                    int Dv = Dd - bsqr * (2 * (x - xc) + 1);
                    //Выбор между текущим и вертикальным
                    if (Math.Abs(Dd) < Math.Abs(Dv))
                    {
                        SetFourPixels(bmp, Color.DarkGray, x, y, xc, yc);
                        SetFourPixels(bmp, Color.Gray, x, y + 1, xc, yc);
                    }
                    else
                    {
                        SetFourPixels(bmp, Color.Gray, x, y, xc, yc);
                        SetFourPixels(bmp, Color.DarkGray, x, y + 1, xc, yc);
                    }
                    if (Dv < 0)
                        y--;
                    else
                    {
                        int si = Math.Abs(Dv) - Math.Abs(Dd);
                        if (si < 0)
                            y--;
                        else
                        {
                            x++; y--;
                        }
                    }
                }
            }
        }
        public static void WuArc(Bitmap bmp, Color color, int x1, int y1, int x2, int y2,
            int startAngle, int sweepAngle)
        {
            double stAn = startAngle * Math.PI / 180;
            double swAn = sweepAngle * Math.PI / 180;
            double destAn = stAn + swAn;
            FirstCalculations(x1, y1, x2, y2, out int x, out int y,
            out int xc, out int yc, out int asqr, out int bsqr);
            while (y >= yc)
            {
                //ошибка:
                int Dd = bsqr * (x + 1 - xc) * (x + 1 - xc) + asqr * (y - 1 - yc) * (y - 1 - yc) - asqr * bsqr;
                if (Dd == 0)
                {
                    SetArcPixels(bmp, color, x, y, xc, yc, stAn, destAn);
                    x++;
                    y--;
                }
                else if (Dd < 0)
                {
                    int Dh = Dd - asqr * (2 * (yc - y) + 1);
                    //Выбор между текущим и горизонтальным - какой закрасить насыщеннее
                    if (Math.Abs(Dd) < Math.Abs(Dh))
                    {
                        SetArcPixels(bmp, Color.DarkGray, x, y, xc, yc, stAn, destAn);
                        SetArcPixels(bmp, Color.Gray, x + 1, y, xc, yc, stAn, destAn);
                    }
                    else
                    {
                        SetArcPixels(bmp, Color.Gray, x, y, xc, yc, stAn, destAn);
                        SetArcPixels(bmp, Color.DarkGray, x + 1, y, xc, yc, stAn, destAn);
                    }
                    if (Dh < 0)
                        x++;
                    else
                    {
                        int di = Math.Abs(Dh) - Math.Abs(Dd);
                        if (di < 0)
                            x++;
                        else
                        {
                            x++; y--;
                        }
                    }
                }
                else
                {
                    int Dv = Dd - bsqr * (2 * (x - xc) + 1);
                    //Выбор между текущим и вертикальным
                    if (Math.Abs(Dd) < Math.Abs(Dv))
                    {
                        SetArcPixels(bmp, Color.DarkGray, x, y, xc, yc, stAn, destAn);
                        SetArcPixels(bmp, Color.Gray, x, y + 1, xc, yc, stAn, destAn);
                    }
                    else
                    {
                        SetArcPixels(bmp, Color.Gray, x, y, xc, yc, stAn, destAn);
                        SetArcPixels(bmp, Color.DarkGray, x, y + 1, xc, yc, stAn, destAn);
                    }
                    if (Dv < 0)
                        y--;
                    else
                    {
                        int si = Math.Abs(Dv) - Math.Abs(Dd);
                        if (si < 0)
                            y--;
                        else
                        {
                            x++; y--;
                        }
                    }
                }
            }
        }
        public static void WuPie(Bitmap bmp, Color color, int x1, int y1, int x2, int y2,
            int startAngle, int sweepAngle)
        {
            double stAn = startAngle * Math.PI / 180;
            double swAn = sweepAngle * Math.PI / 180;
            double destAn = stAn + swAn;
            WuArc(bmp, color, x1, y1, x2, y2, startAngle, sweepAngle);
            int xc = (x1 + x2) / 2; int yc = (y1 + y2) / 2;
            int a = Math.Abs(xc - x2);
            int b = Math.Abs(yc - y2);
            DrawWuBorders(bmp, color, a, b, xc, yc, stAn, destAn);
        }
        private static void DrawWuBorders(Bitmap bmp, Color color, int a, int b, int xc, int yc,
            double stAn, double destAn)
        {
            double an1 = Math.Atan2(a * Math.Sin(stAn), b * Math.Cos(stAn));
            double an2 = Math.Atan2(a * Math.Sin(destAn), b * Math.Cos(destAn));
            WuLine(bmp, color, xc, yc, xc + (int)(a * Math.Cos(an1)), yc + (int)(b * Math.Sin(an1)));
            WuLine(bmp, color, xc, yc, xc + (int)(a * Math.Cos(an2)), yc + (int)(b * Math.Sin(an2)));
        }
    }
}