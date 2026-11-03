using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public static class PlacaPersona3
    {
        private const int PadIzq = 8;
        private const int PadDer = 6;
        private const int PadVert = 2;
        private const int Sesgo = 6;

        private static readonly Color Negro = Color.FromArgb(3, 6, 20);

        private static readonly ConditionalWeakTable<Label, object> _aplicados =
            new ConditionalWeakTable<Label, object>();

        public static void Aplicar(Label lbl)
        {
            object marca;
            if (_aplicados.TryGetValue(lbl, out marca)) return;
            _aplicados.Add(lbl, new object());

            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = TemaPersona3.Blanco;
            lbl.Font = new Font(lbl.Font, FontStyle.Italic);

            if (lbl.AutoSize)
            {
                lbl.Padding = new Padding(PadIzq, PadVert, PadDer, PadVert);
                lbl.Left -= PadIzq;
                lbl.Top -= PadVert;
            }

            lbl.Paint += Placa_Paint;
        }

        private static void Placa_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = (Label)sender;
            int w = lbl.ClientSize.Width;
            int h = lbl.ClientSize.Height;
            if (w <= Sesgo * 2 || h <= 4) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            PointF[] placa =
            {
                new PointF(Sesgo, 0),
                new PointF(w, 0),
                new PointF(w - Sesgo, h),
                new PointF(0, h)
            };

            using (var relleno = new SolidBrush(Negro))
            {
                g.FillPolygon(relleno, placa);
            }

            using (var linea = new Pen(TemaPersona3.Cian, 2f))
            {
                g.DrawLine(linea, 0, h - 1, w - Sesgo, h - 1);
            }

            Rectangle zonaTexto = new Rectangle(PadIzq, 0, Math.Max(1, w - PadIzq - PadDer), h);

            TextRenderer.DrawText(
                g,
                lbl.Text,
                lbl.Font,
                zonaTexto,
                lbl.ForeColor,
                TextFormatFlags.Left |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.NoPrefix |
                TextFormatFlags.NoPadding);
        }
    }
}