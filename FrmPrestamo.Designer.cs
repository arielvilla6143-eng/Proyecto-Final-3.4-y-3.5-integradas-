// Actividad 2.5 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
namespace SistemaBiblioteca1
{
    partial class FrmPrestamo
    {

        private void InitializeComponent()
        {
            lblIdUsuarioPrestamo = new Label();
            txtIdEjemplarAgregar = new TextBox();
            lblIdEjemplarPrestamo = new Label();
            txtIdEjemplarPrestamo = new TextBox();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            lblFechaLimite = new Label();
            dtpFechaLimite = new DateTimePicker();
            chkDevuelto = new CheckBox();
            chkEstadoPrestamo = new CheckBox();
            btnAgregarDetalle = new Button();
            dgvEjemplares = new DataGridView();
            btnEliminarDetalle = new Button();
            btnVaciarDetalle = new Button();
            label1 = new Label();
            lblContadorDetalle = new Label();
            btnExportar = new Button();
            btnImportar = new Button();
            btnVisor = new Button();
            btnRegistrarEstado = new Button();
            btnDeshacer = new Button();
            lblCima = new Label();
            lblContadorHistorial = new Label();
            lstHistorial = new ListBox();
            pnlFormularioBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epValidaciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEjemplares).BeginInit();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(lstHistorial);
            pnlFormularioBase.Controls.Add(lblContadorHistorial);
            pnlFormularioBase.Controls.Add(lblCima);
            pnlFormularioBase.Controls.Add(btnDeshacer);
            pnlFormularioBase.Controls.Add(btnRegistrarEstado);
            pnlFormularioBase.Controls.Add(btnVisor);
            pnlFormularioBase.Controls.Add(btnImportar);
            pnlFormularioBase.Controls.Add(btnExportar);
            pnlFormularioBase.Controls.Add(lblContadorDetalle);
            pnlFormularioBase.Controls.Add(label1);
            pnlFormularioBase.Controls.Add(btnVaciarDetalle);
            pnlFormularioBase.Controls.Add(btnEliminarDetalle);
            pnlFormularioBase.Controls.Add(dgvEjemplares);
            pnlFormularioBase.Controls.Add(btnAgregarDetalle);
            pnlFormularioBase.Controls.Add(lblIdUsuarioPrestamo);
            pnlFormularioBase.Controls.Add(txtIdEjemplarAgregar);
            pnlFormularioBase.Controls.Add(lblIdEjemplarPrestamo);
            pnlFormularioBase.Controls.Add(txtIdEjemplarPrestamo);
            pnlFormularioBase.Controls.Add(lblFechaPrestamo);
            pnlFormularioBase.Controls.Add(dtpFechaPrestamo);
            pnlFormularioBase.Controls.Add(lblFechaLimite);
            pnlFormularioBase.Controls.Add(dtpFechaLimite);
            pnlFormularioBase.Controls.Add(chkDevuelto);
            pnlFormularioBase.Controls.Add(chkEstadoPrestamo);
            pnlFormularioBase.Paint += pnlFormularioBase_Paint;
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoPrestamo, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkDevuelto, 0);
            pnlFormularioBase.Controls.SetChildIndex(dtpFechaLimite, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblFechaLimite, 0);
            pnlFormularioBase.Controls.SetChildIndex(dtpFechaPrestamo, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblFechaPrestamo, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdEjemplarPrestamo, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdEjemplarPrestamo, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdEjemplarAgregar, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdUsuarioPrestamo, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnAgregarDetalle, 0);
            pnlFormularioBase.Controls.SetChildIndex(dgvEjemplares, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnEliminarDetalle, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnVaciarDetalle, 0);
            pnlFormularioBase.Controls.SetChildIndex(label1, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblContadorDetalle, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnExportar, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnImportar, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnVisor, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnRegistrarEstado, 0);
            pnlFormularioBase.Controls.SetChildIndex(btnDeshacer, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblCima, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblContadorHistorial, 0);
            pnlFormularioBase.Controls.SetChildIndex(lstHistorial, 0);
            // 
            // lblId
            // 
            lblId.Location = new Point(16, 20);
            // 
            // txtId
            // 
            txtId.Location = new Point(226, 16);
            txtId.Size = new Size(180, 31);
            // 
            // lblIdUsuarioPrestamo
            // 
            lblIdUsuarioPrestamo.AutoSize = true;
            lblIdUsuarioPrestamo.Location = new Point(20, 59);
            lblIdUsuarioPrestamo.Margin = new Padding(2, 0, 2, 0);
            lblIdUsuarioPrestamo.Name = "lblIdUsuarioPrestamo";
            lblIdUsuarioPrestamo.Size = new Size(99, 25);
            lblIdUsuarioPrestamo.TabIndex = 2;
            lblIdUsuarioPrestamo.Text = "ID Usuario:";
            // 
            // txtIdEjemplarAgregar
            // 
            txtIdEjemplarAgregar.Location = new Point(226, 160);
            txtIdEjemplarAgregar.Margin = new Padding(2);
            txtIdEjemplarAgregar.Name = "txtIdEjemplarAgregar";
            txtIdEjemplarAgregar.Size = new Size(180, 31);
            txtIdEjemplarAgregar.TabIndex = 3;
            txtIdEjemplarAgregar.TextChanged += txtIdEjemplarAgregar_TextChanged;
            // 
            // lblIdEjemplarPrestamo
            // 
            lblIdEjemplarPrestamo.AutoSize = true;
            lblIdEjemplarPrestamo.Location = new Point(14, 164);
            lblIdEjemplarPrestamo.Margin = new Padding(2, 0, 2, 0);
            lblIdEjemplarPrestamo.Name = "lblIdEjemplarPrestamo";
            lblIdEjemplarPrestamo.Size = new Size(107, 25);
            lblIdEjemplarPrestamo.TabIndex = 4;
            lblIdEjemplarPrestamo.Text = "ID Ejemplar:";
            // 
            // txtIdEjemplarPrestamo
            // 
            txtIdEjemplarPrestamo.Location = new Point(226, 69);
            txtIdEjemplarPrestamo.Margin = new Padding(2);
            txtIdEjemplarPrestamo.Name = "txtIdEjemplarPrestamo";
            txtIdEjemplarPrestamo.Size = new Size(180, 31);
            txtIdEjemplarPrestamo.TabIndex = 5;
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(425, 20);
            lblFechaPrestamo.Margin = new Padding(2, 0, 2, 0);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(167, 25);
            lblFechaPrestamo.TabIndex = 6;
            lblFechaPrestamo.Text = "Fecha de préstamo:";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            dtpFechaPrestamo.Location = new Point(601, 20);
            dtpFechaPrestamo.Margin = new Padding(2);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(195, 31);
            dtpFechaPrestamo.TabIndex = 7;
            // 
            // lblFechaLimite
            // 
            lblFechaLimite.AutoSize = true;
            lblFechaLimite.Location = new Point(425, 65);
            lblFechaLimite.Margin = new Padding(2, 0, 2, 0);
            lblFechaLimite.Name = "lblFechaLimite";
            lblFechaLimite.Size = new Size(109, 25);
            lblFechaLimite.TabIndex = 8;
            lblFechaLimite.Text = "Fecha límite:";
            // 
            // dtpFechaLimite
            // 
            dtpFechaLimite.Format = DateTimePickerFormat.Short;
            dtpFechaLimite.Location = new Point(601, 59);
            dtpFechaLimite.Margin = new Padding(2);
            dtpFechaLimite.Name = "dtpFechaLimite";
            dtpFechaLimite.Size = new Size(195, 31);
            dtpFechaLimite.TabIndex = 9;
            // 
            // chkDevuelto
            // 
            chkDevuelto.AutoSize = true;
            chkDevuelto.Location = new Point(484, 111);
            chkDevuelto.Margin = new Padding(2);
            chkDevuelto.Name = "chkDevuelto";
            chkDevuelto.Size = new Size(109, 29);
            chkDevuelto.TabIndex = 10;
            chkDevuelto.Text = "Devuelto";
            chkDevuelto.UseVisualStyleBackColor = true;
            // 
            // chkEstadoPrestamo
            // 
            chkEstadoPrestamo.AutoSize = true;
            chkEstadoPrestamo.Location = new Point(630, 111);
            chkEstadoPrestamo.Margin = new Padding(2);
            chkEstadoPrestamo.Name = "chkEstadoPrestamo";
            chkEstadoPrestamo.Size = new Size(88, 29);
            chkEstadoPrestamo.TabIndex = 11;
            chkEstadoPrestamo.Text = "Activo";
            chkEstadoPrestamo.UseVisualStyleBackColor = true;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(480, 158);
            btnAgregarDetalle.Margin = new Padding(4, 4, 4, 4);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(189, 36);
            btnAgregarDetalle.TabIndex = 14;
            btnAgregarDetalle.Text = "Agregar";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // dgvEjemplares
            // 
            dgvEjemplares.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEjemplares.Location = new Point(4, 208);
            dgvEjemplares.Margin = new Padding(4, 4, 4, 4);
            dgvEjemplares.Name = "dgvEjemplares";
            dgvEjemplares.RowHeadersWidth = 51;
            dgvEjemplares.Size = new Size(792, 119);
            dgvEjemplares.TabIndex = 16;
            // 
            // btnEliminarDetalle
            // 
            btnEliminarDetalle.Location = new Point(480, 338);
            btnEliminarDetalle.Margin = new Padding(4, 4, 4, 4);
            btnEliminarDetalle.Name = "btnEliminarDetalle";
            btnEliminarDetalle.Size = new Size(118, 36);
            btnEliminarDetalle.TabIndex = 17;
            btnEliminarDetalle.Text = "Eliminar";
            btnEliminarDetalle.UseVisualStyleBackColor = true;
            btnEliminarDetalle.Click += btnEliminarDetalle_Click;
            // 
            // btnVaciarDetalle
            // 
            btnVaciarDetalle.Location = new Point(630, 338);
            btnVaciarDetalle.Margin = new Padding(4, 4, 4, 4);
            btnVaciarDetalle.Name = "btnVaciarDetalle";
            btnVaciarDetalle.Size = new Size(118, 36);
            btnVaciarDetalle.TabIndex = 18;
            btnVaciarDetalle.Text = "Vaciar";
            btnVaciarDetalle.UseVisualStyleBackColor = true;
            btnVaciarDetalle.Click += btnVaciarDetalle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 349);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 19;
            label1.Text = "Total ítems:";
            // 
            // lblContadorDetalle
            // 
            lblContadorDetalle.AutoSize = true;
            lblContadorDetalle.Location = new Point(118, 349);
            lblContadorDetalle.Margin = new Padding(4, 0, 4, 0);
            lblContadorDetalle.Name = "lblContadorDetalle";
            lblContadorDetalle.Size = new Size(0, 25);
            lblContadorDetalle.TabIndex = 20;
            // 
            // btnExportar
            // 
            btnExportar.CausesValidation = false;
            btnExportar.Location = new Point(156, 338);
            btnExportar.Margin = new Padding(4, 4, 4, 4);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(94, 36);
            btnExportar.TabIndex = 22;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnImportar
            // 
            btnImportar.CausesValidation = false;
            btnImportar.Location = new Point(256, 338);
            btnImportar.Margin = new Padding(4, 4, 4, 4);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(94, 36);
            btnImportar.TabIndex = 23;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnVisor
            // 
            btnVisor.CausesValidation = false;
            btnVisor.Location = new Point(356, 338);
            btnVisor.Margin = new Padding(4, 4, 4, 4);
            btnVisor.Name = "btnVisor";
            btnVisor.Size = new Size(94, 36);
            btnVisor.TabIndex = 24;
            btnVisor.Text = "Visor";
            btnVisor.UseVisualStyleBackColor = true;
            btnVisor.Click += btnVisor_Click;
            // 
            // btnRegistrarEstado
            // 
            btnRegistrarEstado.CausesValidation = false;
            btnRegistrarEstado.Location = new Point(4, 384);
            btnRegistrarEstado.Margin = new Padding(4, 4, 4, 4);
            btnRegistrarEstado.Name = "btnRegistrarEstado";
            btnRegistrarEstado.Size = new Size(189, 36);
            btnRegistrarEstado.TabIndex = 25;
            btnRegistrarEstado.Text = "Registrar Estado";
            btnRegistrarEstado.UseVisualStyleBackColor = true;
            btnRegistrarEstado.Click += btnRegistrarEstado_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.CausesValidation = false;
            btnDeshacer.Location = new Point(200, 384);
            btnDeshacer.Margin = new Padding(4, 4, 4, 4);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(189, 36);
            btnDeshacer.TabIndex = 26;
            btnDeshacer.Text = "Deshacer Último";
            btnDeshacer.UseVisualStyleBackColor = true;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // lblContadorHistorial
            // 
            lblContadorHistorial.AutoSize = true;
            lblContadorHistorial.Location = new Point(410, 392);
            lblContadorHistorial.Margin = new Padding(4, 0, 4, 0);
            lblContadorHistorial.Name = "lblContadorHistorial";
            lblContadorHistorial.Size = new Size(215, 25);
            lblContadorHistorial.TabIndex = 27;
            lblContadorHistorial.Text = "Acciones en historial: 0";
            // 
            // lblCima
            // 
            lblCima.AutoSize = true;
            lblCima.Location = new Point(4, 430);
            lblCima.Margin = new Padding(4, 0, 4, 0);
            lblCima.Name = "lblCima";
            lblCima.Size = new Size(366, 25);
            lblCima.TabIndex = 28;
            lblCima.Text = "Siguiente acción a revertir: (ninguna)";
            // 
            // lstHistorial
            // 
            lstHistorial.FormattingEnabled = true;
            lstHistorial.HorizontalScrollbar = true;
            lstHistorial.ItemHeight = 25;
            lstHistorial.Location = new Point(4, 462);
            lstHistorial.Margin = new Padding(4, 4, 4, 4);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(792, 129);
            lstHistorial.TabIndex = 29;
            // 
            // FrmPrestamo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Name = "FrmPrestamo";
            Text = "FrmPrestamo";
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)epValidaciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEjemplares).EndInit();
            ResumeLayout(false);
        }



        private Label lblIdUsuarioPrestamo;
        private TextBox txtIdEjemplarAgregar;
        private Label lblIdEjemplarPrestamo;
        private TextBox txtIdEjemplarPrestamo;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Label lblFechaLimite;
        private DateTimePicker dtpFechaLimite;
        private CheckBox chkDevuelto;
        private CheckBox chkEstadoPrestamo;
        private Button btnAgregarDetalle;
        private DataGridView dgvEjemplares;
        private Label lblContadorDetalle;
        private Label label1;
        private Button btnVaciarDetalle;
        private Button btnEliminarDetalle;
        private Button btnExportar;
        private Button btnImportar;
        private Button btnVisor;
        private Button btnRegistrarEstado;
        private Button btnDeshacer;
        private Label lblCima;
        private Label lblContadorHistorial;
        private ListBox lstHistorial;
    }
}