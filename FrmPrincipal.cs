//Suñiga Maciel Joule Alexander
//Villa Olivarez Ariel
//Nuñes Martinez Marco Antonio
//Equipo 2
//=============================
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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void btnProcesarAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                Administrador admin = new Administrador();

                admin.IdAdministrador = int.Parse(txtIdAdmin.Text);
                admin.Nombre = txtNombreAdmin.Text;
                admin.Apellido = txtApellidoAdmin.Text;
                admin.UsuarioAcceso = txtUsuarioAcceso.Text;
                admin.Contrasena = txtContrasena.Text;

                if (cmbNivelAcceso.SelectedItem != null)
                {
                    admin.NivelAcceso = int.Parse(cmbNivelAcceso.SelectedItem.ToString());
                }

                admin.Estado = chkEstadoAdmin.Checked;
                txtResultadoAdmin.Text = "ADMINISTRADOR REGISTRADO" + Environment.NewLine +
                                         admin.ToString() + Environment.NewLine +
                                         $"¿Tiene Permiso Nivel 3 (Admin General)?: {(admin.TienePermiso(3) ? "SÍ" : "NO")}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa un ID numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnProcesarAutor_Click(object sender, EventArgs e)
        {
            try
            {
                Autor autor = new Autor();

                autor.IdAutor = int.Parse(txtIdAutor.Text);
                autor.Nombre = txtNombreAutor.Text;
                autor.Apellido = txtApellidoAutor.Text;
                autor.Nacionalidad = txtNacionalidadAutor.Text;
                autor.FechaNacimiento = dtpFechaNacimientoAutor.Value;
                autor.Estado = chkEstadoAutor.Checked;

                txtResultadoAutor.Text = "AUTOR REGISTRADO" + Environment.NewLine +
                                         autor.ToString() + Environment.NewLine +
                                         $"Edad Calculada: {autor.CalcularEdad()} años";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa un ID numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnProcesarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();

                categoria.IdCategoria = int.Parse(txtIdCategoria.Text);
                categoria.Nombre = txtNombreCategoria.Text;
                categoria.Descripcion = txtDescripcionCategoria.Text;
                categoria.RestringidaMenores = chkRestringidaMenores.Checked;
                categoria.Estado = chkEstadoCategoria.Checked;

                txtResultadoCategoria.Text = "CATEGORÍA REGISTRADA" + Environment.NewLine +
                                             categoria.ToString() + Environment.NewLine +
                                             $"¿Permite acceso a un usuario de 16 años?: {(categoria.PermiteAcceso(16) ? "SÍ" : "NO")}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa un ID numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnProcesarEditorial_Click(object sender, EventArgs e)
        {
            try
            {
                Editorial editorial = new Editorial();

                editorial.IdEditorial = int.Parse(txtIdEditorial.Text);
                editorial.Nombre = txtNombreEditorial.Text;
                editorial.PaisOrigen = txtPaisOrigen.Text;
                editorial.AnioFundacion = int.Parse(txtAnioFundacion.Text);
                editorial.Estado = chkEstadoEditorial.Checked;

                txtResultadoEditorial.Text = "=== EDITORIAL REGISTRADA ===" + Environment.NewLine +
                                             editorial.ToString() + Environment.NewLine +
                                             $"Antigüedad: {editorial.CalcularAntiguedad()} años";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos (ID y Año).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnProcesarEjemplar_Click(object sender, EventArgs e)
        {
            try
            {
                Ejemplar ejemplar = new Ejemplar();

                ejemplar.IdEjemplar = int.Parse(txtIdEjemplar.Text);
                ejemplar.IdLibro = int.Parse(txtIdLibroEjemplar.Text);
                ejemplar.CodigoInventario = txtCodigoInventario.Text;

                if (cmbCondicion.SelectedItem != null)
                {
                    ejemplar.Condicion = cmbCondicion.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor selecciona una condición de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ejemplar.Disponible = chkDisponible.Checked;
                ejemplar.Estado = chkEstadoEjemplar.Checked;

                double penalizacion = ejemplar.CalcularPorcentajePenalizacion() * 100;
                txtResultadoEjemplar.Text = "=== EJEMPLAR REGISTRADO ===" + Environment.NewLine +
                                            ejemplar.ToString() + Environment.NewLine +
                                            $"Penalización por condición: {penalizacion}%";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos en los IDs.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnProcesarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                Libro libro = new Libro();

                libro.IdLibro = int.Parse(txtIdLibro.Text);
                libro.Titulo = txtTituloLibro.Text;
                libro.Isbn = txtIsbn.Text;
                libro.IdAutor = int.Parse(txtIdAutorLibro.Text);
                libro.IdCategoria = int.Parse(txtIdCategoriaLibro.Text);
                libro.IdEditorial = int.Parse(txtIdEditorialLibro.Text);
                libro.AnioPublicacion = int.Parse(txtAnioPublicacion.Text);
                libro.Estado = chkEstadoLibro.Checked;

                txtResultadoLibro.Text = "=== LIBRO REGISTRADO ===" + Environment.NewLine +
                                         libro.ToString() + Environment.NewLine +
                                         $"Antigüedad: {libro.CalcularAntiguedad()} años";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos en los IDs y el Año.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            try
            {
                Pago pago = new Pago();

                pago.IdPago = int.Parse(txtIdPago.Text);
                pago.IdSancion = int.Parse(txtIdSancionPago.Text);
                pago.Monto = double.Parse(txtMontoPago.Text);
                pago.FechaPago = dtpFechaPago.Value;

                if (cmbMetodoPago.SelectedItem != null)
                {
                    pago.MetodoPago = cmbMetodoPago.SelectedItem.ToString();
                }

                pago.Estado = chkEstadoPago.Checked;
                double montoPrueba = 150.0;
                txtResultadoPago.Text = "=== PAGO REGISTRADO ===" + Environment.NewLine +
                                        pago.ToString() + Environment.NewLine +
                                        $"¿Cubre una sanción de ${montoPrueba:0.00}?: {(pago.CubreSancion(montoPrueba) ? "SÍ" : "NO")}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos (ID y Monto).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnProcesarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamo = new Prestamo();

                prestamo.IdPrestamo = int.Parse(txtIdPrestamo.Text);
                prestamo.IdUsuario = int.Parse(txtIdUsuarioPrestamo.Text);
                prestamo.IdEjemplar = int.Parse(txtIdEjemplarPrestamo.Text);
                prestamo.FechaPrestamo = dtpFechaPrestamo.Value;
                prestamo.FechaLimite = dtpFechaLimite.Value;
                prestamo.Devuelto = chkDevuelto.Checked;
                prestamo.Estado = chkEstadoPrestamo.Checked;

                txtResultadoPrestamo.Text = "PRÉSTAMO REGISTRADO" + Environment.NewLine +
                                            prestamo.ToString() + Environment.NewLine +
                                            $"Días de retraso acumulados: {prestamo.CalcularDiasRetraso()} días";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos en los IDs.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnProcesarSancion_Click(object sender, EventArgs e)
        {
            try
            {
                Sancion sancion = new Sancion();

                sancion.IdSancion = int.Parse(txtIdSancion.Text);
                sancion.IdUsuario = int.Parse(txtIdUsuarioSancion.Text);
                sancion.IdPrestamo = int.Parse(txtIdPrestamoSancion.Text);
                sancion.Motivo = txtMotivoSancion.Text;
                sancion.DiasRetraso = int.Parse(txtDiasRetraso.Text);
                sancion.PorcentajePenalizacionCondicion = double.Parse(txtPorcentajePenalizacion.Text);
                sancion.Pagada = chkPagada.Checked;
                sancion.Estado = chkEstadoSancion.Checked;

                double montoCalculado = sancion.CalcularMonto();

                txtResultadoSancion.Text = "=== SANCIÓN REGISTRADA ===" + Environment.NewLine +
                                           sancion.ToString() + Environment.NewLine +
                                           $"Monto Total a Pagar: ${montoCalculado:0.00}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa números válidos (IDs, Días y Porcentaje).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void chkEstadoUsuario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnProcesarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Instanciar el objeto Usuario
                Usuario usuario = new Usuario();

                // 2. Mapear solo las propiedades que SÍ existen en tu modelo
                usuario.IdUsuario = int.Parse(txtIdUsuario.Text);
                usuario.Nombre = txtNombreUsuario.Text;
                usuario.Apellido = txtApellidoUsuario.Text;
                usuario.Email = txtEmailUsuario.Text;
                usuario.Estado = chkEstadoUsuario.Checked;

                // 3. Proyectar el resultado e invocar sus métodos de negocio
                int prestamosActuales = 2; // Valor de prueba
                int limitePrestamos = int.Parse(txtLimitePrestamos.Text); // El segundo valor que pide tu método

                txtResultadoUsuario.Text = "=== USUARIO REGISTRADO ===" + Environment.NewLine +
                                           usuario.ToString() + Environment.NewLine +
                                           // Aquí pasamos los dos valores (int, int) que te pide el error CS7036
                                           $"¿Puede solicitar nuevo préstamo?: {(usuario.PuedeSolicitarPrestamo(prestamosActuales, limitePrestamos) ? "SÍ" : "NO")}";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error de validación: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa números válidos (ID y Límite de préstamos).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }
    }
}
