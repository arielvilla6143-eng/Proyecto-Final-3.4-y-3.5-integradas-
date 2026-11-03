//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public class MenuPersona3 : Control
    {
        private const float FilaBase = 48f;
        private const float AnchoBase = 230f;

        private string[] _items = new string[0];
        private float[] _bloque = new float[0];
        private float[] _hover = new float[0];
        private int _seleccionado = -1;
        private int _encima = -1;

        private readonly System.Windows.Forms.Timer _anim;
        private readonly System.Windows.Forms.Timer _animDesliza;
        private Font _fuente;
        private float _escalaFuente = -1f;

        private float _factor = 1f;
        private bool _expandido = true;
        private float _offsetX;
        private float _offsetObjetivo;

        public event EventHandler SelectedIndexChanged;
        public event EventHandler ExpandidoCambio;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<Graphics, Control> FondoExterno { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] Items
        {
            get { return _items; }
            set
            {
                _items = value ?? new string[0];
                _bloque = new float[_items.Length];
                _hover = new float[_items.Length];
                _seleccionado = -1;
                _encima = -1;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return _seleccionado; }
            set
            {
                if (value < -1 || value >= _items.Length || value == _seleccionado) return;

                _seleccionado = value;
                _anim.Start();
                Invalidate();

                if (SelectedIndexChanged != null)
                {
                    SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float FactorEscala
        {
            get { return _factor; }
            set
            {
                if (value <= 0f) return;
                _factor = value;

                if (_expandido)
                {
                    Width = AnchoCompleto;
                }

                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Expandido
        {
            get { return _expandido; }
        }

        private int AnchoCompleto
        {
            get { return (int)Math.Round(AnchoBase * _factor); }
        }

        public MenuPersona3()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Width = (int)AnchoBase;

            _anim = new System.Windows.Forms.Timer { Interval = 15 };
            _anim.Tick += Anim_Tick;

            _animDesliza = new System.Windows.Forms.Timer { Interval = 15 };
            _animDesliza.Tick += AnimDesliza_Tick;
        }

        public void Alternar()
        {
            _expandido = !_expandido;

            if (_expandido)
            {
                if (Width == 0)
                {
                    _offsetX = -AnchoCompleto;
                }

                Width = AnchoCompleto;
                _offsetObjetivo = 0f;
            }
            else
            {
                _offsetObjetivo = -AnchoCompleto;
            }

            _animDesliza.Start();

            if (ExpandidoCambio != null)
            {
                ExpandidoCambio(this, EventArgs.Empty);
            }
        }

        private void AnimDesliza_Tick(object sender, EventArgs e)
        {
            float dif = _offsetObjetivo - _offsetX;

            if (Math.Abs(dif) < 1f)
            {
                _offsetX = _offsetObjetivo;
                _animDesliza.Stop();

                if (!_expandido && Width != 0)
                {
                    Width = 0;
                }
            }
            else
            {
                _offsetX += dif * 0.28f;
            }

            Invalidate();
        }

        private void Anim_Tick(object sender, EventArgs e)
        {
            bool enMovimiento = false;

            for (int i = 0; i < _items.Length; i++)
            {
                float objetivoBloque = (i == _seleccionado) ? 1f : 0f;
                float objetivoHover = (i == _encima) ? 1f : 0f;

                _bloque[i] += (objetivoBloque - _bloque[i]) * 0.25f;
                _hover[i] += (objetivoHover - _hover[i]) * 0.30f;

                if (Math.Abs(objetivoBloque - _bloque[i]) < 0.01f) _bloque[i] = objetivoBloque;
                else enMovimiento = true;

                if (Math.Abs(objetivoHover - _hover[i]) < 0.01f) _hover[i] = objetivoHover;
                else enMovimiento = true;
            }

            if (!enMovimiento) _anim.Stop();

            Invalidate();
        }

        private int AlturaFila
        {
            get
            {
                if (_items.Length == 0) return 0;

                float tope = FilaBase * _factor;
                return (int)Math.Min(Height / (float)_items.Length, tope);
            }
        }

        private float Escala
        {
            get
            {
                float k = Math.Min(AlturaFila / FilaBase, _factor);
                return Math.Max(0.7f, Math.Min(2.4f, k));
            }
        }

        private int DesplazamientoY
        {
            get { return (Height - AlturaFila * _items.Length) / 2; }
        }

        private int ItemEn(Point p)
        {
            int fila = AlturaFila;
            if (fila == 0) return -1;

            if (p.X > Width + _offsetX) return -1;

            int y = p.Y - DesplazamientoY;
            if (y < 0) return -1;

            int i = y / fila;
            return i < _items.Length ? i : -1;
        }

        private Font FuenteActual(float escala)
        {
            if (_fuente == null || Math.Abs(escala - _escalaFuente) > 0.02f)
            {
                if (_fuente != null) _fuente.Dispose();

                _fuente = new Font("Segoe UI", 15F * escala,
                    FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                _escalaFuente = escala;
            }

            return _fuente;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int i = ItemEn(e.Location);
            if (i != _encima)
            {
                _encima = i;
                Cursor = (i >= 0) ? Cursors.Hand : Cursors.Default;
                _anim.Start();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _encima = -1;
            Cursor = Cursors.Default;
            _anim.Start();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            int i = ItemEn(e.Location);
            if (i >= 0)
            {
                SelectedIndex = i;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (FondoExterno != null)
            {
                FondoExterno(g, this);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            g.TranslateTransform(_offsetX, 0);

            using (var fondo = new SolidBrush(Color.FromArgb(70, 4, 10, 40)))
            using (var borde = new Pen(Color.FromArgb(120, 0, 212, 255), 1f))
            {
                g.FillRectangle(fondo, 0, 0, Width, Height);
                g.DrawLine(borde, Width - 1, 0, Width - 1, Height);
            }

            int n = _items.Length;
            int fila = AlturaFila;
            if (n == 0 || fila == 0) return;

            float k = Escala;
            Font fuente = FuenteActual(k);
            float sesgo = 14f * k;
            float desfaseSombra = 5f * k;
            int y0 = DesplazamientoY;

            float anchoCompleto = AnchoBase * _factor;

            using (var formato = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            })
            using (var brochaRoja = new SolidBrush(Color.FromArgb(230, 30, 60)))
            using (var brochaBlanca = new SolidBrush(TemaPersona3.Blanco))
            {
                for (int i = 0; i < n; i++)
                {
                    float arriba = y0 + i * fila + 2f * k;
                    float abajo = y0 + (i + 1) * fila - 2f * k;

                    float t = (n > 1) ? i / (float)(n - 1) : 0f;
                    float arco = (float)Math.Sin(t * Math.PI) * 16f * k;

                    if (_bloque[i] > 0.01f)
                    {
                        float x0 = 4f * k;
                        float ancho = Math.Max(sesgo * 2, (anchoCompleto - 14f * k) * _bloque[i]);

                        PointF[] sombra =
                        {
                            new PointF(x0 + sesgo + desfaseSombra, arriba + desfaseSombra),
                            new PointF(ancho + desfaseSombra, arriba + desfaseSombra),
                            new PointF(ancho - sesgo + desfaseSombra, abajo + 1f * k),
                            new PointF(x0 + desfaseSombra, abajo + 1f * k)
                        };
                        g.FillPolygon(brochaRoja, sombra);

                        PointF[] bloque =
                        {
                            new PointF(x0 + sesgo, arriba),
                            new PointF(ancho, arriba),
                            new PointF(ancho - sesgo, abajo - 4f * k),
                            new PointF(x0, abajo - 4f * k)
                        };
                        g.FillPolygon(brochaBlanca, bloque);
                    }

                    Color colorTexto = Mix(TemaPersona3.Cian, TemaPersona3.Blanco, _hover[i] * (1f - _bloque[i]));
                    colorTexto = Mix(colorTexto, TemaPersona3.AzulMarino, _bloque[i]);

                    float x = 14f * k + arco + _hover[i] * 8f * k;

                    using (var brochaTexto = new SolidBrush(colorTexto))
                    {
                        GraphicsState estado = g.Save();
                        g.TranslateTransform(x, (arriba + abajo) / 2f);
                        g.RotateTransform(-4f);
                        g.DrawString(_items[i], fuente, brochaTexto, 0, 0, formato);
                        g.Restore(estado);
                    }
                }
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
            if (disposing)
            {
                _anim.Dispose();
                _animDesliza.Dispose();
                if (_fuente != null) _fuente.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}