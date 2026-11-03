//Suñiga Maciel Joule Alexander
//Villa Olivares Ariel 
//Martinez Marco Antonio
//Equipo 2
using System;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public partial class FrmMotivoEliminar : Form
    {
        public string Motivo
        {
            get { return txtMotivo.Text.Trim(); }
        }

        public FrmMotivoEliminar(string idPrestamo)
        {
            InitializeComponent();
            lblMotivo.Text = "Motivo de eliminar el préstamo " + idPrestamo + ":";
            FormClosing += FrmMotivoEliminar_FormClosing;
        }

        private void FrmMotivoEliminar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Escribe un motivo para continuar.", "Motivo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                DialogResult = DialogResult.None;
                txtMotivo.Focus();
            }
        }
    }
}