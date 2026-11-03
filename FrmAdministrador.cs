//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Windows.Forms;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1
{
    public partial class FrmAdministrador : FrmBase, IPanelCRUD
    {
        public FrmAdministrador()
        {

            InitializeComponent();

            ConfigurarCampoLetras(txtNombreAdmin, "Nombre");
            ConfigurarCampoLetras(txtApellidoAdmin, "Apellido");
            ConfigurarCampoTexto(txtUsuarioAcceso, "Usuario de acceso");
            ConfigurarCampoTexto(txtContrasena, "Contraseña");
            ConfigurarCampoLista(cmbNivelAcceso, "Nivel de acceso");
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Administrador admin = CrearAdminDesdeControles();
                admin.InsertarRegistro(admin);

                MessageBox.Show("Administrador guardado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Administrador admin = new Administrador().ConsultarRegistro(id) as Administrador;

                if (admin == null)
                {
                    alerta.SetError(txtId, "No existe un administrador con ese id.");
                    return;
                }

                txtId.Text = admin.Id.ToString();
                txtNombreAdmin.Text = admin.Nombre;
                txtApellidoAdmin.Text = admin.Apellido;
                txtUsuarioAcceso.Text = admin.UsuarioAcceso;
                txtContrasena.Text = admin.Contrasena;
                cmbNivelAcceso.Text = admin.NivelAcceso.ToString();
                chkEstadoAdmin.Checked = admin.EsActivo;
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
                Administrador admin = CrearAdminDesdeControles();
                admin.ActualizarRegistro(admin);

                MessageBox.Show("Administrador actualizado correctamente.", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                new Administrador().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Administrador eliminado correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MostrarEstado(barraEstado, ex.Message);
            }
        }

        private Administrador CrearAdminDesdeControles()
        {
            int id = LeerEntero(txtId.Text, "El id del administrador");

            int nivelAcceso = 1;
            if (!string.IsNullOrEmpty(cmbNivelAcceso.Text))
            {
                nivelAcceso = LeerEntero(cmbNivelAcceso.Text, "El nivel de acceso");
            }

            Administrador admin = new Administrador()
            {
                Id = id,
                Nombre = txtNombreAdmin.Text,
                Apellido = txtApellidoAdmin.Text,
                UsuarioAcceso = txtUsuarioAcceso.Text,
                Contrasena = txtContrasena.Text,
                NivelAcceso = nivelAcceso,
                EsActivo = chkEstadoAdmin.Checked
            };

            return admin;
        }

        private int LeerEntero(string texto, string nombreCampo)
        {
            if (!int.TryParse(texto, out int valor))
                throw new FormatException(nombreCampo + " debe ser un número entero válido.");
            return valor;
        }

        private void LimpiarControles()
        {
            LimpiarErrores();
            txtId.Clear();
            txtNombreAdmin.Clear();
            txtApellidoAdmin.Clear();
            txtUsuarioAcceso.Clear();
            txtContrasena.Clear();
            cmbNivelAcceso.SelectedIndex = -1;
            chkEstadoAdmin.Checked = false;
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }
    }
}