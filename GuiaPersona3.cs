//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public class GuiaPersona3 : Control
    {
        private static readonly Color Negro = Color.FromArgb(3, 6, 20);

        private readonly Font _fuenteInicial =
            new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);

        public GuiaPersona3()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = _fuenteInicial;
            Size = new Size(420, 44);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int w = Width;
            int h = Height;
            if (w <= 1 || h <= 1) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            float k = Font.SizeInPoints / 12f;
            float yLinea = h - 8f * k;

            using (var degradado = new LinearGradientBrush(
                new PointF(0, 0), new PointF(w, 0),
                Color.FromArgb(40, 255, 255, 255), Color.White))
            using (var lapiz = new Pen(degradado, 2f * k))
            {
                g.DrawLine(lapiz, 0, yLinea, w, yLinea);
            }

            PointF[] placa =
            {
                new PointF(8f * k, yLinea - 12f * k),
                new PointF(54f * k, yLinea - 12f * k),
                new PointF(48f * k, yLinea + 2f * k),
                new PointF(2f * k, yLinea + 2f * k)
            };

            using (var relleno = new SolidBrush(Negro))
            using (var brochaEtiqueta = new SolidBrush(TemaPersona3.Cian))
            using (var fuenteEtiqueta = new Font("Segoe UI", Math.Max(6f, 8f * k),
                FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point))
            using (var formatoEtiqueta = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.FillPolygon(relleno, placa);
                g.DrawString("Guía", fuenteEtiqueta, brochaEtiqueta,
                    new RectangleF(4f * k, yLinea - 12f * k, 48f * k, 14f * k), formatoEtiqueta);
            }

            RectangleF zonaTexto = new RectangleF(0, 0, w - 6f * k, yLinea - 10f * k);

            using (var formato = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            })
            using (var sombra = new SolidBrush(Color.FromArgb(170, 3, 6, 20)))
            using (var brochaTexto = new SolidBrush(TemaPersona3.Blanco))
            {
                RectangleF zonaSombra = new RectangleF(zonaTexto.X + 1, zonaTexto.Y + 1,
                    zonaTexto.Width, zonaTexto.Height);

                g.DrawString(Text, Font, sombra, zonaSombra, formato);
                g.DrawString(Text, Font, brochaTexto, zonaTexto, formato);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fuenteInicial.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}