namespace Formularios
{
    partial class FormCantidadPrecio
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
            this.lbl_cantidadPrecio = new System.Windows.Forms.Label();
            this.txt_cantidadPrecio = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_cantidadPrecio
            // 
            this.lbl_cantidadPrecio.AutoSize = true;
            this.lbl_cantidadPrecio.Location = new System.Drawing.Point(12, 19);
            this.lbl_cantidadPrecio.Name = "lbl_cantidadPrecio";
            this.lbl_cantidadPrecio.Size = new System.Drawing.Size(58, 15);
            this.lbl_cantidadPrecio.TabIndex = 0;
            this.lbl_cantidadPrecio.Text = "Cantidad:";
            // 
            // txt_cantidadPrecio
            // 
            this.txt_cantidadPrecio.Location = new System.Drawing.Point(12, 42);
            this.txt_cantidadPrecio.Name = "txt_cantidadPrecio";
            this.txt_cantidadPrecio.Size = new System.Drawing.Size(170, 23);
            this.txt_cantidadPrecio.TabIndex = 1;
            this.txt_cantidadPrecio.Text = "0";
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(12, 88);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(77, 26);
            this.btn_aceptar.TabIndex = 4;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(105, 88);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 26);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(12, 68);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(0, 15);
            this.lbl_error.TabIndex = 6;
            // 
            // FormCantidadPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 129);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.txt_cantidadPrecio);
            this.Controls.Add(this.lbl_cantidadPrecio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCantidadPrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCantidadPrecio";
            this.Load += new System.EventHandler(this.FormCantidadPrecio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_cantidadPrecio;
        private System.Windows.Forms.TextBox txt_cantidadPrecio;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label lbl_error;
    }
}