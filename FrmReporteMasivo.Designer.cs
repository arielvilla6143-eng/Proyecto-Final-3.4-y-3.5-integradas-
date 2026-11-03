// Actividad 3.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
namespace SistemaBiblioteca1
{
    partial class FrmReporteMasivo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlControles = new Panel();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            lblRetardo = new Label();
            nudRetardo = new NumericUpDown();
            btnIniciar = new Button();
            btnDetener = new Button();
            btnLineal = new Button();
            btnPruebaUI = new Button();
            lblClics = new Label();
            lblInfo = new Label();
            pnlProgreso = new Panel();
            pbProgreso = new ProgressBar();
            lblPorcentaje = new Label();
            lblEstado = new Label();
            lblResumen = new Label();
            dgvResultados = new DataGridView();
            colIdPrestamo = new DataGridViewTextBoxColumn();
            colIdUsuario = new DataGridViewTextBoxColumn();
            colDiasRetraso = new DataGridViewTextBoxColumn();
            colRecargo = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRetardo).BeginInit();
            pnlProgreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // pnlControles
            // 
            pnlControles.Controls.Add(lblCantidad);
            pnlControles.Controls.Add(nudCantidad);
            pnlControles.Controls.Add(lblRetardo);
            pnlControles.Controls.Add(nudRetardo);
            pnlControles.Controls.Add(btnIniciar);
            pnlControles.Controls.Add(btnDetener);
            pnlControles.Controls.Add(btnLineal);
            pnlControles.Controls.Add(btnPruebaUI);
            pnlControles.Controls.Add(lblClics);
            pnlControles.Controls.Add(lblInfo);
            pnlControles.Dock = DockStyle.Top;
            pnlControles.Location = new Point(0, 0);
            pnlControles.Name = "pnlControles";
            pnlControles.Size = new Size(900, 128);
            pnlControles.TabIndex = 0;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(16, 18);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(133, 20);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Registros a procesar:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(200, 14);
            nudCantidad.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(100, 27);
            nudCantidad.TabIndex = 1;
            nudCantidad.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblRetardo
            // 
            lblRetardo.AutoSize = true;
            lblRetardo.Location = new Point(16, 56);
            lblRetardo.Name = "lblRetardo";
            lblRetardo.Size = new Size(176, 20);
            lblRetardo.TabIndex = 2;
            lblRetardo.Text = "Retardo por registro (ms):";
            // 
            // nudRetardo
            // 
            nudRetardo.Location = new Point(200, 52);
            nudRetardo.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudRetardo.Name = "nudRetardo";
            nudRetardo.Size = new Size(100, 27);
            nudRetardo.TabIndex = 3;
            nudRetardo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(330, 10);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(230, 36);
            btnIniciar.TabIndex = 4;
            btnIniciar.Text = "Iniciar en segundo plano";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnDetener
            // 
            btnDetener.Enabled = false;
            btnDetener.Location = new Point(572, 10);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(130, 36);
            btnDetener.TabIndex = 5;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = true;
            btnDetener.Click += btnDetener_Click;
            // 
            // btnLineal
            // 
            btnLineal.Location = new Point(330, 52);
            btnLineal.Name = "btnLineal";
            btnLineal.Size = new Size(230, 36);
            btnLineal.TabIndex = 6;
            btnLineal.Text = "Ejecutar lineal (congela)";
            btnLineal.UseVisualStyleBackColor = true;
            btnLineal.Click += btnLineal_Click;
            // 
            // btnPruebaUI
            // 
            btnPruebaUI.Location = new Point(572, 52);
            btnPruebaUI.Name = "btnPruebaUI";
            btnPruebaUI.Size = new Size(200, 36);
            btnPruebaUI.TabIndex = 7;
            btnPruebaUI.Text = "Botón de prueba de UI";
            btnPruebaUI.UseVisualStyleBackColor = true;
            btnPruebaUI.Click += btnPruebaUI_Click;
            // 
            // lblClics
            // 
            lblClics.AutoSize = false;
            lblClics.Location = new Point(784, 58);
            lblClics.Name = "lblClics";
            lblClics.Size = new Size(100, 26);
            lblClics.TabIndex = 8;
            lblClics.Text = "Clics: 0";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = false;
            lblInfo.Location = new Point(16, 96);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(868, 24);
            lblInfo.TabIndex = 9;
            lblInfo.Text = "Con el proceso en marcha pulsa el botón de prueba: si el contador sube, la interfaz está libre.";
            // 
            // pnlProgreso
            // 
            pnlProgreso.Controls.Add(pbProgreso);
            pnlProgreso.Controls.Add(lblPorcentaje);
            pnlProgreso.Controls.Add(lblEstado);
            pnlProgreso.Controls.Add(lblResumen);
            pnlProgreso.Dock = DockStyle.Bottom;
            pnlProgreso.Location = new Point(0, 452);
            pnlProgreso.Name = "pnlProgreso";
            pnlProgreso.Size = new Size(900, 108);
            pnlProgreso.TabIndex = 2;
            // 
            // pbProgreso
            // 
            pbProgreso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbProgreso.Location = new Point(16, 12);
            pbProgreso.Name = "pbProgreso";
            pbProgreso.Size = new Size(690, 26);
            pbProgreso.TabIndex = 0;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPorcentaje.AutoSize = false;
            lblPorcentaje.Location = new Point(718, 12);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(166, 26);
            lblPorcentaje.TabIndex = 1;
            lblPorcentaje.Text = "0 %";
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoSize = false;
            lblEstado.Location = new Point(16, 46);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(868, 24);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Listo. Elige la cantidad de registros e inicia el proceso.";
            // 
            // lblResumen
            // 
            lblResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResumen.AutoSize = false;
            lblResumen.Location = new Point(16, 76);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(868, 24);
            lblResumen.TabIndex = 3;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { colIdPrestamo, colIdUsuario, colDiasRetraso, colRecargo, colMonto });
            dgvResultados.Dock = DockStyle.Fill;
            dgvResultados.Location = new Point(0, 128);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(900, 324);
            dgvResultados.TabIndex = 1;
            // 
            // colIdPrestamo
            // 
            colIdPrestamo.HeaderText = "ID préstamo";
            colIdPrestamo.MinimumWidth = 6;
            colIdPrestamo.Name = "colIdPrestamo";
            colIdPrestamo.ReadOnly = true;
            // 
            // colIdUsuario
            // 
            colIdUsuario.HeaderText = "ID usuario";
            colIdUsuario.MinimumWidth = 6;
            colIdUsuario.Name = "colIdUsuario";
            colIdUsuario.ReadOnly = true;
            // 
            // colDiasRetraso
            // 
            colDiasRetraso.HeaderText = "Días de retraso";
            colDiasRetraso.MinimumWidth = 6;
            colDiasRetraso.Name = "colDiasRetraso";
            colDiasRetraso.ReadOnly = true;
            // 
            // colRecargo
            // 
            colRecargo.HeaderText = "% recargo";
            colRecargo.MinimumWidth = 6;
            colRecargo.Name = "colRecargo";
            colRecargo.ReadOnly = true;
            // 
            // colMonto
            // 
            colMonto.HeaderText = "Monto ($)";
            colMonto.MinimumWidth = 6;
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            // 
            // FrmReporteMasivo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 560);
            Controls.Add(dgvResultados);
            Controls.Add(pnlProgreso);
            Controls.Add(pnlControles);
            MinimumSize = new Size(760, 480);
            Name = "FrmReporteMasivo";
            Text = "Reporte masivo de sanciones";
            FormClosing += FrmReporteMasivo_FormClosing;
            pnlControles.ResumeLayout(false);
            pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRetardo).EndInit();
            pnlProgreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlControles;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Label lblRetardo;
        private NumericUpDown nudRetardo;
        private Button btnIniciar;
        private Button btnDetener;
        private Button btnLineal;
        private Button btnPruebaUI;
        private Label lblClics;
        private Label lblInfo;
        private Panel pnlProgreso;
        private ProgressBar pbProgreso;
        private Label lblPorcentaje;
        private Label lblEstado;
        private Label lblResumen;
        private DataGridView dgvResultados;
        private DataGridViewTextBoxColumn colIdPrestamo;
        private DataGridViewTextBoxColumn colIdUsuario;
        private DataGridViewTextBoxColumn colDiasRetraso;
        private DataGridViewTextBoxColumn colRecargo;
        private DataGridViewTextBoxColumn colMonto;
    }
}
