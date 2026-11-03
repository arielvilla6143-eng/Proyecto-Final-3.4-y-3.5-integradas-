namespace SistemaBiblioteca1
{
    partial class FrmEjemplar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIdLibroEjemplar = new Label();
            lblCodigoInventario = new Label();
            txtIdLIbroEjemplar = new TextBox();
            txtCodigoInventario = new TextBox();
            lblCondicion = new Label();
            chkDisponible = new CheckBox();
            chkEstadoEjemplar = new CheckBox();
            cmbCondicion = new ComboBox();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(cmbCondicion);
            pnlFormularioBase.Controls.Add(txtCodigoInventario);
            pnlFormularioBase.Controls.Add(chkDisponible);
            pnlFormularioBase.Controls.Add(lblCondicion);
            pnlFormularioBase.Controls.Add(chkEstadoEjemplar);
            pnlFormularioBase.Controls.Add(txtIdLIbroEjemplar);
            pnlFormularioBase.Controls.Add(lblCodigoInventario);
            pnlFormularioBase.Controls.Add(lblIdLibroEjemplar);
            pnlFormularioBase.Size = new Size(622, 313);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdLibroEjemplar, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblCodigoInventario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdLIbroEjemplar, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoEjemplar, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblCondicion, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkDisponible, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtCodigoInventario, 0);
            pnlFormularioBase.Controls.SetChildIndex(cmbCondicion, 0);
            // 
            // txtId
            // 
            txtId.Location = new Point(170, 17);
            // 
            // lblIdLibroEjemplar
            // 
            lblIdLibroEjemplar.AutoSize = true;
            lblIdLibroEjemplar.Location = new Point(12, 63);
            lblIdLibroEjemplar.Name = "lblIdLibroEjemplar";
            lblIdLibroEjemplar.Size = new Size(65, 20);
            lblIdLibroEjemplar.TabIndex = 0;
            lblIdLibroEjemplar.Text = "ID Libro:";
            // 
            // lblCodigoInventario
            // 
            lblCodigoInventario.AutoSize = true;
            lblCodigoInventario.Location = new Point(12, 103);
            lblCodigoInventario.Name = "lblCodigoInventario";
            lblCodigoInventario.Size = new Size(131, 20);
            lblCodigoInventario.TabIndex = 1;
            lblCodigoInventario.Text = "Codigo Inventario:";
            // 
            // txtIdLIbroEjemplar
            // 
            txtIdLIbroEjemplar.Location = new Point(170, 60);
            txtIdLIbroEjemplar.Name = "txtIdLIbroEjemplar";
            txtIdLIbroEjemplar.Size = new Size(185, 27);
            txtIdLIbroEjemplar.TabIndex = 2;
            // 
            // txtCodigoInventario
            // 
            txtCodigoInventario.Location = new Point(170, 100);
            txtCodigoInventario.Name = "txtCodigoInventario";
            txtCodigoInventario.Size = new Size(185, 27);
            txtCodigoInventario.TabIndex = 3;
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.Location = new Point(12, 148);
            lblCondicion.Name = "lblCondicion";
            lblCondicion.Size = new Size(79, 20);
            lblCondicion.TabIndex = 4;
            lblCondicion.Text = "Condición:";
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Location = new Point(170, 197);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(103, 24);
            chkDisponible.TabIndex = 6;
            chkDisponible.Text = "Disponible";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // chkEstadoEjemplar
            // 
            chkEstadoEjemplar.AutoSize = true;
            chkEstadoEjemplar.Location = new Point(170, 242);
            chkEstadoEjemplar.Name = "chkEstadoEjemplar";
            chkEstadoEjemplar.RightToLeft = RightToLeft.No;
            chkEstadoEjemplar.Size = new Size(73, 24);
            chkEstadoEjemplar.TabIndex = 7;
            chkEstadoEjemplar.Text = "Activo";
            chkEstadoEjemplar.UseVisualStyleBackColor = true;
            // 
            // cmbCondicion
            // 
            cmbCondicion.FormattingEnabled = true;
            cmbCondicion.Items.AddRange(new object[] { "Nuevo", "Bueno", "Regular", "Dañado" });
            cmbCondicion.Location = new Point(170, 145);
            cmbCondicion.Name = "cmbCondicion";
            cmbCondicion.Size = new Size(185, 28);
            cmbCondicion.TabIndex = 8;
            // 
            // FrmEjemplar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 313);
            Name = "FrmEjemplar";
            Text = "FrmEjemplar";
            Load += FrmEjemplar_Load;
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblIdLibroEjemplar;
        private Label lblCodigoInventario;
        private TextBox txtIdLIbroEjemplar;
        private TextBox txtCodigoInventario;
        private Label lblCondicion;
        private CheckBox chkDisponible;
        private CheckBox chkEstadoEjemplar;
        private ComboBox cmbCondicion;
    }
}