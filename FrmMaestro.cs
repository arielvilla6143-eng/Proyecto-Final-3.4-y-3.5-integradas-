// Actividad 2.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
namespace SistemaBiblioteca1
{
    partial class FrmMaestro
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


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlContenedorVistas = new Panel();
            pnlSuperior = new Panel();
            lblModulo = new Label();
            cmbModulo = new ComboBox();
            lblIdBusqueda = new Label();
            txtIdBusqueda = new TextBox();
            btnMasterBuscar = new BotonPersona3();
            pnlInferior = new Panel();
            btnMasterGuardar = new BotonPersona3();
            btnMasterActualizar = new BotonPersona3();
            btnMasterEliminar = new BotonPersona3();
            statusStrip1 = new StatusStrip();
            tsslEstado = new ToolStripStatusLabel();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pnlContenedorVistas.SuspendLayout();
            pnlSuperior.SuspendLayout();
            pnlInferior.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlContenedorVistas
            // 
            pnlContenedorVistas.Controls.Add(label4);
            pnlContenedorVistas.Controls.Add(label3);
            pnlContenedorVistas.Controls.Add(label2);
            pnlContenedorVistas.Controls.Add(label1);
            pnlContenedorVistas.Dock = DockStyle.Fill;
            pnlContenedorVistas.Location = new Point(0, 56);
            pnlContenedorVistas.Margin = new Padding(2, 2, 2, 2);
            pnlContenedorVistas.Name = "pnlContenedorVistas";
            pnlContenedorVistas.Size = new Size(720, 342);
            pnlContenedorVistas.TabIndex = 1;
            // 
            // pnlSuperior
            // 
            pnlSuperior.Controls.Add(lblModulo);
            pnlSuperior.Controls.Add(cmbModulo);
            pnlSuperior.Controls.Add(lblIdBusqueda);
            pnlSuperior.Controls.Add(txtIdBusqueda);
            pnlSuperior.Controls.Add(btnMasterBuscar);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Margin = new Padding(2, 2, 2, 2);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(720, 56);
            pnlSuperior.TabIndex = 0;
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Location = new Point(12, 18);
            lblModulo.Margin = new Padding(2, 0, 2, 0);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(64, 20);
            lblModulo.TabIndex = 0;
            lblModulo.Text = "Módulo:";
            // 
            // cmbModulo
            // 
            cmbModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModulo.FormattingEnabled = true;
            cmbModulo.Location = new Point(80, 14);
            cmbModulo.Margin = new Padding(2, 2, 2, 2);
            cmbModulo.Name = "cmbModulo";
            cmbModulo.CausesValidation = false;
            cmbModulo.Size = new Size(177, 28);
            cmbModulo.TabIndex = 1;
            cmbModulo.SelectedIndexChanged += cmbModulo_SelectedIndexChanged;
            // 
            // lblIdBusqueda
            // 
            lblIdBusqueda.AutoSize = true;
            lblIdBusqueda.Location = new Point(272, 18);
            lblIdBusqueda.Margin = new Padding(2, 0, 2, 0);
            lblIdBusqueda.Name = "lblIdBusqueda";
            lblIdBusqueda.Size = new Size(86, 20);
            lblIdBusqueda.TabIndex = 2;
            lblIdBusqueda.Text = "ID a buscar:";
            // 
            // txtIdBusqueda
            // 
            txtIdBusqueda.Location = new Point(364, 14);
            txtIdBusqueda.Margin = new Padding(2, 2, 2, 2);
            txtIdBusqueda.Name = "txtIdBusqueda";
            txtIdBusqueda.CausesValidation = false;
            txtIdBusqueda.Size = new Size(97, 27);
            txtIdBusqueda.TabIndex = 3;
            txtIdBusqueda.TextChanged += txtIdBusqueda_TextChanged;
            // 
            // btnMasterBuscar
            // 
            btnMasterBuscar.Location = new Point(476, 12);
            btnMasterBuscar.Margin = new Padding(2, 2, 2, 2);
            btnMasterBuscar.Name = "btnMasterBuscar";
            btnMasterBuscar.CausesValidation = false;
            btnMasterBuscar.Size = new Size(96, 32);
            btnMasterBuscar.TabIndex = 4;
            btnMasterBuscar.Text = "Buscar";
            btnMasterBuscar.UseVisualStyleBackColor = true;
            btnMasterBuscar.Click += btnMasterBuscar_Click;
            // 
            // pnlInferior
            // 
            pnlInferior.Controls.Add(btnMasterGuardar);
            pnlInferior.Controls.Add(btnMasterActualizar);
            pnlInferior.Controls.Add(btnMasterEliminar);
            pnlInferior.Dock = DockStyle.Bottom;
            pnlInferior.Location = new Point(0, 398);
            pnlInferior.Margin = new Padding(2, 2, 2, 2);
            pnlInferior.Name = "pnlInferior";
            pnlInferior.Size = new Size(720, 56);
            pnlInferior.TabIndex = 2;
            // 
            // btnMasterGuardar
            // 
            btnMasterGuardar.Location = new Point(12, 12);
            btnMasterGuardar.Margin = new Padding(2, 2, 2, 2);
            btnMasterGuardar.Name = "btnMasterGuardar";
            btnMasterGuardar.Size = new Size(120, 32);
            btnMasterGuardar.TabIndex = 0;
            btnMasterGuardar.Text = "Guardar";
            btnMasterGuardar.UseVisualStyleBackColor = true;
            btnMasterGuardar.Click += btnMasterGuardar_Click;
            // 
            // btnMasterActualizar
            // 
            btnMasterActualizar.Location = new Point(144, 12);
            btnMasterActualizar.Margin = new Padding(2, 2, 2, 2);
            btnMasterActualizar.Name = "btnMasterActualizar";
            btnMasterActualizar.Size = new Size(120, 32);
            btnMasterActualizar.TabIndex = 1;
            btnMasterActualizar.Text = "Actualizar";
            btnMasterActualizar.UseVisualStyleBackColor = true;
            btnMasterActualizar.Click += btnMasterActualizar_Click;
            // 
            // btnMasterEliminar
            // 
            btnMasterEliminar.Location = new Point(276, 12);
            btnMasterEliminar.Margin = new Padding(2, 2, 2, 2);
            btnMasterEliminar.Name = "btnMasterEliminar";
            btnMasterEliminar.CausesValidation = false;
            btnMasterEliminar.Size = new Size(120, 32);
            btnMasterEliminar.TabIndex = 2;
            btnMasterEliminar.Text = "Eliminar";
            btnMasterEliminar.UseVisualStyleBackColor = true;
            btnMasterEliminar.Click += btnMasterEliminar_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslEstado });
            statusStrip1.Location = new Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 11, 0);
            statusStrip1.Size = new Size(720, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslEstado
            // 
            tsslEstado.Name = "tsslEstado";
            tsslEstado.Size = new Size(159, 20);
            tsslEstado.Text = "Listo. Elige un módulo.";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(559, 18);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Equipo #2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(538, 53);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 1;
            label2.Text = "Villa Olivarez Ariel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(494, 86);
            label3.Name = "label3";
            label3.Size = new Size(211, 20);
            label3.TabIndex = 2;
            label3.Text = "Suñiga Macile Joule Alexander";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(489, 123);
            label4.Name = "label4";
            label4.Size = new Size(216, 20);
            label4.TabIndex = 3;
            label4.Text = "Nuñez Martinez Marco Antonio";
            // 
            // FrmMaestro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 480);
            Controls.Add(pnlContenedorVistas);
            Controls.Add(pnlInferior);
            Controls.Add(pnlSuperior);
            Controls.Add(statusStrip1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FrmMaestro";
            Text = "Sistema de Biblioteca";
            pnlContenedorVistas.ResumeLayout(false);
            pnlContenedorVistas.PerformLayout();
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlInferior.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        private Panel pnlContenedorVistas;
        private Panel pnlSuperior;
        private Label lblModulo;
        private ComboBox cmbModulo;
        private Label lblIdBusqueda;
        private TextBox txtIdBusqueda;
        private BotonPersona3 btnMasterBuscar;
        private Panel pnlInferior;
        private BotonPersona3 btnMasterGuardar;
        private BotonPersona3 btnMasterActualizar;
        private BotonPersona3 btnMasterEliminar;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslEstado;
        private ErrorProvider errorProvider1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
    }
}