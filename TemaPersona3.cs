using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public static class TemaPersona3
    {
        public static readonly Color AzulMarino = ColorTranslator.FromHtml("#0A1128");
        public static readonly Color Cian = ColorTranslator.FromHtml("#00D4FF");
        public static readonly Color Blanco = Color.White;

        private static readonly Color AzulControl = ColorTranslator.FromHtml("#14214A");

        private static readonly Color FondoBarra = Color.FromArgb(3, 6, 20);

        private static readonly Font FuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold);
        private static readonly Font FuenteEstado = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);

        private class ColoresBarraEstado : ProfessionalColorTable
        {
            public override Color StatusStripGradientBegin { get { return FondoBarra; } }
            public override Color StatusStripGradientEnd { get { return FondoBarra; } }
        }

        public static void Aplicar(Form formulario)
        {
            formulario.BackColor = AzulMarino;
            formulario.ForeColor = Blanco;
            ActivarDobleBuffer(formulario);

            AplicarARecursivo(formulario.Controls);
        }

        private static void AplicarARecursivo(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is BotonPersona3)
                {
                }
                else if (c is Button boton)
                {
                    EstilizarBoton(boton);
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = AzulControl;
                    txt.ForeColor = Blanco;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cmb)
                {
                    cmb.BackColor = AzulControl;
                    cmb.ForeColor = Blanco;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is NumericUpDown num)
                {
                    num.BackColor = AzulControl;
                    num.ForeColor = Blanco;
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.ForeColor = Color.Black;
                    dtp.CalendarMonthBackground = AzulControl;
                    dtp.CalendarForeColor = Blanco;
                    dtp.CalendarTitleBackColor = Cian;
                    dtp.CalendarTitleForeColor = AzulMarino;
                }
                else if (c is ListBox lst)
                {
                    lst.BackColor = AzulControl;
                    lst.ForeColor = Blanco;
                    lst.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is DataGridView dgv)
                {
                    EstilizarGrid(dgv);
                    ActivarDobleBuffer(dgv);
                }
                else if (c is CheckBox || c is RadioButton)
                {
                    c.ForeColor = Blanco;
                    c.BackColor = Color.Transparent;
                }
                else if (c is Label lbl)
                {
                    PlacaPersona3.Aplicar(lbl);
                }
                else if (c is StatusStrip barra)
                {
                    EstilizarBarraEstado(barra);
                }
                else if (c is Panel || c is GroupBox)
                {
                    c.BackColor = Color.FromArgb(90, 10, 17, 40);
                    c.ForeColor = Blanco;
                    ActivarDobleBuffer(c);
                }

                if (c.HasChildren)
                {
                    AplicarARecursivo(c.Controls);
                }
            }
        }
        private static void ActivarDobleBuffer(Control c)
        {
            PropertyInfo prop = typeof(Control).GetProperty(
                "DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            if (prop != null)
            {
                prop.SetValue(c, true, null);
            }
        }

        private static void EstilizarBarraEstado(StatusStrip barra)
        {
            barra.BackColor = FondoBarra;
            barra.SizingGrip = false;
            barra.Renderer = new ToolStripProfessionalRenderer(new ColoresBarraEstado())
            {
                RoundedEdges = false
            };

            foreach (ToolStripItem item in barra.Items)
            {
                item.ForeColor = Cian;
                item.BackColor = Color.Transparent;
                item.Font = FuenteEstado;
            }

            barra.Paint -= BarraEstado_Paint;
            barra.Paint += BarraEstado_Paint;
        }

        private static void BarraEstado_Paint(object sender, PaintEventArgs e)
        {
            Control barra = (Control)sender;

            using (var linea = new Pen(Cian, 2f))
            {
                e.Graphics.DrawLine(linea, 0, 1, barra.Width, 1);
            }
        }

        private static void EstilizarBoton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = AzulMarino;
            b.ForeColor = Cian;
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = AzulMarino;
            b.FlatAppearance.MouseDownBackColor = AzulMarino;

            EfectoBotonPersona3.Aplicar(b);
        }

        private static void EstilizarGrid(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = AzulMarino;
            g.EnableHeadersVisualStyles = false;
            g.GridColor = Cian;
            g.RowHeadersVisible = false;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            g.ColumnHeadersDefaultCellStyle.BackColor = Cian;
            g.ColumnHeadersDefaultCellStyle.ForeColor = AzulMarino;
            g.ColumnHeadersDefaultCellStyle.Font = FuenteTitulo;
            g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 30;

            g.DefaultCellStyle.BackColor = AzulMarino;
            g.DefaultCellStyle.ForeColor = Blanco;
            g.DefaultCellStyle.SelectionBackColor = Cian;
            g.DefaultCellStyle.SelectionForeColor = AzulMarino;
        }
    }
}