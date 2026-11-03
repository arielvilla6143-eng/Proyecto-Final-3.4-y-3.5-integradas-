namespace SistemaBiblioteca1
{
    partial class FrmCategoria
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
            lblNombreCategoria = new Label();
            lblDescripcionCategoria = new Label();
            txtNombreCategoria = new TextBox();
            txtDescripcionCategoria = new TextBox();
            chkRestringidaMenores = new CheckBox();
            chkEstadoCategoria = new CheckBox();
            pnlFormularioBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epValidaciones).BeginInit();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(lblDescripcionCategoria);
            pnlFormularioBase.Controls.Add(lblNombreCategoria);
            pnlFormularioBase.Controls.Add(chkRestringidaMenores);
            pnlFormularioBase.Controls.Add(txtNombreCategoria);
            pnlFormularioBase.Controls.Add(txtDescripcionCategoria);
            pnlFormularioBase.Controls.Add(chkEstadoCategoria);
            pnlFormularioBase.Size = new Size(778, 391);
            pnlFormularioBase.Paint += pnlFormularioBase_Paint;
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoCategoria, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtDescripcionCategoria, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtNombreCategoria, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkRestringidaMenores, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblNombreCategoria, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblDescripcionCategoria, 0);
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.Location = new Point(20, 72);
            lblNombreCategoria.Margin = new Padding(4, 0, 4, 0);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(82, 25);
            lblNombreCategoria.TabIndex = 0;
            lblNombreCategoria.Text = "Nombre:";
            // 
            // lblDescripcionCategoria
            // 
            lblDescripcionCategoria.AutoSize = true;
            lblDescripcionCategoria.Location = new Point(20, 114);
            lblDescripcionCategoria.Margin = new Padding(4, 0, 4, 0);
            lblDescripcionCategoria.Name = "lblDescripcionCategoria";
            lblDescripcionCategoria.Size = new Size(108, 25);
            lblDescripcionCategoria.TabIndex = 1;
            lblDescripcionCategoria.Text = "Descripcion:";
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(230, 72);
            txtNombreCategoria.Margin = new Padding(4, 4, 4, 4);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(230, 31);
            txtNombreCategoria.TabIndex = 2;
            // 
            // txtDescripcionCategoria
            // 
            txtDescripcionCategoria.Location = new Point(230, 114);
            txtDescripcionCategoria.Margin = new Padding(4, 4, 4, 4);
            txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            txtDescripcionCategoria.Size = new Size(230, 31);
            txtDescripcionCategoria.TabIndex = 3;
            // 
            // chkRestringidaMenores
            // 
            chkRestringidaMenores.AutoSize = true;
            chkRestringidaMenores.Location = new Point(230, 168);
            chkRestringidaMenores.Margin = new Padding(4, 4, 4, 4);
            chkRestringidaMenores.Name = "chkRestringidaMenores";
            chkRestringidaMenores.Size = new Size(192, 29);
            chkRestringidaMenores.TabIndex = 4;
            chkRestringidaMenores.Text = "Apto para menores";
            chkRestringidaMenores.UseVisualStyleBackColor = true;
            // 
            // chkEstadoCategoria
            // 
            chkEstadoCategoria.AutoSize = true;
            chkEstadoCategoria.Location = new Point(230, 205);
            chkEstadoCategoria.Margin = new Padding(4, 4, 4, 4);
            chkEstadoCategoria.Name = "chkEstadoCategoria";
            chkEstadoCategoria.Size = new Size(88, 29);
            chkEstadoCategoria.TabIndex = 5;
            chkEstadoCategoria.Text = "Activo";
            chkEstadoCategoria.UseVisualStyleBackColor = true;
            // 
            // FrmCategoria
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 391);
            Name = "FrmCategoria";
            Text = "FrmCategoria";
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)epValidaciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNombreCategoria;
        private Label lblDescripcionCategoria;
        private TextBox txtNombreCategoria;
        private TextBox txtDescripcionCategoria;
        private CheckBox chkRestringidaMenores;
        private CheckBox chkEstadoCategoria;
    }
}