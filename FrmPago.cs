//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Windows.Forms;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1
{
    public partial class FrmPago : FrmBase, IPanelCRUD
    {
        public FrmPago()
        {
            InitializeComponent();

            ConfigurarCampoEntero(txtSancionPago, "ID de la sanción");
            ConfigurarCampoDecimal(txtMontoPago, "Monto", t => (double.TryParse(t, out double m) && m > 0) ? null : "El monto debe ser mayor a cero.");
            ConfigurarCampoLista(cmbMetodoPago, "Método de pago");
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Pago pago = CrearPagoDesdeControles();
                pago.InsertarRegistro(pago);

                MessageBox.Show("Pago guardado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarBuscar(string id, ErrorProvider alerta)
        {
            alerta.SetError(txtId, string.Empty);

            try
            {
                Pago pago = new Pago().ConsultarRegistro(id) as Pago;

                if (pago == null)
                {
                    alerta.SetError(txtId, "No existe un pago con ese id.");
                    return;
                }

                txtId.Text = pago.Id.ToString();
                txtSancionPago.Text = pago.IdSancion.ToString();
                txtMontoPago.Text = pago.Monto.ToString();
                dtpFechaPago.Value = pago.FechaPago;
                cmbMetodoPago.Text = pago.MetodoPago;
                chkEstadoPago.Checked = pago.EsActivo;
            }
            catch (ArgumentException ex)
            {
                alerta.SetError(txtId, ex.Message);
            }
        }

        public void EjecutarActualizar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Pago pago = CrearPagoDesdeControles();
                pago.ActualizarRegistro(pago);

                MessageBox.Show("Pago actualizado correctamente.", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "No se pudo actualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarEliminar(StatusStrip barraEstado)
        {
            // Validación: el ID es obligatorio antes de intentar eliminar
            if (!ValidarIdObligatorio())
            {
                MostrarEstado(barraEstado, "Escribe o busca el ID del registro que deseas eliminar.");
                return;
            }

            try
            {
                new Pago().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Pago eliminado correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MostrarEstado(barraEstado, ex.Message);
            }
        }

        private Pago CrearPagoDesdeControles()
        {
            int id = LeerEntero(txtId.Text, "El id del pago");
            int idSancion = LeerEntero(txtSancionPago.Text, "El id de la sanción");
            double monto = LeerDouble(txtMontoPago.Text, "El monto");

            Pago pago = new Pago()
            {
                Id = id,
                IdSancion = idSancion,
                Monto = monto,
                FechaPago = dtpFechaPago.Value,
                MetodoPago = cmbMetodoPago.Text,
                EsActivo = chkEstadoPago.Checked
            };

            return pago;
        }

        private int LeerEntero(string texto, string nombreCampo)
        {
            if (!int.TryParse(texto, out int valor))
                throw new FormatException(nombreCampo + " debe ser un número entero válido.");
            return valor;
        }

        private double LeerDouble(string texto, string nombreCampo)
        {
            if (!double.TryParse(texto, out double valor))
                throw new FormatException(nombreCampo + " debe ser un número válido.");
            return valor;
        }

        private void LimpiarControles()
        {
            LimpiarErrores();
            txtId.Clear();
            txtSancionPago.Clear();
            txtMontoPago.Clear();
            dtpFechaPago.Value = DateTime.Now;
            cmbMetodoPago.SelectedIndex = -1;
            chkEstadoPago.Checked = false;
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }
    }
}