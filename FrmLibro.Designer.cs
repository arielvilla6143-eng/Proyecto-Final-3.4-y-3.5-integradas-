// Actividad 2.4 - Equipo #2
//   SUÑIGA Maciel Joule Alexander
//   VILLA Olivarez Ariel
//   NUÑEZ Martinez Marco Antonio
// ===============================
namespace SistemaBiblioteca1
{
    partial class FrmLibro
    {
        private void InitializeComponent()
        {
            lblTituloLibro = new Label();
            txtTituloLibro = new TextBox();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            lblIdAutorLibro = new Label();
            txtIdAutorLibro = new TextBox();
            lblIdCategoriaLibro = new Label();
            txtIdCategoriaLibro = new TextBox();
            lblIdEditorialLibro = new Label();
            txtIdEditorialLibro = new TextBox();
            lblAnioPublicacion = new Label();
            txtAnioPublicacion = new TextBox();
            chkEstadoLibro = new CheckBox();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(lblTituloLibro);
            pnlFormularioBase.Controls.Add(txtTituloLibro);
            pnlFormularioBase.Controls.Add(lblIsbn);
            pnlFormularioBase.Controls.Add(txtIsbn);
            pnlFormularioBase.Controls.Add(lblIdAutorLibro);
            pnlFormularioBase.Controls.Add(txtIdAutorLibro);
            pnlFormularioBase.Controls.Add(lblIdCategoriaLibro);
            pnlFormularioBase.Controls.Add(txtIdCategoriaLibro);
            pnlFormularioBase.Controls.Add(lblIdEditorialLibro);
            pnlFormularioBase.Controls.Add(txtIdEditorialLibro);
            pnlFormularioBase.Controls.Add(lblAnioPublicacion);
            pnlFormularioBase.Controls.Add(txtAnioPublicacion);
            pnlFormularioBase.Controls.Add(chkEstadoLibro);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtAnioPublicacion, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblAnioPublicacion, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdEditorialLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdEditorialLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdCategoriaLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdCategoriaLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIdAutorLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdAutorLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtIsbn, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIsbn, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtTituloLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblTituloLibro, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            // 
            // lblId
            // 
            lblId.Location = new Point(13, 16);
            // 
            // txtId
            // 
            txtId.Location = new Point(184, 13);
            // 
            // lblTituloLibro
            // 
            lblTituloLibro.AutoSize = true;
            lblTituloLibro.Location = new Point(16, 58);
            lblTituloLibro.Margin = new Padding(2, 0, 2, 0);
            lblTituloLibro.Name = "lblTituloLibro";
            lblTituloLibro.Size = new Size(50, 20);
            lblTituloLibro.TabIndex = 2;
            lblTituloLibro.Text = "Título:";
            // 
            // txtTituloLibro
            // 
            txtTituloLibro.Location = new Point(184, 56);
            txtTituloLibro.Margin = new Padding(2, 2, 2, 2);
            txtTituloLibro.Name = "txtTituloLibro";
            txtTituloLibro.Size = new Size(185, 27);
            txtTituloLibro.TabIndex = 3;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(16, 90);
            lblIsbn.Margin = new Padding(2, 0, 2, 0);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(44, 20);
            lblIsbn.TabIndex = 4;
            lblIsbn.Text = "ISBN:";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(184, 88);
            txtIsbn.Margin = new Padding(2, 2, 2, 2);
            txtIsbn.MaxLength = 13;
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(185, 27);
            txtIsbn.TabIndex = 5;
            // 
            // lblIdAutorLibro
            // 
            lblIdAutorLibro.AutoSize = true;
            lblIdAutorLibro.Location = new Point(16, 122);
            lblIdAutorLibro.Margin = new Padding(2, 0, 2, 0);
            lblIdAutorLibro.Name = "lblIdAutorLibro";
            lblIdAutorLibro.Size = new Size(68, 20);
            lblIdAutorLibro.TabIndex = 6;
            lblIdAutorLibro.Text = "ID Autor:";
            // 
            // txtIdAutorLibro
            // 
            txtIdAutorLibro.Location = new Point(184, 120);
            txtIdAutorLibro.Margin = new Padding(2, 2, 2, 2);
            txtIdAutorLibro.Name = "txtIdAutorLibro";
            txtIdAutorLibro.Size = new Size(185, 27);
            txtIdAutorLibro.TabIndex = 7;
            // 
            // lblIdCategoriaLibro
            // 
            lblIdCategoriaLibro.AutoSize = true;
            lblIdCategoriaLibro.Location = new Point(16, 154);
            lblIdCategoriaLibro.Margin = new Padding(2, 0, 2, 0);
            lblIdCategoriaLibro.Name = "lblIdCategoriaLibro";
            lblIdCategoriaLibro.Size = new Size(96, 20);
            lblIdCategoriaLibro.TabIndex = 8;
            lblIdCategoriaLibro.Text = "ID Categoría:";
            // 
            // txtIdCategoriaLibro
            // 
            txtIdCategoriaLibro.Location = new Point(184, 152);
            txtIdCategoriaLibro.Margin = new Padding(2, 2, 2, 2);
            txtIdCategoriaLibro.Name = "txtIdCategoriaLibro";
            txtIdCategoriaLibro.Size = new Size(185, 27);
            txtIdCategoriaLibro.TabIndex = 9;
            // 
            // lblIdEditorialLibro
            // 
            lblIdEditorialLibro.AutoSize = true;
            lblIdEditorialLibro.Location = new Point(16, 186);
            lblIdEditorialLibro.Margin = new Padding(2, 0, 2, 0);
            lblIdEditorialLibro.Name = "lblIdEditorialLibro";
            lblIdEditorialLibro.Size = new Size(87, 20);
            lblIdEditorialLibro.TabIndex = 10;
            lblIdEditorialLibro.Text = "ID Editorial:";
            // 
            // txtIdEditorialLibro
            // 
            txtIdEditorialLibro.Location = new Point(184, 184);
            txtIdEditorialLibro.Margin = new Padding(2, 2, 2, 2);
            txtIdEditorialLibro.Name = "txtIdEditorialLibro";
            txtIdEditorialLibro.Size = new Size(185, 27);
            txtIdEditorialLibro.TabIndex = 11;
            // 
            // lblAnioPublicacion
            // 
            lblAnioPublicacion.AutoSize = true;
            lblAnioPublicacion.Location = new Point(16, 218);
            lblAnioPublicacion.Margin = new Padding(2, 0, 2, 0);
            lblAnioPublicacion.Name = "lblAnioPublicacion";
            lblAnioPublicacion.Size = new Size(141, 20);
            lblAnioPublicacion.TabIndex = 12;
            lblAnioPublicacion.Text = "Año de publicación:";
            // 
            // txtAnioPublicacion
            // 
            txtAnioPublicacion.Location = new Point(184, 216);
            txtAnioPublicacion.Margin = new Padding(2, 2, 2, 2);
            txtAnioPublicacion.MaxLength = 4;
            txtAnioPublicacion.Name = "txtAnioPublicacion";
            txtAnioPublicacion.Size = new Size(81, 27);
            txtAnioPublicacion.TabIndex = 13;
            // 
            // chkEstadoLibro
            // 
            chkEstadoLibro.AutoSize = true;
            chkEstadoLibro.Location = new Point(184, 254);
            chkEstadoLibro.Margin = new Padding(2, 2, 2, 2);
            chkEstadoLibro.Name = "chkEstadoLibro";
            chkEstadoLibro.Size = new Size(103, 24);
            chkEstadoLibro.TabIndex = 14;
            chkEstadoLibro.Text = "Disponible";
            chkEstadoLibro.UseVisualStyleBackColor = true;
            // 
            // FrmLibro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Name = "FrmLibro";
            Text = "FrmLibro";
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
        }


        private Label lblTituloLibro;
        private TextBox txtTituloLibro;
        private Label lblIsbn;
        private TextBox txtIsbn;
        private Label lblIdAutorLibro;
        private TextBox txtIdAutorLibro;
        private Label lblIdCategoriaLibro;
        private TextBox txtIdCategoriaLibro;
        private Label lblIdEditorialLibro;
        private TextBox txtIdEditorialLibro;
        private Label lblAnioPublicacion;
        private TextBox txtAnioPublicacion;
        private CheckBox chkEstadoLibro;
    }
}