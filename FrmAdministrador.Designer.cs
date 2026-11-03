namespace SistemaBiblioteca1
{
    partial class FrmAdministrador
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombreAdmin = new Label();
            lblApellidoAdmin = new Label();
            lblUsuarioAdmin = new Label();
            lblContrasena = new Label();
            lblNivelAcceso = new Label();
            chkEstadoAdmin = new CheckBox();
            txtNombreAdmin = new TextBox();
            txtApellidoAdmin = new TextBox();
            txtUsuarioAcceso = new TextBox();
            txtContrasena = new TextBox();
            cmbNivelAcceso = new ComboBox();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(txtUsuarioAcceso);
            pnlFormularioBase.Controls.Add(txtApellidoAdmin);
            pnlFormularioBase.Controls.Add(chkEstadoAdmin);
            pnlFormularioBase.Controls.Add(txtNombreAdmin);
            pnlFormularioBase.Controls.Add(lblNivelAcceso);
            pnlFormularioBase.Controls.Add(lblUsuarioAdmin);
            pnlFormularioBase.Controls.Add(lblNombreAdmin);
            pnlFormularioBase.Controls.Add(lblApellidoAdmin);
            pnlFormularioBase.Controls.Add(cmbNivelAcceso);
            pnlFormularioBase.Controls.Add(lblContrasena);
            pnlFormularioBase.Controls.Add(txtContrasena);
            pnlFormularioBase.Size = new Size(622, 313);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtContrasena, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblContrasena, 0);
            pnlFormularioBase.Controls.SetChildIndex(cmbNivelAcceso, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblApellidoAdmin, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblNombreAdmin, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblUsuarioAdmin, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblNivelAcceso, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtNombreAdmin, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoAdmin, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtApellidoAdmin, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtUsuarioAcceso, 0);
            // 
            // lblNombreAdmin
            // 
            lblNombreAdmin.AutoSize = true;
            lblNombreAdmin.Location = new Point(12, 49);
            lblNombreAdmin.Name = "lblNombreAdmin";
            lblNombreAdmin.Size = new Size(67, 20);
            lblNombreAdmin.TabIndex = 0;
            lblNombreAdmin.Text = "Nombre:";
            // 
            // lblApellidoAdmin
            // 
            lblApellidoAdmin.AutoSize = true;
            lblApellidoAdmin.Location = new Point(12, 86);
            lblApellidoAdmin.Name = "lblApellidoAdmin";
            lblApellidoAdmin.Size = new Size(69, 20);
            lblApellidoAdmin.TabIndex = 1;
            lblApellidoAdmin.Text = "Apellido:";
            // 
            // lblUsuarioAdmin
            // 
            lblUsuarioAdmin.AutoSize = true;
            lblUsuarioAdmin.Location = new Point(12, 126);
            lblUsuarioAdmin.Name = "lblUsuarioAdmin";
            lblUsuarioAdmin.Size = new Size(62, 20);
            lblUsuarioAdmin.TabIndex = 2;
            lblUsuarioAdmin.Text = "Usuario:";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(12, 166);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(86, 20);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña:";
            // 
            // lblNivelAcceso
            // 
            lblNivelAcceso.AutoSize = true;
            lblNivelAcceso.Location = new Point(12, 203);
            lblNivelAcceso.Name = "lblNivelAcceso";
            lblNivelAcceso.Size = new Size(137, 20);
            lblNivelAcceso.TabIndex = 4;
            lblNivelAcceso.Text = "Nivel Acceso (1-3): ";
            // 
            // chkEstadoAdmin
            // 
            chkEstadoAdmin.AutoSize = true;
            chkEstadoAdmin.Location = new Point(184, 245);
            chkEstadoAdmin.Name = "chkEstadoAdmin";
            chkEstadoAdmin.Size = new Size(73, 24);
            chkEstadoAdmin.TabIndex = 5;
            chkEstadoAdmin.Text = "Activo";
            chkEstadoAdmin.UseVisualStyleBackColor = true;
            // 
            // txtNombreAdmin
            // 
            txtNombreAdmin.Location = new Point(184, 50);
            txtNombreAdmin.Name = "txtNombreAdmin";
            txtNombreAdmin.Size = new Size(185, 27);
            txtNombreAdmin.TabIndex = 6;
            // 
            // txtApellidoAdmin
            // 
            txtApellidoAdmin.Location = new Point(184, 86);
            txtApellidoAdmin.Name = "txtApellidoAdmin";
            txtApellidoAdmin.Size = new Size(185, 27);
            txtApellidoAdmin.TabIndex = 7;
            // 
            // txtUsuarioAcceso
            // 
            txtUsuarioAcceso.Location = new Point(184, 123);
            txtUsuarioAcceso.Name = "txtUsuarioAcceso";
            txtUsuarioAcceso.Size = new Size(185, 27);
            txtUsuarioAcceso.TabIndex = 8;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(184, 163);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(185, 27);
            txtContrasena.TabIndex = 9;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // cmbNivelAcceso
            // 
            cmbNivelAcceso.FormattingEnabled = true;
            cmbNivelAcceso.Items.AddRange(new object[] { "1", "2", "3" });
            cmbNivelAcceso.Location = new Point(184, 200);
            cmbNivelAcceso.Name = "cmbNivelAcceso";
            cmbNivelAcceso.Size = new Size(77, 28);
            cmbNivelAcceso.TabIndex = 10;
            // 
            // FrmAdministrador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 313);
            Name = "FrmAdministrador";
            Text = "FrmAdministrador";
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblNombreAdmin;
        private Label lblApellidoAdmin;
        private Label lblUsuarioAdmin;
        private Label lblContrasena;
        private Label lblNivelAcceso;
        private CheckBox chkEstadoAdmin;
        private TextBox txtNombreAdmin;
        private TextBox txtApellidoAdmin;
        private TextBox txtUsuarioAcceso;
        private TextBox txtContrasena;
        private ComboBox cmbNivelAcceso;
    }
}