// Actividad 3.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
using SistemaBiblioteca1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBiblioteca1
{
    public partial class FrmReporteMasivo : Form
    {
        private CancellationTokenSource? cts;
        private ProgresoReporte? ultimoProgreso;
        private int clicsPrueba;

        private readonly ErrorProvider epParametros = new ErrorProvider();
        private readonly HashSet<NumericUpDown> camposInvalidos = new HashSet<NumericUpDown>();

        public FrmReporteMasivo()
        {
            InitializeComponent();

            epParametros.ContainerControl = this;

            foreach (NumericUpDown campo in new NumericUpDown[] { nudCantidad, nudRetardo })
            {
                campo.KeyPress += SoloNumeros_KeyPress;
                campo.Validating += Parametro_Validating;
                campo.ValueChanged += (s, e) => LimpiarErrorCampo(campo);
            }

            btnDetener.CausesValidation = false;
            btnPruebaUI.CausesValidation = false;
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            await EjecutarEnSegundoPlanoAsync();
        }

        private async Task EjecutarEnSegundoPlanoAsync()
        {
            if (!ValidarParametros())
                return;

            int cantidad = (int)nudCantidad.Value;
            int retardo = (int)nudRetardo.Value;

            PrepararInterfaz(true, true);

            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            IProgress<ProgresoReporte> progreso = new Progress<ProgresoReporte>(ActualizarProgreso);

            try
            {
                ResumenReporte resumen = await Task.Run(() =>
                {
                    ActualizarEstado("Generando y analizando préstamos en segundo plano...");

                    ResumenReporte r = MotorReporteSanciones.Procesar(cantidad, retardo, progreso, AgregarFila, token);

                    ActualizarEstado("Consolidando resultados...");
                    return r;
                }, token);

                if (IsDisposed) return;

                if (resumen.Cancelado)
                {
                    MostrarCancelacion(resumen, cantidad);
                    return;
                }

                ActualizarEstado("Proceso completado.");
                MostrarResumen("Segundo plano", resumen);
            }
            catch (OperationCanceledException)
            {
                if (IsDisposed) return;

                ActualizarEstado("Proceso cancelado por el usuario.");
                if (ultimoProgreso != null)
                {
                    lblResumen.Text = "Cancelado en " + ultimoProgreso.Porcentaje + " %  |  Procesados: " +
                                      ultimoProgreso.Procesados + " de " + ultimoProgreso.Total +
                                      "  |  Sancionados hasta el momento: " + ultimoProgreso.Sancionados;
                }
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;

                ActualizarEstado("Error durante el proceso.");
                MessageBox.Show(ex.Message, "No se pudo completar el reporte",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (!IsDisposed)
                    PrepararInterfaz(false, false);

                if (cts != null)
                {
                    cts.Dispose();
                    cts = null;
                }
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                btnDetener.Enabled = false;
                ActualizarEstado("Cancelando...");
            }
        }

        private void FrmReporteMasivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cts != null)
                cts.Cancel();
        }

        private void btnLineal_Click(object sender, EventArgs e)
        {
            if (!ValidarParametros())
                return;

            int cantidad = (int)nudCantidad.Value;
            int retardo = (int)nudRetardo.Value;
            double segundos = cantidad * (double)retardo / 1000.0;

            DialogResult respuesta = MessageBox.Show(
                "El proceso se ejecutará en el hilo principal durante unos " + segundos.ToString("0.0") +
                " segundos.\n\nLa ventana se congelará (no podrás moverla ni pulsar botones) hasta que termine.\n\n¿Continuar con la demostración?",
                "Ejecución lineal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            PrepararInterfaz(true, false);
            ActualizarEstado("Procesando en el hilo principal... la ventana NO responde.");
            lblEstado.Refresh();

            try
            {
                ResumenReporte resumen = MotorReporteSanciones.Procesar(cantidad, retardo, null, AgregarFila,
                                                                       CancellationToken.None);
                ActualizarEstado("Proceso lineal terminado.");
                MostrarResumen("Lineal (hilo principal)", resumen);
            }
            finally
            {
                PrepararInterfaz(false, false);
            }
        }

        private void btnPruebaUI_Click(object sender, EventArgs e)
        {
            clicsPrueba++;
            lblClics.Text = "Clics: " + clicsPrueba;
        }

        private void ActualizarProgreso(ProgresoReporte p)
        {
            if (IsDisposed) return;

            ultimoProgreso = p;
            pbProgreso.Value = Math.Min(100, p.Porcentaje);
            lblPorcentaje.Text = p.Porcentaje + " %  (" + p.Procesados + "/" + p.Total + ")";
            lblResumen.Text = "Sancionados: " + p.Sancionados + "  |  Monto acumulado: $" + p.MontoAcumulado.ToString("0.00");
        }

        private void ActualizarEstado(string texto)
        {
            if (IsDisposed || Disposing) return;

            if (lblEstado.InvokeRequired)
            {
                try
                {
                    lblEstado.BeginInvoke(new MethodInvoker(() => ActualizarEstado(texto)));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                return;
            }

            lblEstado.Text = texto;
        }

        private void AgregarFila(FilaReporte fila)
        {
            if (IsDisposed || Disposing) return;

            if (dgvResultados.InvokeRequired)
            {
                try
                {
                    dgvResultados.BeginInvoke(new Action<FilaReporte>(AgregarFila), fila);
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                return;
            }

            dgvResultados.Rows.Add(fila.IdPrestamo, fila.IdUsuario, fila.DiasRetraso,
                                   fila.PorcentajeRecargo.ToString("P0"), fila.Monto.ToString("0.00"));
        }

        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            if (char.IsDigit(e.KeyChar) && sender is NumericUpDown campo)
                LimpiarErrorCampo(campo);
        }

        private void LimpiarErrorCampo(NumericUpDown campo)
        {
            camposInvalidos.Remove(campo);
            epParametros.SetError(campo, "");
        }

        private void Parametro_Validating(object? sender, CancelEventArgs e)
        {
            NumericUpDown? campo = sender as NumericUpDown;
            if (campo == null)
                return;

            string? mensaje = ObtenerErrorNumerico(campo);

            if (mensaje != null)
            {
                camposInvalidos.Add(campo);
                epParametros.SetError(campo, mensaje);
                e.Cancel = true;
            }
            else
            {
                LimpiarErrorCampo(campo);
            }
        }

        private bool ValidarParametros()
        {
            bool cantidadValida = ValidarCampo(nudCantidad);
            bool retardoValido = ValidarCampo(nudRetardo);

            if (cantidadValida && retardoValido)
                return true;

            ActualizarEstado("Corrige los campos marcados antes de iniciar.");
            if (!cantidadValida)
                nudCantidad.Focus();
            else
                nudRetardo.Focus();
            return false;
        }

        private bool ValidarCampo(NumericUpDown campo)
        {
            if (camposInvalidos.Contains(campo))
                return false;

            string? mensaje = ObtenerErrorNumerico(campo);

            if (mensaje != null)
            {
                epParametros.SetError(campo, mensaje);
                return false;
            }

            epParametros.SetError(campo, "");
            return true;
        }

        private string? ObtenerErrorNumerico(NumericUpDown campo)
        {
            string nombre = (campo == nudCantidad) ? "Registros a procesar" : "Retardo por registro";
            string texto = campo.Text.Trim();

            if (texto.Length == 0)
                return "El campo '" + nombre + "' es obligatorio.";

            if (!int.TryParse(texto, out int valor))
                return "'" + nombre + "' solo admite números enteros.";

            if (valor < campo.Minimum || valor > campo.Maximum)
                return "'" + nombre + "' debe estar entre " + campo.Minimum + " y " + campo.Maximum + ".";

            return null;
        }

        private void PrepararInterfaz(bool ejecutando, bool permitirDetener)
        {
            btnIniciar.Enabled = !ejecutando;
            btnLineal.Enabled = !ejecutando;
            nudCantidad.Enabled = !ejecutando;
            nudRetardo.Enabled = !ejecutando;
            btnDetener.Enabled = ejecutando && permitirDetener;

            if (ejecutando)
            {
                dgvResultados.Rows.Clear();
                pbProgreso.Value = 0;
                lblPorcentaje.Text = "0 %";
                lblResumen.Text = "";
                ultimoProgreso = null;
            }
        }

        private void MostrarCancelacion(ResumenReporte r, int total)
        {
            int porcentaje = total == 0 ? 0 : (int)((long)r.Procesados * 100 / total);

            ActualizarEstado("Proceso cancelado por el usuario.");
            pbProgreso.Value = Math.Min(100, porcentaje);
            lblPorcentaje.Text = porcentaje + " %  (" + r.Procesados + "/" + total + ")";
            lblResumen.Text = "Cancelado en " + porcentaje + " %  |  Procesados: " + r.Procesados + " de " + total +
                              "  |  Sancionados hasta el momento: " + r.Sancionados +
                              "  |  Monto parcial: $" + r.MontoTotal.ToString("0.00");
        }

        private void MostrarResumen(string modo, ResumenReporte r)
        {
            pbProgreso.Value = 100;
            lblPorcentaje.Text = "100 %  (" + r.Procesados + "/" + r.Procesados + ")";
            lblResumen.Text = "Modo: " + modo + "  |  Tiempo: " + r.Duracion.TotalSeconds.ToString("0.0") +
                              " s  |  Sancionados: " + r.Sancionados + " de " + r.Procesados +
                              "  |  Monto total: $" + r.MontoTotal.ToString("0.00") +
                              "  |  Mayor retraso: " + r.MayorRetraso + " días";
        }
    }
}