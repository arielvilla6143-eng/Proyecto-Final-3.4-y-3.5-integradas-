// Actividad 2.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
namespace SistemaBiblioteca1
{
    partial class FrmBase
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
            components = new System.ComponentModel.Container();
            pnlFormularioBase = new Panel();
            lblId = new Label();
            txtId = new TextBox();
            epValidaciones = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)epValidaciones).BeginInit();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(lblId);
            pnlFormularioBase.Controls.Add(txtId);
            pnlFormularioBase.Dock = DockStyle.Fill;
            pnlFormularioBase.Location = new Point(0, 0);
            pnlFormularioBase.Margin = new Padding(2, 2, 2, 2);
            pnlFormularioBase.Name = "pnlFormularioBase";
            pnlFormularioBase.Size = new Size(640, 360);
            pnlFormularioBase.TabIndex = 0;
            pnlFormularioBase.Paint += pnlFormularioBase_Paint;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(16, 20);
            lblId.Margin = new Padding(2, 0, 2, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(184, 18);
            txtId.Margin = new Padding(2, 2, 2, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(185, 27);
            txtId.TabIndex = 1;
            // 
            // epValidaciones
            // 
            epValidaciones.ContainerControl = this;
            // 
            // FrmBase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(pnlFormularioBase);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FrmBase";
            Text = "FrmBase";
            ((System.ComponentModel.ISupportInitialize)epValidaciones).EndInit();
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected Panel pnlFormularioBase;
        protected Label lblId;
        protected TextBox txtId;
        protected ErrorProvider epValidaciones;
    }
}