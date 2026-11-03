//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public partial class FrmBase : Form
    {
        private enum TipoCampo
        {
            Texto,
            Letras,
            Entero,
            Decimal
        }

        private class ReglaCampo
        {
            public string Nombre = "";
            public TipoCampo Tipo = TipoCampo.Texto;
            public bool Obligatorio = true;
            public Func<string, string?>? ReglaExtra = null;
        }

        private readonly Dictionary<Control, ReglaCampo> reglas = new Dictionary<Control, ReglaCampo>();

        public FrmBase()
        {
            InitializeComponent();

            ConfigurarCampoEntero(txtId, "ID");
        }

        protected void ConfigurarCampoLetras(TextBox txt, string nombreCampo, bool obligatorio = true)
        {
            RegistrarRegla(txt, nombreCampo, TipoCampo.Letras, obligatorio, null);
            txt.KeyPress += SoloLetras_KeyPress;
            txt.Validating += Campo_Validating;
            txt.TextChanged += Campo_Cambio;
        }

        protected void ConfigurarCampoTexto(TextBox txt, string nombreCampo, Func<string, string?>? reglaExtra = null)
        {
            RegistrarRegla(txt, nombreCampo, TipoCampo.Texto, true, reglaExtra);
            txt.Validating += Campo_Validating;
            txt.TextChanged += Campo_Cambio;
        }

        protected void ConfigurarCampoEntero(TextBox txt, string nombreCampo, Func<string, string?>? reglaExtra = null)
        {
            RegistrarRegla(txt, nombreCampo, TipoCampo.Entero, true, reglaExtra);
            txt.KeyPress += SoloNumeros_KeyPress;
            txt.Validating += Campo_Validating;
            txt.TextChanged += Campo_Cambio;
        }

        protected void ConfigurarCampoDecimal(TextBox txt, string nombreCampo, Func<string, string?>? reglaExtra = null)
        {
            RegistrarRegla(txt, nombreCampo, TipoCampo.Decimal, true, reglaExtra);
            txt.KeyPress += NumeroDecimal_KeyPress;
            txt.Validating += Campo_Validating;
            txt.TextChanged += Campo_Cambio;
        }

        protected void ConfigurarCampoLista(ComboBox cmb, string nombreCampo)
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            RegistrarRegla(cmb, nombreCampo, TipoCampo.Texto, true, null);
            cmb.Validating += Campo_Validating;
            cmb.SelectedIndexChanged += Campo_Cambio;
        }

        private void RegistrarRegla(Control control, string nombreCampo, TipoCampo tipo,
                                    bool obligatorio, Func<string, string?>? reglaExtra)
        {
            ReglaCampo regla = new ReglaCampo();
            regla.Nombre = nombreCampo;
            regla.Tipo = tipo;
            regla.Obligatorio = obligatorio;
            regla.ReglaExtra = reglaExtra;
            reglas[control] = regla;
        }

        private void SoloLetras_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void NumeroDecimal_KeyPress(object? sender, KeyPressEventArgs e)
        {
            TextBox? txt = sender as TextBox;
            if (txt == null)
                return;

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                bool yaTienePunto = txt.Text.Contains('.') && !txt.SelectedText.Contains('.');
                if (!yaTienePunto)
                    return;
            }

            e.Handled = true;
            SystemSounds.Beep.Play();
        }

        private void Campo_Validating(object? sender, CancelEventArgs e)
        {
            Control? control = sender as Control;
            if (control == null)
                return;

            string? mensaje = ObtenerMensajeError(control);

            if (mensaje != null)
            {
                epValidaciones.SetError(control, mensaje);
                e.Cancel = true;
            }
            else
            {
                epValidaciones.SetError(control, "");
            }
        }

        private void Campo_Cambio(object? sender, EventArgs e)
        {
            Control? control = sender as Control;
            if (control == null)
                return;

            if (epValidaciones.GetError(control) != "" && ObtenerMensajeError(control) == null)
                epValidaciones.SetError(control, "");
        }

        private string? ObtenerMensajeError(Control control)
        {
            if (!reglas.TryGetValue(control, out ReglaCampo? regla))
                return null;

            if (control is ComboBox combo)
            {
                if (combo.SelectedIndex == -1)
                    return "Seleccione una opción en '" + regla.Nombre + "'.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(control.Text))
            {
                if (regla.Obligatorio)
                    return "El campo '" + regla.Nombre + "' es obligatorio.";
                return null;
            }

            string texto = control.Text.Trim();

            if (regla.Tipo == TipoCampo.Letras)
            {
                foreach (char c in texto)
                {
                    if (!char.IsLetter(c) && c != ' ')
                        return "'" + regla.Nombre + "' solo admite letras.";
                }
            }
            else if (regla.Tipo == TipoCampo.Entero)
            {
                foreach (char c in texto)
                {
                    if (!char.IsDigit(c))
                        return "'" + regla.Nombre + "' solo admite números.";
                }
            }
            else if (regla.Tipo == TipoCampo.Decimal)
            {
                int puntos = 0;
                int digitos = 0;
                foreach (char c in texto)
                {
                    if (c == '.')
                        puntos++;
                    else if (char.IsDigit(c))
                        digitos++;
                    else
                        return "'" + regla.Nombre + "' solo admite números y un punto decimal.";
                }
                if (puntos > 1 || digitos == 0)
                    return "'" + regla.Nombre + "' no es un número decimal válido.";
            }

            if (regla.ReglaExtra != null)
                return regla.ReglaExtra(texto);

            return null;
        }

        protected bool ValidarFormulario()
        {
            bool hayErrores = false;

            if (!this.ValidateChildren())
                hayErrores = true;

            Control? primerConError = BuscarControlConError(this);
            if (primerConError != null)
                hayErrores = true;

            if (hayErrores)
            {
                MessageBox.Show("Hay campos con errores. Corríjalos antes de continuar.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                primerConError?.Focus();
                return false;
            }

            return true;
        }

        private Control? BuscarControlConError(Control contenedor)
        {
            foreach (Control hijo in contenedor.Controls)
            {
                if (epValidaciones.GetError(hijo) != "")
                    return hijo;

                Control? interno = BuscarControlConError(hijo);
                if (interno != null)
                    return interno;
            }
            return null;
        }

        protected bool ValidarIdObligatorio()
        {
            string? mensaje = ObtenerMensajeError(txtId);

            if (mensaje != null)
            {
                epValidaciones.SetError(txtId, mensaje);
                txtId.Focus();
                return false;
            }

            epValidaciones.SetError(txtId, "");
            return true;
        }

        protected void LimpiarErrores() { 
            {
            epValidaciones.Clear();
            }
        }
        private void pnlFormularioBase_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}