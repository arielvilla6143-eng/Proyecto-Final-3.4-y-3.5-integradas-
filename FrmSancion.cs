//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1
{
    public partial class FrmSancion : FrmBase, IPanelCRUD
    {
        public FrmSancion()
        {
            InitializeComponent();

            ConfigurarCampoEntero(txtIdUsuarioSancion, "ID del usuario");
            ConfigurarCampoEntero(txtIdPrestamoSancion, "ID del préstamo");
            ConfigurarCampoLetras(txtMotivoSancion, "Motivo");
            ConfigurarCampoEntero(txtDiasRetraso, "Días de retraso");
            ConfigurarCampoDecimal(txtPorcentajePenalizacion, "Porcentaje de penalización", t => (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out double p) && p >= 0 && p <= 1) ? null : "El porcentaje debe estar entre 0 y 1 (por ejemplo 0.20).");
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Sancion sancion = CrearSancionDesdeControles();
                sancion.InsertarRegistro(sancion);

                MessageBox.Show("Sanción guardada correctamente. Monto calculado: $" +
                                sancion.Monto.ToString("0.00"), "Guardar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarBuscar(string id, ErrorProvider alerta)
        {
            alerta.SetError(txtId, string.Empty);

            try
            {
                Sancion sancion = new Sancion().ConsultarRegistro(id) as Sancion;

                if (sancion == null)
                {
                    alerta.SetError(txtId, "No existe una sanción con ese id.");
                    return;
                }

                txtId.Text = sancion.Id.ToString();
                txtIdUsuarioSancion.Text = sancion.IdUsuario.ToString();
                txtIdPrestamoSancion.Text = sancion.IdPrestamo.ToString();
                txtMotivoSancion.Text = sancion.Motivo;
                txtDiasRetraso.Text = sancion.DiasRetraso.ToString();
                txtPorcentajePenalizacion.Text = sancion.PorcentajePenalizacionCondicion.ToString(CultureInfo.InvariantCulture);
                chkPagada.Checked = sancion.Pagada;
                chkEstadoSancion.Checked = sancion.EsActivo;
                lblMontoSancion.Text = "Monto: $" + sancion.Monto.ToString("0.00");
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
                Sancion sancion = CrearSancionDesdeControles();

                Sancion existente = new Sancion().ConsultarRegistro(txtId.Text) as Sancion;
                if (existente != null)
                {
                    sancion.FechaRegistro = existente.FechaRegistro;
                    sancion.FechaInicio = existente.FechaInicio;
                    sancion.FechaFinDesactivacion = existente.FechaFinDesactivacion;
                }

                sancion.ActualizarRegistro(sancion);
                lblMontoSancion.Text = "Monto: $" + sancion.Monto.ToString("0.00");

                MessageBox.Show("Sanción actualizada correctamente. Monto calculated: $" +
                                sancion.Monto.ToString("0.00"), "Actualizar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "No se pudo actualizar",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                new Sancion().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Sanción eliminada correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MostrarEstado(barraEstado, ex.Message);
            }
        }

        private Sancion CrearSancionDesdeControles()
        {
            int id = LeerEntero(txtId.Text, "El id");
            int idUsuario = LeerEntero(txtIdUsuarioSancion.Text, "El id del usuario");
            int idPrestamo = LeerEntero(txtIdPrestamoSancion.Text, "El id del préstamo");
            int diasRetraso = LeerEntero(txtDiasRetraso.Text, "Los días de retraso");
            double porcentaje = LeerDecimal(txtPorcentajePenalizacion.Text, "El porcentaje de recargo");

            Sancion sancion = new Sancion(id, idUsuario, idPrestamo, txtMotivoSancion.Text,
                                          diasRetraso, porcentaje, chkEstadoSancion.Checked);
            sancion.Pagada = chkPagada.Checked;
            return sancion;
        }

        private int LeerEntero(string texto, string nombreCampo)
        {
            if (!int.TryParse(texto, out int valor))
                throw new FormatException(nombreCampo + " debe ser un número entero.");
            return valor;
        }

        private double LeerDecimal(string texto, string nombreCampo)
        {
            string normalizado = texto.Trim().Replace(',', '.');
            if (!double.TryParse(normalizado, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor))
                throw new FormatException(nombreCampo + " debe ser un número (por ejemplo 0.20).");
            return valor;
        }

        private void LimpiarControles()
        {
            LimpiarErrores();
            txtId.Clear();
            txtIdUsuarioSancion.Clear();
            txtIdPrestamoSancion.Clear();
            txtMotivoSancion.Clear();
            txtDiasRetraso.Clear();
            txtPorcentajePenalizacion.Clear();
            chkPagada.Checked = false;
            chkEstadoSancion.Checked = false;
            lblMontoSancion.Text = "Monto: $0.00";
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }
    }
}