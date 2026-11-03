//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace SistemaBiblioteca1
{
    public class Menup : Control
    {
        private readonly System.Windows.Forms.Timer _anim;
        private float _hover;
        private float _abierto;
        private bool _encima;
        private bool _estaAbierto;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Abierto
        {
            get { return _estaAbierto; }
            set
            {
                if (_estaAbierto == value) return;
                _estaAbierto = value;
                _anim.Start();
            }
        }

        public Menup()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Size = new Size(64, 40);
            Cursor = Cursors.Hand;

            _anim = new System.Windows.Forms.Timer { Interval = 15 };
            _anim.Tick += Anim_Tick;
        }

        private void Anim_Tick(object sender, EventArgs e)
        {
            float objetivoHover = _encima ? 1f : 0f;
            float objetivoAbierto = _estaAbierto ? 1f : 0f;

            _hover += (objetivoHover - _hover) * 0.25f;
            _abierto += (objetivoAbierto - _abierto) * 0.25f;

            bool enMovimiento = false;

            if (Math.Abs(objetivoHover - _hover) < 0.01f) _hover = objetivoHover;
            else enMovimiento = true;

            if (Math.Abs(objetivoAbierto - _abierto) < 0.01f) _abierto = objetivoAbierto;
            else enMovimiento = true;

            if (!enMovimiento) _anim.Stop();

            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _encima = true;
            _anim.Start();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _encima = false;
            _anim.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(TemaPersona3.AzulMarino);

            int w = ClientSize.Width;
            int h = ClientSize.Height;
            if (w <= 4 || h <= 4) return;

            float sesgo = h * 0.35f;

            if (_hover > 0.01f)
            {
                float ancho = Math.Max(sesgo * 2, (w - 6) * _hover);

                PointF[] sombra =
                {
                    new PointF(sesgo + 5, 5),
                    new PointF(ancho + 5, 5),
                    new PointF(ancho - sesgo + 5, h - 1),
                    new PointF(5, h - 1)
                };
                using (var brochaRoja = new SolidBrush(Color.FromArgb(230, 30, 60)))
                {
                    g.FillPolygon(brochaRoja, sombra);
                }

                PointF[] bloque =
                {
                    new PointF(sesgo, 1),
                    new PointF(ancho, 1),
                    new PointF(ancho - sesgo, h - 5),
                    new PointF(0, h - 5)
                };
                using (var brochaBlanca = new SolidBrush(TemaPersona3.Blanco))
                {
                    g.FillPolygon(brochaBlanca, bloque);
                }
            }
            else
            {
                using (var lapiz = new Pen(TemaPersona3.Cian, 2))
                {
                    g.DrawLine(lapiz, 0, h - 2, w, h - 2);
                }
            }

            Color colorLinea = Mix(TemaPersona3.Cian, TemaPersona3.AzulMarino, _hover);
            float grosor = Math.Max(2.5f, h * 0.075f);
            float largo = h * 0.30f;
            float espacio = h * 0.20f;
            float cx = w / 2f;
            float cy = (h - 4) / 2f;

            float t = _abierto;
            float desplaza = espacio * (1f - t);

            using (var lapizLinea = new Pen(colorLinea, grosor))
            {
                lapizLinea.StartCap = LineCap.Round;
                lapizLinea.EndCap = LineCap.Round;

                DibujarRaya(g, lapizLinea, cx, cy - desplaza, largo, 45f * t);
                DibujarRaya(g, lapizLinea, cx, cy + desplaza, largo, -45f * t);
            }

            if (t < 0.99f)
            {
                int alfa = (int)(255 * (1f - t));
                using (var lapizCentral = new Pen(Color.FromArgb(alfa, colorLinea), grosor))
                {
                    lapizCentral.StartCap = LineCap.Round;
                    lapizCentral.EndCap = LineCap.Round;
                    DibujarRaya(g, lapizCentral, cx, cy, largo, 0f);
                }
            }
        }

        private static void DibujarRaya(Graphics g, Pen lapiz, float x, float y, float largo, float angulo)
        {
            g.TranslateTransform(x, y);
            g.RotateTransform(angulo);
            g.DrawLine(lapiz, -largo, 0, largo, 0);
            g.ResetTransform();
        }

        private static Color Mix(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _anim.Dispose();
            base.Dispose(disposing);
        }
    }
}