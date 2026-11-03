// Actividad 2.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
namespace SistemaBiblioteca1
{
    partial class FrmUsuario
    {
        private void InitializeComponent()
        {
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblApellidoUsuario = new Label();
            txtApellidoUsuario = new TextBox();
            lblEmailUsuario = new Label();
            txtEmailUsuario = new TextBox();
            lblTelefonoUsuario = new Label();
            txtTelefonoUsuario = new TextBox();
            lblIdUniversitarioUsuario = new Label();
            txtIdUniversitarioUsuario = new TextBox();
            chkEstadoUsuario = new CheckBox();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(lblNombreUsuario);
            pnlFormularioBase.Controls.Add(txtNombreUsuario);
            pnlFormularioBase.Controls.Add(lblApellidoUsuario);
            pnlFormularioBase.Controls.Add(txtApellidoUsuario);
            pnlFormularioBase.Controls.Add(lblEmailUsuario);
            pnlFormularioBase.Controls.Add(txtEmailUsuario);
            pnlFormularioBase.Controls.Add(lblTelefonoUsuario);
            pnlFormularioBase.Controls.Add(txtTelefonoUsuario);
            pnlFormularioBase.Controls.Add(lblIdUniversitarioUsuario);
            pnlFormularioBase.Controls.Add(txtIdUniversitarioUsuario);
            pnlFormularioBase.Controls.Add(chkEstadoUsuario);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdUniversitarioUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdUniversitarioUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtTelefonoUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblTelefonoUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtEmailUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblEmailUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtApellidoUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblApellidoUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtNombreUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblNombreUsuario, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            // 
            // lblId
            // 
            lblId.Location = new Point(13, 16);
            // 
            // txtId
            // 
            txtId.Location = new Point(184, 16);
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(16, 60);
            lblNombreUsuario.Margin = new Padding(2, 0, 2, 0);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(67, 20);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "Nombre:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(184, 58);
            txtNombreUsuario.Margin = new Padding(2, 2, 2, 2);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(185, 27);
            txtNombreUsuario.TabIndex = 3;
            // 
            // lblApellidoUsuario
            // 
            lblApellidoUsuario.AutoSize = true;
            lblApellidoUsuario.Location = new Point(16, 96);
            lblApellidoUsuario.Margin = new Padding(2, 0, 2, 0);
            lblApellidoUsuario.Name = "lblApellidoUsuario";
            lblApellidoUsuario.Size = new Size(75, 20);
            lblApellidoUsuario.TabIndex = 4;
            lblApellidoUsuario.Text = "Apellidos:";
            // 
            // txtApellidoUsuario
            // 
            txtApellidoUsuario.Location = new Point(184, 94);
            txtApellidoUsuario.Margin = new Padding(2, 2, 2, 2);
            txtApellidoUsuario.Name = "txtApellidoUsuario";
            txtApellidoUsuario.Size = new Size(185, 27);
            txtApellidoUsuario.TabIndex = 5;
            // 
            // lblEmailUsuario
            // 
            lblEmailUsuario.AutoSize = true;
            lblEmailUsuario.Location = new Point(16, 132);
            lblEmailUsuario.Margin = new Padding(2, 0, 2, 0);
            lblEmailUsuario.Name = "lblEmailUsuario";
            lblEmailUsuario.Size = new Size(135, 20);
            lblEmailUsuario.TabIndex = 6;
            lblEmailUsuario.Text = "Correo electronico:";
            // 
            // txtEmailUsuario
            // 
            txtEmailUsuario.Location = new Point(184, 130);
            txtEmailUsuario.Margin = new Padding(2, 2, 2, 2);
            txtEmailUsuario.Name = "txtEmailUsuario";
            txtEmailUsuario.Size = new Size(185, 27);
            txtEmailUsuario.TabIndex = 7;
            // 
            // lblTelefonoUsuario
            // 
            lblTelefonoUsuario.AutoSize = true;
            lblTelefonoUsuario.Location = new Point(16, 168);
            lblTelefonoUsuario.Margin = new Padding(2, 0, 2, 0);
            lblTelefonoUsuario.Name = "lblTelefonoUsuario";
            lblTelefonoUsuario.Size = new Size(150, 20);
            lblTelefonoUsuario.TabIndex = 8;
            lblTelefonoUsuario.Text = "Teléfono (10 dígitos):";
            lblTelefonoUsuario.Click += lblTelefonoUsuario_Click;
            // 
            // txtTelefonoUsuario
            // 
            txtTelefonoUsuario.Location = new Point(184, 166);
            txtTelefonoUsuario.Margin = new Padding(2, 2, 2, 2);
            txtTelefonoUsuario.MaxLength = 10;
            txtTelefonoUsuario.Name = "txtTelefonoUsuario";
            txtTelefonoUsuario.Size = new Size(185, 27);
            txtTelefonoUsuario.TabIndex = 9;
            // 
            // lblIdUniversitarioUsuario
            // 
            lblIdUniversitarioUsuario.AutoSize = true;
            lblIdUniversitarioUsuario.Location = new Point(16, 204);
            lblIdUniversitarioUsuario.Margin = new Padding(2, 0, 2, 0);
            lblIdUniversitarioUsuario.Name = "lblIdUniversitarioUsuario";
            lblIdUniversitarioUsuario.Size = new Size(112, 20);
            lblIdUniversitarioUsuario.TabIndex = 10;
            lblIdUniversitarioUsuario.Text = "ID universitario:";
            // 
            // txtIdUniversitarioUsuario
            // 
            txtIdUniversitarioUsuario.Location = new Point(184, 202);
            txtIdUniversitarioUsuario.Margin = new Padding(2, 2, 2, 2);
            txtIdUniversitarioUsuario.Name = "txtIdUniversitarioUsuario";
            txtIdUniversitarioUsuario.Size = new Size(185, 27);
            txtIdUniversitarioUsuario.TabIndex = 11;
            // 
            // chkEstadoUsuario
            // 
            chkEstadoUsuario.AutoSize = true;
            chkEstadoUsuario.Location = new Point(184, 240);
            chkEstadoUsuario.Margin = new Padding(2, 2, 2, 2);
            chkEstadoUsuario.Name = "chkEstadoUsuario";
            chkEstadoUsuario.Size = new Size(73, 24);
            chkEstadoUsuario.TabIndex = 12;
            chkEstadoUsuario.Text = "Activo";
            chkEstadoUsuario.UseVisualStyleBackColor = true;
            // 
            // FrmUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Name = "FrmUsuario";
            Text = "FrmUsuario";
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblApellidoUsuario;
        private TextBox txtApellidoUsuario;
        private Label lblEmailUsuario;
        private TextBox txtEmailUsuario;
        private Label lblTelefonoUsuario;
        private TextBox txtTelefonoUsuario;
        private Label lblIdUniversitarioUsuario;
        private TextBox txtIdUniversitarioUsuario;
        private CheckBox chkEstadoUsuario;
    }
}