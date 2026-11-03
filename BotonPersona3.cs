//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SistemaBiblioteca1
{
    public class BotonPersona3 : Button
    {
        private readonly Timer _anim;
        private float _progreso;
        private bool _encima;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ColorAcento { get; set; } = Color.FromArgb(230, 30, 60);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Inclinacion { get; set; } = -4f;

        public BotonPersona3()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 11F, FontStyle.Bold | FontStyle.Italic);

            _anim = new Timer { Interval = 15 };
            _anim.Tick += Anim_Tick;
        }

        private void Anim_Tick(object sender, EventArgs e)
        {
            float objetivo = (_encima || Focused) ? 1f : 0f;
            _progreso += (objetivo - _progreso) * 0.25f;

            if (Math.Abs(objetivo - _progreso) < 0.01f)
            {
                _progreso = objetivo;
                _anim.Stop();
            }

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

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _anim.Start();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _anim.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.Clear(TemaPersona3.AzulMarino);

            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int sesgo = 14;

            if (_progreso > 0.01f)
            {
                float ancho = Math.Max(sesgo * 2, (w - 6) * _progreso);

                PointF[] sombra =
                {
                    new PointF(sesgo + 5, 5),
                    new PointF(ancho + 5, 5),
                    new PointF(ancho - sesgo + 5, h - 1),
                    new PointF(5, h - 1)
                };
                using (var brochaRoja = new SolidBrush(ColorAcento))
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

            Color colorTexto = Enabled
                ? Mix(TemaPersona3.Cian, TemaPersona3.AzulMarino, _progreso)
                : Color.Gray;

            using (var brochaTexto = new SolidBrush(colorTexto))
            using (var formato = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.TranslateTransform(w / 2f, h / 2f);
                g.RotateTransform(Inclinacion);
                g.DrawString(Text, Font, brochaTexto, 0, 0, formato);
                g.ResetTransform();
            }
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