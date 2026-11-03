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
    public partial class FrmAutor : FrmBase, IPanelCRUD
    {
        public FrmAutor()
        {
            InitializeComponent();

            ConfigurarCampoLetras(txtNombreAutor, "Nombre");
            ConfigurarCampoLetras(txtApellidoAutor, "Apellido");
            ConfigurarCampoLetras(txtNacionalidadAutor, "Nacionalidad");
        }

        public void EjecutarGuardar()
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Autor autor = CrearAutorDesdeControles();
                autor.InsertarRegistro(autor);

                MessageBox.Show("Autor guardado correctamente.", "Guardar",
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
                Autor autor = new Autor().ConsultarRegistro(id) as Autor;

                if (autor == null)
                {
                    alerta.SetError(txtId, "No existe un autor con ese id.");
                    return;
                }

                txtId.Text = autor.Id.ToString();
                txtNombreAutor.Text = autor.Nombre;
                txtApellidoAutor.Text = autor.Apellido;
                txtNacionalidadAutor.Text = autor.Nacionalidad;
                dtpFechaNacimientoAutor.Value = autor.FechaNacimiento;
                chkEstadoAutor.Checked = autor.EsActivo;
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
                Autor autor = CrearAutorDesdeControles();

                Autor existente = new Autor().ConsultarRegistro(txtId.Text) as Autor;
                if (existente != null)
                    autor.FechaRegistro = existente.FechaRegistro;

                autor.ActualizarRegistro(autor);

                MessageBox.Show("Autor actualizado correctamente.", "Actualizar",
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
                new Autor().EliminarRegistro(txtId.Text);
                LimpiarControles();
                MostrarEstado(barraEstado, "Autor eliminado correctamente.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MostrarEstado(barraEstado, ex.Message);
            }
        }

        private Autor CrearAutorDesdeControles()
        {
            if (!int.TryParse(txtId.Text, out int id))
                throw new FormatException("El id debe ser un número entero.");

            return new Autor(id, txtNombreAutor.Text, txtApellidoAutor.Text, txtNacionalidadAutor.Text,
                             dtpFechaNacimientoAutor.Value, chkEstadoAutor.Checked);
        }

        private void LimpiarControles()
        {
            LimpiarErrores();
            txtId.Clear();
            txtNombreAutor.Clear();
            txtApellidoAutor.Clear();
            txtNacionalidadAutor.Clear();
            dtpFechaNacimientoAutor.Value = DateTime.Now;
            chkEstadoAutor.Checked = false;
        }

        private void MostrarEstado(StatusStrip barraEstado, string mensaje)
        {
            if (barraEstado.Items.Count > 0)
                barraEstado.Items[0].Text = mensaje;
        }
    }
}