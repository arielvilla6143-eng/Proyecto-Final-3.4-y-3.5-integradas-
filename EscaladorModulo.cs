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
    public class EscaladorModulo
    {
        private const int MargenDiseno = 12;
        private const float EscalaMin = 0.6f;
        private const float EscalaMax = 3.0f;
        private const float AltoBarraBase = 56f;
        private const float FraccionMaxBarra = 0.12f;

        private class Elemento
        {
            public Control Control;
            public Rectangle Original;
            public bool EsRaiz;
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

        private readonly Form _modulo;
        private readonly BarraAccionesPersona3 _barra;
        private readonly List<Elemento> _elementos = new List<Elemento>();
        private readonly int _anchoContenido;
        private readonly int _altoContenido;

        private float _escala = -1f;
        private float _escalaBarra = -1f;
        private int _offX = int.MinValue;
        private int _offY = int.MinValue;
        private bool _aplicando;

        public static EscaladorModulo Aplicar(Form modulo)
        {
            return new EscaladorModulo(modulo);
        }

        private EscaladorModulo(Form modulo)
        {
            _modulo = modulo;

            foreach (Control c in modulo.Controls)
            {
                BarraAccionesPersona3 barra = c as BarraAccionesPersona3;
                if (barra != null)
                {
                    _barra = barra;
                    break;
                }
            }

            int maxDerecha = 0;
            int maxAbajo = 0;
            Medir(modulo.Controls, true, ref maxDerecha, ref maxAbajo);

            _anchoContenido = maxDerecha + MargenDiseno;
            _altoContenido = maxAbajo + MargenDiseno;

            if (maxDerecha == 0 || maxAbajo == 0) return;

            Registrar(modulo.Controls, true);

            modulo.Resize += (s, e) => Reescalar();
            modulo.Disposed += (s, e) => LiberarFuentes();

            Reescalar();
        }

        private static int R(float valor)
        {
            return (int)Math.Round(valor);
        }

        private static float Paso(float valor)
        {
            return (float)(Math.Floor(valor * 20.0) / 20.0);
        }

        private static float Limitar(float valor)
        {
            return Math.Max(EscalaMin, Math.Min(EscalaMax, valor));
        }

        private static bool EsAnfitrion(Control c, bool raiz)
        {
            return raiz && c.Dock == DockStyle.Fill && c is ScrollableControl && c.HasChildren;
        }

        private static void Medir(Control.ControlCollection controles, bool raiz,
            ref int maxDerecha, ref int maxAbajo)
        {
            foreach (Control c in controles)
            {
                if (c is BarraAccionesPersona3 || c is StatusStrip || c is Form) continue;

                if (EsAnfitrion(c, raiz))
                {
                    Medir(c.Controls, true, ref maxDerecha, ref maxAbajo);
                    continue;
                }

                if (c.Dock != DockStyle.None) continue;

                maxDerecha = Math.Max(maxDerecha, c.Right);
                maxAbajo = Math.Max(maxAbajo, c.Bottom);
            }
        }

        private void Registrar(Control.ControlCollection controles, bool raiz)
        {
            foreach (Control c in controles)
            {
                if (c is Form || c is StatusStrip || c is BarraAccionesPersona3) continue;

                if (EsAnfitrion(c, raiz))
                {
                    Registrar(c.Controls, true);
                    continue;
                }

                var el = new Elemento
                {
                    Control = c,
                    Original = c.Bounds,
                    EsRaiz = raiz && c.Dock == DockStyle.None
                };

                bool contenedor = c is Panel || c is GroupBox;
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
                    Registrar(c.Controls, false);
                }
            }
        }

        private void Reescalar()
        {
            if (_aplicando) return;

            int w = _modulo.ClientSize.Width;
            int h = _modulo.ClientSize.Height;
            if (w <= 0 || h <= 0) return;

            float sBarra = 1f;
            float altoBarra = 0f;

            if (_barra != null)
            {
                sBarra = Math.Min(w / (float)_barra.AnchoBase, FraccionMaxBarra * h / AltoBarraBase);
                sBarra = Paso(Limitar(sBarra));
                altoBarra = AltoBarraBase * sBarra;
            }

            float sAncho = w / (float)_anchoContenido;
            float sAlto = (h - altoBarra) / _altoContenido;
            float s = Paso(Limitar(Math.Min(sAncho, sAlto)));

            int offX = Math.Max(0, (int)((w - _anchoContenido * s) / 2f));
            int offY = Math.Max(0, (int)((h - altoBarra - _altoContenido * s) / 2f));

            bool cambioContenido = Math.Abs(s - _escala) > 0.001f;
            bool cambioBarra = Math.Abs(sBarra - _escalaBarra) > 0.001f;

            if (!cambioContenido && !cambioBarra && offX == _offX && offY == _offY) return;

            _aplicando = true;
            _modulo.SuspendLayout();

            try
            {
                _escala = s;
                _escalaBarra = sBarra;
                _offX = offX;
                _offY = offY;

                if (_barra != null && cambioBarra)
                {
                    _barra.Escala = sBarra;
                }

                foreach (Elemento el in _elementos)
                {
                    if (!cambioContenido && !el.EsRaiz) continue;

                    AplicarEscala(el, s, !cambioContenido);
                }
            }
            finally
            {
                _modulo.ResumeLayout(true);
                _aplicando = false;
            }
        }

        private void AplicarEscala(Elemento el, float s, bool soloPosicion)
        {
            Control c = el.Control;
            Rectangle o = el.Original;

            int x = R(o.X * s);
            int y = R(o.Y * s);

            if (el.EsRaiz)
            {
                x += _offX;
                y += _offY;
            }

            if (soloPosicion)
            {
                c.Location = new Point(x, y);
                return;
            }

            switch (c.Dock)
            {
                case DockStyle.None:
                    if (el.EscalarTamano)
                    {
                        c.SetBounds(x, y, R(o.Width * s), R(o.Height * s));
                    }
                    else
                    {
                        c.Location = new Point(x, y);
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