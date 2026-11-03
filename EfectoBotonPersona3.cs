//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public class EfectoBotonPersona3
    {
        private static readonly ConditionalWeakTable<Button, EfectoBotonPersona3> _aplicados =
            new ConditionalWeakTable<Button, EfectoBotonPersona3>();

        private static readonly Color Rojo = Color.FromArgb(230, 30, 60);

        private readonly Button _boton;
        private readonly System.Windows.Forms.Timer _anim;
        private readonly float _tamBase;

        private Font _fuente;
        private float _tamFuente = -1f;

        private float _progreso;
        private bool _encima;

        public static void Aplicar(Button boton)
        {
            EfectoBotonPersona3 existente;
            if (_aplicados.TryGetValue(boton, out existente)) return;

            _aplicados.Add(boton, new EfectoBotonPersona3(boton));
        }

        private EfectoBotonPersona3(Button boton)
        {
            _boton = boton;
            _tamBase = Math.Max(1f, boton.Font.SizeInPoints);

            _anim = new System.Windows.Forms.Timer { Interval = 15 };
            _anim.Tick += Anim_Tick;

            _boton.MouseEnter += (s, e) => { _encima = true; _anim.Start(); };
            _boton.MouseLeave += (s, e) => { _encima = false; _anim.Start(); };
            _boton.GotFocus += (s, e) => _anim.Start();
            _boton.LostFocus += (s, e) => _anim.Start();
            _boton.Paint += Boton_Paint;
            _boton.Disposed += (s, e) =>
            {
                _anim.Dispose();
                if (_fuente != null) _fuente.Dispose();
            };
        }

        private Font FuenteActual()
        {
            float factor = _boton.Font.SizeInPoints / _tamBase;
            float tam = 10.5f * factor;

            if (_fuente == null || Math.Abs(tam - _tamFuente) > 0.05f)
            {
                if (_fuente != null) _fuente.Dispose();

                _fuente = new Font("Segoe UI", tam, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                _tamFuente = tam;
            }

            return _fuente;
        }

        private void Anim_Tick(object sender, EventArgs e)
        {
            float objetivo = (_encima || _boton.Focused) ? 1f : 0f;
            _progreso += (objetivo - _progreso) * 0.25f;

            if (Math.Abs(objetivo - _progreso) < 0.01f)
            {
                _progreso = objetivo;
                _anim.Stop();
            }

            _boton.Invalidate();
        }

        private void Boton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            g.Clear(TemaPersona3.AzulMarino);

            int w = _boton.ClientSize.Width;
            int h = _boton.ClientSize.Height;
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
                using (var brochaRoja = new SolidBrush(Rojo))
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

            Color colorTexto = _boton.Enabled
                ? Mix(TemaPersona3.Cian, TemaPersona3.AzulMarino, _progreso)
                : Color.Gray;

            using (var brochaTexto = new SolidBrush(colorTexto))
            using (var formato = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                HotkeyPrefix = HotkeyPrefix.None
            })
            {
                g.TranslateTransform(w / 2f, h / 2f);
                g.RotateTransform(-4f);
                g.DrawString(_boton.Text, FuenteActual(), brochaTexto, 0, 0, formato);
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
    }
}