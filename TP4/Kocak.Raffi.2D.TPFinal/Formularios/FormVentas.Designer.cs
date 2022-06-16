namespace Formularios
{
    partial class FormVentas
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
            this.dgv_ventas = new System.Windows.Forms.DataGridView();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lbl_textoRecaudacion = new System.Windows.Forms.Label();
            this.lbl_recaudacion = new System.Windows.Forms.Label();
            this.lbl_textoCantidad = new System.Windows.Forms.Label();
            this.lbl_cantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ventas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ventas
            // 
            this.dgv_ventas.AllowUserToAddRows = false;
            this.dgv_ventas.AllowUserToDeleteRows = false;
            this.dgv_ventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ventas.Location = new System.Drawing.Point(12, 32);
            this.dgv_ventas.MultiSelect = false;
            this.dgv_ventas.Name = "dgv_ventas";
            this.dgv_ventas.ReadOnly = true;
            this.dgv_ventas.RowHeadersVisible = false;
            this.dgv_ventas.RowTemplate.Height = 25;
            this.dgv_ventas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ventas.Size = new System.Drawing.Size(588, 196);
            this.dgv_ventas.TabIndex = 1;
            this.dgv_ventas.DoubleClick += new System.EventHandler(this.dgv_productos_DoubleClick);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(591, 0);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(21, 23);
            this.btn_cerrar.TabIndex = 7;
            this.btn_cerrar.Text = "X";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lbl_textoRecaudacion
            // 
            this.lbl_textoRecaudacion.AutoSize = true;
            this.lbl_textoRecaudacion.Location = new System.Drawing.Point(12, 274);
            this.lbl_textoRecaudacion.Name = "lbl_textoRecaudacion";
            this.lbl_textoRecaudacion.Size = new System.Drawing.Size(131, 15);
            this.lbl_textoRecaudacion.TabIndex = 8;
            this.lbl_textoRecaudacion.Text = "Recaudación de ventas:";
            // 
            // lbl_recaudacion
            // 
            this.lbl_recaudacion.AutoSize = true;
            this.lbl_recaudacion.Location = new System.Drawing.Point(176, 274);
            this.lbl_recaudacion.Name = "lbl_recaudacion";
            this.lbl_recaudacion.Size = new System.Drawing.Size(19, 15);
            this.lbl_recaudacion.TabIndex = 9;
            this.lbl_recaudacion.Text = "$0";
            // 
            // lbl_textoCantidad
            // 
            this.lbl_textoCantidad.AutoSize = true;
            this.lbl_textoCantidad.Location = new System.Drawing.Point(61, 248);
            this.lbl_textoCantidad.Name = "lbl_textoCantidad";
            this.lbl_textoCantidad.Size = new System.Drawing.Size(82, 15);
            this.lbl_textoCantidad.TabIndex = 10;
            this.lbl_textoCantidad.Text = "Ventas totales:";
            // 
            // lbl_cantidad
            // 
            this.lbl_cantidad.AutoSize = true;
            this.lbl_cantidad.Location = new System.Drawing.Point(176, 248);
            this.lbl_cantidad.Name = "lbl_cantidad";
            this.lbl_cantidad.Size = new System.Drawing.Size(13, 15);
            this.lbl_cantidad.TabIndex = 11;
            this.lbl_cantidad.Text = "0";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 309);
            this.Controls.Add(this.lbl_cantidad);
            this.Controls.Add(this.lbl_textoCantidad);
            this.Controls.Add(this.lbl_recaudacion);
            this.Controls.Add(this.lbl_textoRecaudacion);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.dgv_ventas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ventas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ventas;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label lbl_textoRecaudacion;
        private System.Windows.Forms.Label lbl_recaudacion;
        private System.Windows.Forms.Label lbl_textoCantidad;
        private System.Windows.Forms.Label lbl_cantidad;
    }
}