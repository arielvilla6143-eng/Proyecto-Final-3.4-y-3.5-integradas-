//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1
{
    public partial class FrmPrestamo : FrmBase, IPanelCRUD
    {
        private FrmVisorPrestamo visor;
        private Prestamo prestamoActual;

        public FrmPrestamo()
        {
            InitializeComponent();

            ConfigurarCampoEntero(txtIdEjemplarAgregar, "ID del usuario");
            ConfigurarCampoEntero(txtIdEjemplarPrestamo, "ID del ejemplar");
            btnAgregarDetalle.CausesValidation = false;
            btnEliminarDetalle.CausesValidation = false;
            btnVaciarDetalle.CausesValidation = false;
            btnRegistrarEstado.CausesValidation = false;
            btnDeshacer.CausesValidation = false;
            ConfigurarGrid();
            ActualizarContador();

            prestamoActual = new Prestamo();
            ActualizarHistorial();
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Prestamo prestamo = CrearPrestamoDesdeControles();
                prestamo.InsertarRegistro(prestamo);

                MessageBox.Show("Préstamo guardado correctamente.", "Guardar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();

                prestamoActual.VaciarHistorial();
                ActualizarHistorial();
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
                Prestamo prestamo = new Prestamo().ConsultarRegistro(id) as Prestamo;

                if (prestamo == null)
                {
                    alerta.SetError(txtId, "No existe un préstamo con ese id.");
                    return;
                }

                txtId.Text = prestamo.Id.ToString();
                txtIdEjemplarAgregar.Text = prestamo.IdUsuario.ToString();
                txtIdEjemplarPrestamo.Text = prestamo.IdEjemplar.ToString();
                dtpFechaPrestamo.Value = prestamo.FechaPrestamo;
                dtpFechaLimite.Value = prestamo.FechaLimite;
                chkDevuelto.Checked = prestamo.Devuelto;
                chkEstadoPrestamo.Checked = prestamo.EsActivo;
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
                Prestamo prestamo = CrearPrestamoDesdeControles();

                Prestamo existente = new Prestamo().ConsultarRegistro(txtId.Text) as Prestamo;
                if (existente != null)
                {
                    prestamo.FechaRegistro = existente.FechaRegistro;

                    if (chkDevuelto.Checked && existente.Devuelto)
                        prestamo.FechaDevolucionReal = existente.FechaDevolucionReal;
                }

                prestamo.ActualizarRegistro(prestamo);

                MessageBox.Show("Préstamo actualizado correctamente.", "Actualizar",
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
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Captura o busca un préstamo antes de eliminar.", "Eliminar",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que deseas eliminar el préstamo con id " + txtId.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                MostrarEstado(barraEstado, "Eliminación cancelada.");
                return;
            }

            string motivo;
            using (FrmMotivoEliminar dialogoMotivo = new FrmMotivoEliminar(txtId.Text))
            {
                if (dialogoMotivo.ShowDialog(this) != DialogResult.OK)
                {
                    MostrarEstado(barraEstado, "Eliminación cancelada.");
                    return;
                }
                motivo = dialogoMotivo.Motivo;
            }

            try
            {
                new Prestamo().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Préstamo eliminado. Motivo: " + motivo);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "No se pudo eliminar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Captura o busca un préstamo antes de exportar.", "Exportar",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.Title = "Exportar préstamo a archivo de texto";
            dialogoGuardar.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            dialogoGuardar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialogoGuardar.FileName = "Prestamo_" + txtId.Text + ".txt";

            if (dialogoGuardar.ShowDialog() == DialogResult.OK)
            {
                string ruta = dialogoGuardar.FileName;
                try
                {
                    string[] lineas =
                    {
                        "Id=" + txtId.Text,
                        "IdUsuario=" + txtIdEjemplarAgregar.Text,
                        "IdEjemplar=" + txtIdEjemplarPrestamo.Text,
                        "FechaPrestamo=" + dtpFechaPrestamo.Value.ToString("yyyy-MM-dd"),
                        "FechaLimite=" + dtpFechaLimite.Value.ToString("yyyy-MM-dd"),
                        "Devuelto=" + chkDevuelto.Checked,
                        "Activo=" + chkEstadoPrestamo.Checked
                    };

                    File.WriteAllLines(ruta, lineas);

                    MessageBox.Show("Archivo guardado en:\n" + ruta, "Exportar",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("No se pudo guardar el archivo: " + ex.Message, "Exportar",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogoAbrir = new OpenFileDialog();
            dialogoAbrir.Title = "Importar préstamo desde archivo de texto";
            dialogoAbrir.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            dialogoAbrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (dialogoAbrir.ShowDialog() == DialogResult.OK)
            {
                string ruta = dialogoAbrir.FileName;
                try
                {
                    Dictionary<string, string> datos = new Dictionary<string, string>();
                    foreach (string linea in File.ReadAllLines(ruta))
                    {
                        int posicion = linea.IndexOf('=');
                        if (posicion > 0)
                            datos[linea.Substring(0, posicion)] = linea.Substring(posicion + 1);
                    }

                    txtId.Text = datos["Id"];
                    txtIdEjemplarAgregar.Text = datos["IdUsuario"];
                    txtIdEjemplarPrestamo.Text = datos["IdEjemplar"];
                    dtpFechaPrestamo.Value = DateTime.Parse(datos["FechaPrestamo"]);
                    dtpFechaLimite.Value = DateTime.Parse(datos["FechaLimite"]);
                    chkDevuelto.Checked = bool.Parse(datos["Devuelto"]);
                    chkEstadoPrestamo.Checked = bool.Parse(datos["Activo"]);

                    MessageBox.Show("Datos cargados desde:\n" + ruta, "Importar",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) when (ex is IOException || ex is KeyNotFoundException || ex is FormatException)
                {
                    MessageBox.Show("El archivo no tiene el formato esperado o no se pudo leer.", "Importar",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVisor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Captura o busca un préstamo antes de abrir el visor.", "Visor",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (visor != null && !visor.IsDisposed)
            {
                visor.Activate();
                return;
            }

            visor = new FrmVisorPrestamo(txtId.Text);
            visor.Show(this);
        }

        private Prestamo CrearPrestamoDesdeControles()
        {
            int id = LeerEntero(txtId.Text, "El id");
            int idUsuario = LeerEntero(txtIdEjemplarAgregar.Text, "El id del usuario");
            int idEjemplar = LeerEntero(txtIdEjemplarPrestamo.Text, "El id del ejemplar");

            Prestamo prestamo = new Prestamo(id, idUsuario, idEjemplar, dtpFechaPrestamo.Value,
                                             dtpFechaLimite.Value, chkEstadoPrestamo.Checked);
            prestamo.Devuelto = chkDevuelto.Checked;
            return prestamo;
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
            txtIdEjemplarAgregar.Clear();
            txtIdEjemplarPrestamo.Clear();
            dtpFechaPrestamo.Value = DateTime.Now;
            dtpFechaLimite.Value = DateTime.Now;
            chkDevuelto.Checked = false;
            chkEstadoPrestamo.Checked = false;
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }

        private void pnlFormularioBase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtIdEjemplarAgregar_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfigurarGrid()
        {
            if (dgvEjemplares.Columns.Count == 0)
            {
                dgvEjemplares.Columns.Add("IdEjemplar", "ID Ejemplar");
                dgvEjemplares.AllowUserToAddRows = false;
                dgvEjemplares.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void FrmPrestamo_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            ActualizarContador();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvEjemplares.Columns.Count == 0)
            {
                ConfigurarGrid();
            }

            if (string.IsNullOrWhiteSpace(txtIdEjemplarAgregar.Text))
            {
                MessageBox.Show("Por favor, ingrese el ID del ejemplar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdEjemplarAgregar.Focus();
                return;
            }

            if (!int.TryParse(txtIdEjemplarAgregar.Text, out _))
            {
                MessageBox.Show("El ID del ejemplar debe contener únicamente números.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdEjemplarAgregar.SelectAll();
                txtIdEjemplarAgregar.Focus();
                return;
            }

            foreach (DataGridViewRow fila in dgvEjemplares.Rows)
            {
                if (fila.Cells["IdEjemplar"].Value != null && fila.Cells["IdEjemplar"].Value.ToString() == txtIdEjemplarAgregar.Text.Trim())
                {
                    MessageBox.Show("Este ejemplar ya se encuentra agregado en la lista.", "Ejemplar duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdEjemplarAgregar.SelectAll();
                    txtIdEjemplarAgregar.Focus();
                    return;
                }
            }

            dgvEjemplares.Rows.Add(txtIdEjemplarAgregar.Text.Trim());
            txtIdEjemplarAgregar.Clear();
            txtIdEjemplarAgregar.Focus();
            ActualizarContador();
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvEjemplares.Rows.Count == 0)
            {
                MessageBox.Show("No hay ejemplares en la lista para eliminar.", "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvEjemplares.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila de la lista para eliminar el ejemplar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvEjemplares.Rows.RemoveAt(dgvEjemplares.SelectedRows[0].Index);
            ActualizarContador();
        }

        private void btnVaciarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvEjemplares.Rows.Count == 0)
            {
                MessageBox.Show("La lista de ejemplares ya está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea remover todos los ejemplares de la lista?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                dgvEjemplares.Rows.Clear();
                ActualizarContador();
            }
        }

        private void btnRegistrarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = LeerEntero(txtIdEjemplarAgregar.Text, "El id del usuario");
                int idEjemplar = LeerEntero(txtIdEjemplarPrestamo.Text, "El id del ejemplar");

                bool registrado = prestamoActual.RegistrarEstado(idUsuario, idEjemplar,
                                                                 dtpFechaPrestamo.Value,
                                                                 dtpFechaLimite.Value,
                                                                 chkDevuelto.Checked,
                                                                 chkEstadoPrestamo.Checked);

                if (!registrado)
                {
                    MessageBox.Show("Ese estado ya existe en el historial.", "Estado duplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ActualizarHistorial();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "No se pudo registrar el estado",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (prestamoActual.ContarHistorial() == 0)
            {
                ActualizarHistorial();
                return;
            }

            prestamoActual.DesapilarYRevertir();
            MostrarPrestamoEnControles();
            ActualizarHistorial();
        }

        private void MostrarPrestamoEnControles()
        {
            txtIdEjemplarAgregar.Text = prestamoActual.IdUsuario > 0 ? prestamoActual.IdUsuario.ToString() : string.Empty;
            txtIdEjemplarPrestamo.Text = prestamoActual.IdEjemplar > 0 ? prestamoActual.IdEjemplar.ToString() : string.Empty;
            dtpFechaPrestamo.Value = prestamoActual.FechaPrestamo;
            dtpFechaLimite.Value = prestamoActual.FechaLimite;
            chkDevuelto.Checked = prestamoActual.Devuelto;
            chkEstadoPrestamo.Checked = prestamoActual.Estado;
        }

        private void ActualizarHistorial()
        {
            lstHistorial.Items.Clear();

            string[] elementos = prestamoActual.VolcarAArreglo();
            for (int i = 0; i < elementos.Length; i++)
            {
                if (i == 0)
                    lstHistorial.Items.Add("► CIMA: " + elementos[i]);
                else
                    lstHistorial.Items.Add(elementos[i]);
            }

            string cima = prestamoActual.InspeccionarCima();
            if (cima == null)
                lblCima.Text = "Siguiente acción a revertir: (ninguna)";
            else
                lblCima.Text = "Siguiente acción a revertir: " + cima;

            lblContadorHistorial.Text = "Acciones en historial: " + prestamoActual.ContarHistorial();

            btnDeshacer.Enabled = prestamoActual.ContarHistorial() > 0;
        }

        private void ActualizarContador()
        {
            lblContadorDetalle.Text = dgvEjemplares.Rows.Count.ToString();
        }
    }
}