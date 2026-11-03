// Actividad 3.3 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
using SistemaBiblioteca1.Models;
using System;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public partial class FrmVisorPrestamo : Form
    {
        private string idPrestamo;

        public FrmVisorPrestamo(string idPrestamo)
        {
            InitializeComponent();
            this.idPrestamo = idPrestamo;
            Text = "Visor de préstamo " + idPrestamo;
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                Prestamo prestamo = new Prestamo().ConsultarRegistro(idPrestamo) as Prestamo;

                if (prestamo == null)
                {
                    txtVisor.Text = "No existe un préstamo con el id " + idPrestamo + ".";
                    return;
                }

                txtVisor.Text =
                    "Id: " + prestamo.Id + Environment.NewLine +
                    "Id usuario: " + prestamo.IdUsuario + Environment.NewLine +
                    "Id ejemplar: " + prestamo.IdEjemplar + Environment.NewLine +
                    "Fecha de préstamo: " + prestamo.FechaPrestamo.ToString("dd/MM/yyyy") + Environment.NewLine +
                    "Fecha límite: " + prestamo.FechaLimite.ToString("dd/MM/yyyy") + Environment.NewLine +
                    "Devuelto: " + (prestamo.Devuelto ? "Sí" : "No") + Environment.NewLine +
                    "Activo: " + (prestamo.EsActivo ? "Sí" : "No");
            }
            catch (ArgumentException ex)
            {
                txtVisor.Text = ex.Message;
            }
        }

        private void btnActualizarVisor_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnCerrarVisor_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}