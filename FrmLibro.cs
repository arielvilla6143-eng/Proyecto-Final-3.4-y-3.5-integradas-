//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SistemaBiblioteca1.Models;

namespace SistemaBiblioteca1
{
    public partial class FrmLibro : FrmBase, IPanelCRUD
    {
        public FrmLibro()
        {
            InitializeComponent();

            ConfigurarCampoTexto(txtTituloLibro, "Título");
            ConfigurarCampoTexto(txtIsbn, "ISBN", t => (t.Length != 10 && t.Length != 13) ? "El ISBN debe tener 10 o 13 caracteres." : null);
            ConfigurarCampoEntero(txtIdAutorLibro, "ID del autor");
            ConfigurarCampoEntero(txtIdCategoriaLibro, "ID de la categoría");
            ConfigurarCampoEntero(txtIdEditorialLibro, "ID de la editorial");
            ConfigurarCampoEntero(txtAnioPublicacion, "Año de publicación", t => t.Length != 4 ? "El año debe tener 4 dígitos." : null);
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Libro libro = CrearLibroDesdeControles();
                libro.InsertarRegistro(libro);

                MessageBox.Show("Libro guardado correctamente.", "Guardar",
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
                Libro libro = new Libro().ConsultarRegistro(id) as Libro;

                if (libro == null)
                {
                    alerta.SetError(txtId, "No existe un libro con ese id.");
                    return;
                }

                txtId.Text = libro.Id.ToString();
                txtTituloLibro.Text = libro.Titulo;
                txtIsbn.Text = libro.Isbn;
                txtIdAutorLibro.Text = libro.IdAutor.ToString();
                txtIdCategoriaLibro.Text = libro.IdCategoria.ToString();
                txtIdEditorialLibro.Text = libro.IdEditorial.ToString();
                txtAnioPublicacion.Text = libro.AnioPublicacion.ToString();
                chkEstadoLibro.Checked = libro.EsActivo;
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
                Libro libro = CrearLibroDesdeControles();

                Libro existente = new Libro().ConsultarRegistro(txtId.Text) as Libro;
                if (existente != null)
                    libro.FechaRegistro = existente.FechaRegistro;

                libro.ActualizarRegistro(libro);

                MessageBox.Show("Libro actualizado correctamente.", "Actualizar",
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
                new Libro().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Libro eliminado correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MostrarEstado(barraEstado, ex.Message);
            }
        }

        private Libro CrearLibroDesdeControles()
        {
            int id = LeerEntero(txtId.Text, "El id");
            int idAutor = LeerEntero(txtIdAutorLibro.Text, "El id del autor");
            int idCategoria = LeerEntero(txtIdCategoriaLibro.Text, "El id de la categoría");
            int idEditorial = LeerEntero(txtIdEditorialLibro.Text, "El id de la editorial");
            int anio = LeerEntero(txtAnioPublicacion.Text, "El año de publicación");

            return new Libro(id, txtTituloLibro.Text, txtIsbn.Text, idAutor, idCategoria,
                             idEditorial, anio, chkEstadoLibro.Checked);
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
            txtTituloLibro.Clear();
            txtIsbn.Clear();
            txtIdAutorLibro.Clear();
            txtIdCategoriaLibro.Clear();
            txtIdEditorialLibro.Clear();
            txtAnioPublicacion.Clear();
            chkEstadoLibro.Checked = false;
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }
    }
}