//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equippo 2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public class FondoModulo
    {
        private readonly Form _form;
        private readonly string _titulo;
        private Bitmap _escena;

        public static void Aplicar(Form form, string titulo = null)
        {
            new FondoModulo(form, titulo);
        }

        private FondoModulo(Form form, string titulo)
        {
            _form = form;
            _titulo = titulo;
            _form.Paint += Form_Paint;
            _form.Resize += (s, e) => _form.Invalidate();
            _form.Disposed += (s, e) =>
            {
                if (_escena != null) _escena.Dispose();
            };
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = _form.ClientRectangle;
            if (r.Width == 0 || r.Height == 0) return;

            if (_escena == null || _escena.Width != r.Width || _escena.Height != r.Height)
            {
                CrearEscena(r.Size);
            }

            Rectangle clip = Rectangle.Intersect(e.ClipRectangle, r);
            if (clip.Width == 0 || clip.Height == 0) return;

            e.Graphics.DrawImage(_escena, clip, clip, GraphicsUnit.Pixel);
        }

        private void CrearEscena(Size tam)
        {
            if (_escena != null) _escena.Dispose();

            int w = tam.Width;
            int h = tam.Height;
            _escena = new Bitmap(w, h, PixelFormat.Format32bppPArgb);

            using (Graphics g = Graphics.FromImage(_escena))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (var degradado = new LinearGradientBrush(
                    new Rectangle(0, 0, w, h),
                    Color.FromArgb(10, 50, 130),
                    Color.FromArgb(4, 10, 40),
                    90f))
                {
                    g.FillRectangle(degradado, 0, 0, w, h);
                }

                float cx = w * 0.78f;
                float cy = h * 0.30f;
                float radio = Math.Min(w, h) * 0.20f;
                float radioHalo = radio * 2.4f;

                using (var rutaHalo = new GraphicsPath())
                {
                    rutaHalo.AddEllipse(cx - radioHalo, cy - radioHalo, radioHalo * 2, radioHalo * 2);
                    using (var halo = new PathGradientBrush(rutaHalo))
                    {
                        halo.CenterColor = Color.FromArgb(90, 190, 240, 255);
                        halo.SurroundColors = new[] { Color.FromArgb(0, 190, 240, 255) };
                        g.FillPath(halo, rutaHalo);
                    }
                }

                using (var disco = new SolidBrush(Color.FromArgb(45, 200, 245, 255)))
                using (var anillo = new Pen(Color.FromArgb(80, 200, 245, 255), 2f))
                {
                    g.FillEllipse(disco, cx - radio, cy - radio, radio * 2, radio * 2);
                    g.DrawEllipse(anillo, cx - radio, cy - radio, radio * 2, radio * 2);
                }

                DibujarTitulo(g, w, h);

                DibujarDunas(g, w, h, 0.90f, 0.030f, 0.010f, 0f, Color.FromArgb(110, 6, 18, 55));
                DibujarDunas(g, w, h, 0.94f, 0.025f, 0.014f, 2f, Color.FromArgb(150, 3, 9, 30));
            }
        }

        private GraphicsPath CrearRutaTitulo(FontFamily familia, float tamano)
        {
            var ruta = new GraphicsPath();
            ruta.AddString(
                _titulo,
                familia,
                (int)(FontStyle.Bold | FontStyle.Italic),
                tamano,
                new PointF(0, 0),
                StringFormat.GenericTypographic);
            return ruta;
        }

        private void DibujarTitulo(Graphics g, int w, int h)
        {
            if (string.IsNullOrEmpty(_titulo)) return;

            float tamano = h * 0.40f;

            using (var familia = new FontFamily("Segoe UI"))
            {
                GraphicsPath ruta = CrearRutaTitulo(familia, tamano);

                try
                {
                    RectangleF caja = ruta.GetBounds();

                    float limite = w * 0.95f;
                    if (caja.Width > limite)
                    {
                        tamano *= limite / caja.Width;
                        ruta.Dispose();
                        ruta = CrearRutaTitulo(familia, tamano);
                        caja = ruta.GetBounds();
                    }

                    GraphicsState estado = g.Save();

                    g.TranslateTransform(12f, h * 0.14f);
                    g.RotateTransform(-3f);
                    g.TranslateTransform(-caja.X, -caja.Y);

                    using (var relleno = new SolidBrush(Color.FromArgb(24, 255, 255, 255)))
                    using (var contorno = new Pen(Color.FromArgb(80, 0, 212, 255), 2f))
                    {
                        contorno.LineJoin = LineJoin.Round;
                        g.FillPath(relleno, ruta);
                        g.DrawPath(contorno, ruta);
                    }

                    g.Restore(estado);
                }
                finally
                {
                    ruta.Dispose();
                }
            }
        }

        private static void DibujarDunas(Graphics g, int w, int h,
            float nivel, float amplitud, float frecuencia, float fase, Color color)
        {
            int paso = 10;
            int puntos = w / paso + 2;
            PointF[] contorno = new PointF[puntos + 2];

            for (int i = 0; i < puntos; i++)
            {
                float x = i * paso;
                float y = h * nivel + (float)Math.Sin(x * frecuencia + fase) * h * amplitud;
                contorno[i] = new PointF(x, y);
            }

            contorno[puntos] = new PointF(w + paso, h);
            contorno[puntos + 1] = new PointF(0, h);

            using (var brocha = new SolidBrush(color))
            {
                g.FillPolygon(brocha, contorno);
            }
        }
    }
}