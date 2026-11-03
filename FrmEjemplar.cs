//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Windows.Forms;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1
{
    public partial class FrmEjemplar : FrmBase, IPanelCRUD
    {
        public FrmEjemplar()
        {
            InitializeComponent();

            ConfigurarCampoEntero(txtIdLIbroEjemplar, "ID del libro");
            ConfigurarCampoTexto(txtCodigoInventario, "Código de inventario");
            txtCodigoInventario.MaxLength = 12;
            ConfigurarCampoLista(cmbCondicion, "Condición");
        }

        private void FrmEjemplar_Load(object sender, EventArgs e)
        {
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Ejemplar ejemplar = CrearEjemplarDesdeControles();
                ejemplar.InsertarRegistro(ejemplar);

                MessageBox.Show("Ejemplar guardado correctamente.", "Guardar",
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
                Ejemplar ejemplar = new Ejemplar().ConsultarRegistro(id) as Ejemplar;

                if (ejemplar == null)
                {
                    alerta.SetError(txtId, "No existe un ejemplar con ese id.");
                    return;
                }

                txtId.Text = ejemplar.Id.ToString();
                txtIdLIbroEjemplar.Text = ejemplar.IdLibro.ToString();
                txtCodigoInventario.Text = ejemplar.CodigoInventario;
                cmbCondicion.Text = ejemplar.Condicion;
                chkDisponible.Checked = ejemplar.Disponible;
                chkEstadoEjemplar.Checked = ejemplar.EsActivo;
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
                Ejemplar ejemplar = CrearEjemplarDesdeControles();
                ejemplar.ActualizarRegistro(ejemplar);

                MessageBox.Show("Ejemplar actualizado correctamente.", "Actualizar",
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
                new Ejemplar().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Ejemplar eliminado correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MostrarEstado(barraEstado, ex.Message);
            }
        }

        private Ejemplar CrearEjemplarDesdeControles()
        {
            int id = LeerEntero(txtId.Text, "El id del ejemplar");
            int idLibro = LeerEntero(txtIdLIbroEjemplar.Text, "El id del libro");

            Ejemplar ejemplar = new Ejemplar()
            {
                Id = id,
                IdLibro = idLibro,
                CodigoInventario = txtCodigoInventario.Text,
                Condicion = cmbCondicion.Text,
                Disponible = chkDisponible.Checked,
                EsActivo = chkEstadoEjemplar.Checked
            };

            return ejemplar;
        }

        private int LeerEntero(string texto, string nombreCampo)
        {
            if (!int.TryParse(texto, out int valor))
                throw new FormatException(nombreCampo + " debe ser un número entero.");
            return valor;
        }

        private void LimpiarControles()
        {
            LimpiarErrores();
            txtId.Clear();
            txtIdLIbroEjemplar.Clear();
            txtCodigoInventario.Clear();
            cmbCondicion.SelectedIndex = -1;
            chkDisponible.Checked = false;
            chkEstadoEjemplar.Checked = false;
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }
    }
}