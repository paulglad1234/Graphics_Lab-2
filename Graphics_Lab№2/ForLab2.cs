using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graphics_Lab_2
{
    public partial class ForLab2 : Form
    {
        Point cur = new Point(0, 0);
        public ForLab2()
        {
            InitializeComponent();
        }
        public void DrawPicture(Bitmap bmp, Graphics g)
        {
            if (IsEllipse.Checked)
            {
                startAngleNumeric.Visible = false;
                sweepAngleNumeric.Visible = false;
                DrawAlgoritms.BresenhamEllipse(bmp, Color.Yellow, Width / 2, Height / 2, cur.X, cur.Y, true);
                DrawAlgoritms.BresenhamEllipse(bmp, Color.Black, Width / 2, Height / 2, cur.X, cur.Y, false);
            }
            if (IsArc.Checked)
            {
                startAngleNumeric.Visible = true;
                sweepAngleNumeric.Visible = true;

                DrawAlgoritms.BresenhamArc(bmp, Color.Black, Width / 2, Height / 2, cur.X, cur.Y,
                    (int)startAngleNumeric.Value, (int)sweepAngleNumeric.Value);
            }
            if (IsPie.Checked)
            {
                startAngleNumeric.Visible = true;
                sweepAngleNumeric.Visible = true;
                DrawAlgoritms.BresenhamPie(bmp, Color.Yellow, Width / 2, Height / 2, cur.X, cur.Y,
                    (int)startAngleNumeric.Value, (int)sweepAngleNumeric.Value, true);
                DrawAlgoritms.BresenhamPie(bmp, Color.Black, Width / 2, Height / 2, cur.X, cur.Y,
                    (int)startAngleNumeric.Value, (int)sweepAngleNumeric.Value, false);
            }
        }
        private void Draw(Graphics g, Rectangle r)
        {
            Bitmap bmp = new Bitmap(r.Width, r.Height);
            DrawPicture(bmp, g);
            g.DrawImage(bmp, r);
            bmp.Dispose();
        }
        private void ForLab2_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics, e.ClipRectangle);
        }
        private void ForLab2_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            Invalidate();
        }
    }
}
