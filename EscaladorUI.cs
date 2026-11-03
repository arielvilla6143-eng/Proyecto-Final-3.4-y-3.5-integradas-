//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public class EscaladorUI
    {
        private class Elemento
        {
            public Control Control;
            public Rectangle Original;
            public bool EscalarTamano;
            public bool EscalarFuente;
            public Font FuenteOriginal;
            public Font FuenteCreada;

            public int AltoEncabezado;
            public int AltoFila;
            public int[] Anchos;
            public Font FuenteEncabezadoOriginal;
            public Font FuenteEncabezadoCreada;
        }

        private readonly Control _raiz;
        private readonly Size _referencia;
        private readonly float _escalaMin;
        private readonly float _escalaMax;
        private readonly List<Elemento> _elementos = new List<Elemento>();
        private float _escalaActual = 1f;

        public float Escala
        {
            get { return _escalaActual; }
        }

        public event EventHandler EscalaCambio;

        public static EscaladorUI Aplicar(Control raiz, float escalaMin = 0.85f, float escalaMax = 2.5f)
        {
            return new EscaladorUI(raiz, escalaMin, escalaMax);
        }

        private EscaladorUI(Control raiz, float escalaMin, float escalaMax)
        {
            _raiz = raiz;
            _referencia = raiz.ClientSize;
            _escalaMin = escalaMin;
            _escalaMax = escalaMax;

            Registrar(raiz.Controls);

            raiz.Resize += (s, e) => Reescalar();
            raiz.Disposed += (s, e) => LiberarFuentes();

            Reescalar();
        }

        private static int R(float valor)
        {
            return (int)Math.Round(valor);
        }

        private void Registrar(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is Form) continue;

                if (c is StatusStrip) continue;

                if (c is MenuPersona3) continue;

                var el = new Elemento { Control = c, Original = c.Bounds };

                bool contenedor = c is Panel || c is GroupBox || c is Menup;
                el.EscalarFuente = !contenedor;
                el.FuenteOriginal = c.Font;

                bool seAjustaSolo = c.AutoSize && (c is Label || c is CheckBox || c is RadioButton);
                el.EscalarTamano = c.Dock == DockStyle.None && !seAjustaSolo;

                if (c.Dock == DockStyle.None)
                {
                    c.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }

                DataGridView g = c as DataGridView;
                if (g != null)
                {
                    el.AltoEncabezado = g.ColumnHeadersHeight;
                    el.AltoFila = g.RowTemplate.Height;
                    el.Anchos = new int[g.Columns.Count];
                    for (int i = 0; i < g.Columns.Count; i++)
                    {
                        el.Anchos[i] = g.Columns[i].Width;
                    }
                    el.FuenteEncabezadoOriginal = g.ColumnHeadersDefaultCellStyle.Font ?? g.Font;
                }

                _elementos.Add(el);

                if (c.HasChildren)
                {
                    Registrar(c.Controls);
                }
            }
        }

        private void Reescalar()
        {
            Size actual = _raiz.ClientSize;
            if (_referencia.Width <= 0 || _referencia.Height <= 0) return;
            if (actual.Width <= 0 || actual.Height <= 0) return;

            float s = Math.Min(
                (float)actual.Width / _referencia.Width,
                (float)actual.Height / _referencia.Height);

            s = Math.Max(_escalaMin, Math.Min(_escalaMax, s));
            s = (float)(Math.Round(s * 20.0) / 20.0);

            if (Math.Abs(s - _escalaActual) < 0.001f)
                return;
            _escalaActual = s;

            _raiz.SuspendLayout();

            foreach (Elemento el in _elementos)
            {
                AplicarEscala(el, s);
            }

            _raiz.ResumeLayout(true);

            if (EscalaCambio != null)
            {
                EscalaCambio(this, EventArgs.Empty);
            }
        }

        private void AplicarEscala(Elemento el, float s)
        {
            Control c = el.Control;
            Rectangle o = el.Original;

            switch (c.Dock)
            {
                case DockStyle.None:
                    if (el.EscalarTamano)
                    {
                        c.SetBounds(R(o.X * s), R(o.Y * s), R(o.Width * s), R(o.Height * s));
                    }
                    else
                    {
                        c.Location = new Point(R(o.X * s), R(o.Y * s));
                    }
                    break;

                case DockStyle.Top:
                case DockStyle.Bottom:
                    c.Height = R(o.Height * s);
                    break;

                case DockStyle.Left:
                case DockStyle.Right:
                    c.Width = R(o.Width * s);
                    break;
            }

            if (el.EscalarFuente && el.FuenteOriginal != null)
            {
                Font nueva = new Font(
                    el.FuenteOriginal.FontFamily,
                    el.FuenteOriginal.SizeInPoints * s,
                    el.FuenteOriginal.Style,
                    GraphicsUnit.Point);

                Font anterior = el.FuenteCreada;
                c.Font = nueva;
                el.FuenteCreada = nueva;

                if (anterior != null) anterior.Dispose();
            }

            DataGridView g = c as DataGridView;
            if (g != null)
            {
                EscalarGrid(el, g, s);
            }
        }

        private void EscalarGrid(Elemento el, DataGridView g, float s)
        {
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = Math.Max(20, R(el.AltoEncabezado * s));

            int alto = Math.Max(18, R(el.AltoFila * s));
            g.RowTemplate.Height = alto;
            foreach (DataGridViewRow fila in g.Rows)
            {
                fila.Height = alto;
            }

            for (int i = 0; i < g.Columns.Count && i < el.Anchos.Length; i++)
            {
                DataGridViewColumn col = g.Columns[i];
                if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet ||
                    col.AutoSizeMode == DataGridViewAutoSizeColumnMode.None)
                {
                    col.Width = Math.Max(20, R(el.Anchos[i] * s));
                }
            }

            if (el.FuenteEncabezadoOriginal != null)
            {
                Font nueva = new Font(
                    el.FuenteEncabezadoOriginal.FontFamily,
                    el.FuenteEncabezadoOriginal.SizeInPoints * s,
                    el.FuenteEncabezadoOriginal.Style,
                    GraphicsUnit.Point);

                Font anterior = el.FuenteEncabezadoCreada;
                g.ColumnHeadersDefaultCellStyle.Font = nueva;
                el.FuenteEncabezadoCreada = nueva;

                if (anterior != null) anterior.Dispose();
            }
        }

        private void LiberarFuentes()
        {
            foreach (Elemento el in _elementos)
            {
                if (el.FuenteCreada != null) el.FuenteCreada.Dispose();
                if (el.FuenteEncabezadoCreada != null) el.FuenteEncabezadoCreada.Dispose();
            }
        }
    }
}