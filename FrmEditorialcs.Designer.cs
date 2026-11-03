namespace SistemaBiblioteca1
{
    partial class FrmEditorialcs
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
            lblNombreEditorial = new Label();
            lblPaisOrigen = new Label();
            lblAnioFundacion = new Label();
            txtNombreEditorial = new TextBox();
            txtPaisOrigen = new TextBox();
            txtAnioFundacion = new TextBox();
            chkEstadoEditorial = new CheckBox();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(txtAnioFundacion);
            pnlFormularioBase.Controls.Add(txtPaisOrigen);
            pnlFormularioBase.Controls.Add(chkEstadoEditorial);
            pnlFormularioBase.Controls.Add(txtNombreEditorial);
            pnlFormularioBase.Size = new Size(622, 313);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtNombreEditorial, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoEditorial, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtPaisOrigen, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtAnioFundacion, 0);
            // 
            // lblNombreEditorial
            // 
            lblNombreEditorial.AutoSize = true;
            lblNombreEditorial.Location = new Point(12, 49);
            lblNombreEditorial.Name = "lblNombreEditorial";
            lblNombreEditorial.Size = new Size(67, 20);
            lblNombreEditorial.TabIndex = 0;
            lblNombreEditorial.Text = "Nombre:";
            // 
            // lblPaisOrigen
            // 
            lblPaisOrigen.AutoSize = true;
            lblPaisOrigen.Location = new Point(12, 88);
            lblPaisOrigen.Name = "lblPaisOrigen";
            lblPaisOrigen.Size = new Size(105, 20);
            lblPaisOrigen.TabIndex = 1;
            lblPaisOrigen.Text = "Pais de origen:";
            // 
            // lblAnioFundacion
            // 
            lblAnioFundacion.AutoSize = true;
            lblAnioFundacion.Location = new Point(12, 130);
            lblAnioFundacion.Name = "lblAnioFundacion";
            lblAnioFundacion.Size = new Size(130, 20);
            lblAnioFundacion.TabIndex = 2;
            lblAnioFundacion.Text = "Año de fundación:";
            // 
            // txtNombreEditorial
            // 
            txtNombreEditorial.Location = new Point(184, 55);
            txtNombreEditorial.Name = "txtNombreEditorial";
            txtNombreEditorial.Size = new Size(185, 27);
            txtNombreEditorial.TabIndex = 3;
            // 
            // txtPaisOrigen
            // 
            txtPaisOrigen.Location = new Point(184, 88);
            txtPaisOrigen.Name = "txtPaisOrigen";
            txtPaisOrigen.Size = new Size(185, 27);
            txtPaisOrigen.TabIndex = 4;
            // 
            // txtAnioFundacion
            // 
            txtAnioFundacion.Location = new Point(184, 127);
            txtAnioFundacion.MaxLength = 4;
            txtAnioFundacion.Name = "txtAnioFundacion";
            txtAnioFundacion.PlaceholderText = "2007";
            txtAnioFundacion.Size = new Size(53, 27);
            txtAnioFundacion.TabIndex = 5;
            // 
            // chkEstadoEditorial
            // 
            chkEstadoEditorial.AutoSize = true;
            chkEstadoEditorial.Location = new Point(184, 171);
            chkEstadoEditorial.Name = "chkEstadoEditorial";
            chkEstadoEditorial.Size = new Size(72, 24);
            chkEstadoEditorial.TabIndex = 6;
            chkEstadoEditorial.Text = "Activa";
            chkEstadoEditorial.UseVisualStyleBackColor = true;
            // 
            // FrmEditorialcs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 313);
            Controls.Add(lblAnioFundacion);
            Controls.Add(lblPaisOrigen);
            Controls.Add(lblNombreEditorial);
            Name = "FrmEditorialcs";
            Text = "FrmEditorialcs";
            Controls.SetChildIndex(pnlFormularioBase, 0);
            Controls.SetChildIndex(lblNombreEditorial, 0);
            Controls.SetChildIndex(lblPaisOrigen, 0);
            Controls.SetChildIndex(lblAnioFundacion, 0);
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreEditorial;
        private Label lblPaisOrigen;
        private Label lblAnioFundacion;
        private TextBox txtNombreEditorial;
        private TextBox txtPaisOrigen;
        private TextBox txtAnioFundacion;
        private CheckBox chkEstadoEditorial;
    }
}