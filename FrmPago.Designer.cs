namespace SistemaBiblioteca1
{
    partial class FrmPago
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
            lblIdSancion = new Label();
            lblMontoPago = new Label();
            lblFechaPago = new Label();
            lblMetodoPago = new Label();
            chkEstadoPago = new CheckBox();
            txtSancionPago = new TextBox();
            txtMontoPago = new TextBox();
            dtpFechaPago = new DateTimePicker();
            cmbMetodoPago = new ComboBox();
            pnlFormularioBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormularioBase
            // 
            pnlFormularioBase.Controls.Add(dtpFechaPago);
            pnlFormularioBase.Controls.Add(cmbMetodoPago);
            pnlFormularioBase.Controls.Add(chkEstadoPago);
            pnlFormularioBase.Controls.Add(lblFechaPago);
            pnlFormularioBase.Controls.Add(lblMetodoPago);
            pnlFormularioBase.Controls.Add(txtMontoPago);
            pnlFormularioBase.Controls.Add(txtSancionPago);
            pnlFormularioBase.Controls.Add(lblIdSancion);
            pnlFormularioBase.Controls.Add(lblMontoPago);
            pnlFormularioBase.Size = new Size(662, 313);
            pnlFormularioBase.Controls.SetChildIndex(txtId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblId, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblMontoPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblIdSancion, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtSancionPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(txtMontoPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblMetodoPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(lblFechaPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(chkEstadoPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(cmbMetodoPago, 0);
            pnlFormularioBase.Controls.SetChildIndex(dtpFechaPago, 0);
            // 
            // lblIdSancion
            // 
            lblIdSancion.AutoSize = true;
            lblIdSancion.Location = new Point(16, 67);
            lblIdSancion.Name = "lblIdSancion";
            lblIdSancion.Size = new Size(83, 20);
            lblIdSancion.TabIndex = 0;
            lblIdSancion.Text = "ID Sanción:";
            // 
            // lblMontoPago
            // 
            lblMontoPago.AutoSize = true;
            lblMontoPago.Location = new Point(16, 106);
            lblMontoPago.Name = "lblMontoPago";
            lblMontoPago.Size = new Size(78, 20);
            lblMontoPago.TabIndex = 1;
            lblMontoPago.Text = "Monto ($):";
            // 
            // lblFechaPago
            // 
            lblFechaPago.AutoSize = true;
            lblFechaPago.Location = new Point(16, 144);
            lblFechaPago.Name = "lblFechaPago";
            lblFechaPago.Size = new Size(110, 20);
            lblFechaPago.TabIndex = 2;
            lblFechaPago.Text = "Fecha de pago:";
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(16, 185);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(125, 20);
            lblMetodoPago.TabIndex = 3;
            lblMetodoPago.Text = "Método de pago:";
            // 
            // chkEstadoPago
            // 
            chkEstadoPago.AutoSize = true;
            chkEstadoPago.Location = new Point(184, 223);
            chkEstadoPago.Name = "chkEstadoPago";
            chkEstadoPago.Size = new Size(73, 24);
            chkEstadoPago.TabIndex = 4;
            chkEstadoPago.Text = "Activo";
            chkEstadoPago.UseVisualStyleBackColor = true;
            // 
            // txtSancionPago
            // 
            txtSancionPago.Location = new Point(184, 60);
            txtSancionPago.Name = "txtSancionPago";
            txtSancionPago.Size = new Size(185, 27);
            txtSancionPago.TabIndex = 5;
            // 
            // txtMontoPago
            // 
            txtMontoPago.Location = new Point(184, 103);
            txtMontoPago.Name = "txtMontoPago";
            txtMontoPago.Size = new Size(185, 27);
            txtMontoPago.TabIndex = 6;
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Format = DateTimePickerFormat.Short;
            dtpFechaPago.Location = new Point(184, 139);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(185, 27);
            dtpFechaPago.TabIndex = 7;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.Location = new Point(184, 177);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(185, 28);
            cmbMetodoPago.TabIndex = 8;
            // 
            // FrmPago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 313);
            Name = "FrmPago";
            Text = "FrmPago";
            pnlFormularioBase.ResumeLayout(false);
            pnlFormularioBase.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblIdSancion;
        private Label lblMontoPago;
        private Label lblFechaPago;
        private Label lblMetodoPago;
        private CheckBox chkEstadoPago;
        private TextBox txtSancionPago;
        private TextBox txtMontoPago;
        private DateTimePicker dtpFechaPago;
        private ComboBox cmbMetodoPago;
    }
}