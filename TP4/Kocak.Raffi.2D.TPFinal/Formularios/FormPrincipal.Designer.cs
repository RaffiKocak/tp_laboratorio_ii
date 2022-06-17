namespace Formularios
{
    partial class FormPrincipal
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
            this.dgv_productos = new System.Windows.Forms.DataGridView();
            this.btn_ventas = new System.Windows.Forms.Button();
            this.btn_cambiarPrecio = new System.Windows.Forms.Button();
            this.btn_agregarProducto = new System.Windows.Forms.Button();
            this.btn_bajaProducto = new System.Windows.Forms.Button();
            this.btn_agregarStock = new System.Windows.Forms.Button();
            this.btn_restarStock = new System.Windows.Forms.Button();
            this.lst_venta = new System.Windows.Forms.ListBox();
            this.btn_registrarVenta = new System.Windows.Forms.Button();
            this.btn_cancelarVenta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_totalParcial = new System.Windows.Forms.Label();
            this.lbl_precioParcial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_kiosko = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lbl_cargando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_productos
            // 
            this.dgv_productos.AllowUserToAddRows = false;
            this.dgv_productos.AllowUserToDeleteRows = false;
            this.dgv_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productos.Location = new System.Drawing.Point(15, 40);
            this.dgv_productos.MultiSelect = false;
            this.dgv_productos.Name = "dgv_productos";
            this.dgv_productos.ReadOnly = true;
            this.dgv_productos.RowHeadersVisible = false;
            this.dgv_productos.RowTemplate.Height = 25;
            this.dgv_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_productos.Size = new System.Drawing.Size(486, 233);
            this.dgv_productos.TabIndex = 0;
            this.dgv_productos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_productos_CellMouseDoubleClick);
            // 
            // btn_ventas
            // 
            this.btn_ventas.Location = new System.Drawing.Point(15, 289);
            this.btn_ventas.Name = "btn_ventas";
            this.btn_ventas.Size = new System.Drawing.Size(147, 40);
            this.btn_ventas.TabIndex = 1;
            this.btn_ventas.Text = "Ventas";
            this.btn_ventas.UseVisualStyleBackColor = true;
            this.btn_ventas.Click += new System.EventHandler(this.btn_ventas_Click);
            // 
            // btn_cambiarPrecio
            // 
            this.btn_cambiarPrecio.Location = new System.Drawing.Point(15, 348);
            this.btn_cambiarPrecio.Name = "btn_cambiarPrecio";
            this.btn_cambiarPrecio.Size = new System.Drawing.Size(147, 40);
            this.btn_cambiarPrecio.TabIndex = 2;
            this.btn_cambiarPrecio.Text = "Cambiar precio unitario";
            this.btn_cambiarPrecio.UseVisualStyleBackColor = true;
            this.btn_cambiarPrecio.Click += new System.EventHandler(this.btn_cambiarPrecio_Click);
            // 
            // btn_agregarProducto
            // 
            this.btn_agregarProducto.Location = new System.Drawing.Point(186, 289);
            this.btn_agregarProducto.Name = "btn_agregarProducto";
            this.btn_agregarProducto.Size = new System.Drawing.Size(147, 40);
            this.btn_agregarProducto.TabIndex = 3;
            this.btn_agregarProducto.Text = "Agregar producto";
            this.btn_agregarProducto.UseVisualStyleBackColor = true;
            this.btn_agregarProducto.Click += new System.EventHandler(this.btn_agregarProducto_Click);
            // 
            // btn_bajaProducto
            // 
            this.btn_bajaProducto.Location = new System.Drawing.Point(186, 348);
            this.btn_bajaProducto.Name = "btn_bajaProducto";
            this.btn_bajaProducto.Size = new System.Drawing.Size(147, 40);
            this.btn_bajaProducto.TabIndex = 4;
            this.btn_bajaProducto.Text = "Dar de baja producto";
            this.btn_bajaProducto.UseVisualStyleBackColor = true;
            this.btn_bajaProducto.Click += new System.EventHandler(this.btn_bajaProducto_Click);
            // 
            // btn_agregarStock
            // 
            this.btn_agregarStock.Location = new System.Drawing.Point(354, 289);
            this.btn_agregarStock.Name = "btn_agregarStock";
            this.btn_agregarStock.Size = new System.Drawing.Size(147, 40);
            this.btn_agregarStock.TabIndex = 5;
            this.btn_agregarStock.Text = "Agregar stock";
            this.btn_agregarStock.UseVisualStyleBackColor = true;
            this.btn_agregarStock.Click += new System.EventHandler(this.btn_agregarStock_Click);
            // 
            // btn_restarStock
            // 
            this.btn_restarStock.Location = new System.Drawing.Point(354, 348);
            this.btn_restarStock.Name = "btn_restarStock";
            this.btn_restarStock.Size = new System.Drawing.Size(147, 40);
            this.btn_restarStock.TabIndex = 6;
            this.btn_restarStock.Text = "Restar stock";
            this.btn_restarStock.UseVisualStyleBackColor = true;
            this.btn_restarStock.Click += new System.EventHandler(this.btn_restarStock_Click);
            // 
            // lst_venta
            // 
            this.lst_venta.FormattingEnabled = true;
            this.lst_venta.HorizontalScrollbar = true;
            this.lst_venta.ItemHeight = 15;
            this.lst_venta.Location = new System.Drawing.Point(528, 56);
            this.lst_venta.Name = "lst_venta";
            this.lst_venta.Size = new System.Drawing.Size(289, 199);
            this.lst_venta.TabIndex = 10;
            this.lst_venta.DoubleClick += new System.EventHandler(this.lst_venta_DoubleClick);
            // 
            // btn_registrarVenta
            // 
            this.btn_registrarVenta.Location = new System.Drawing.Point(528, 289);
            this.btn_registrarVenta.Name = "btn_registrarVenta";
            this.btn_registrarVenta.Size = new System.Drawing.Size(134, 40);
            this.btn_registrarVenta.TabIndex = 11;
            this.btn_registrarVenta.Text = "Registrar Venta";
            this.btn_registrarVenta.UseVisualStyleBackColor = true;
            this.btn_registrarVenta.Click += new System.EventHandler(this.btn_registrarVenta_Click);
            // 
            // btn_cancelarVenta
            // 
            this.btn_cancelarVenta.Location = new System.Drawing.Point(683, 289);
            this.btn_cancelarVenta.Name = "btn_cancelarVenta";
            this.btn_cancelarVenta.Size = new System.Drawing.Size(134, 40);
            this.btn_cancelarVenta.TabIndex = 13;
            this.btn_cancelarVenta.Text = "Cancelar Venta";
            this.btn_cancelarVenta.UseVisualStyleBackColor = true;
            this.btn_cancelarVenta.Click += new System.EventHandler(this.btn_cancelarVenta_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(507, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 398);
            this.panel1.TabIndex = 14;
            // 
            // lbl_totalParcial
            // 
            this.lbl_totalParcial.AutoSize = true;
            this.lbl_totalParcial.Location = new System.Drawing.Point(528, 258);
            this.lbl_totalParcial.Name = "lbl_totalParcial";
            this.lbl_totalParcial.Size = new System.Drawing.Size(73, 15);
            this.lbl_totalParcial.TabIndex = 15;
            this.lbl_totalParcial.Text = "Total parcial:";
            // 
            // lbl_precioParcial
            // 
            this.lbl_precioParcial.AutoSize = true;
            this.lbl_precioParcial.Location = new System.Drawing.Point(607, 258);
            this.lbl_precioParcial.Name = "lbl_precioParcial";
            this.lbl_precioParcial.Size = new System.Drawing.Size(19, 15);
            this.lbl_precioParcial.TabIndex = 16;
            this.lbl_precioParcial.Text = "$0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Carrito de venta:";
            // 
            // lbl_kiosko
            // 
            this.lbl_kiosko.AutoSize = true;
            this.lbl_kiosko.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_kiosko.Location = new System.Drawing.Point(12, 9);
            this.lbl_kiosko.Name = "lbl_kiosko";
            this.lbl_kiosko.Size = new System.Drawing.Size(69, 25);
            this.lbl_kiosko.TabIndex = 19;
            this.lbl_kiosko.Text = "Kiosko";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(808, 0);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(21, 23);
            this.btn_cerrar.TabIndex = 20;
            this.btn_cerrar.Text = "X";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lbl_cargando
            // 
            this.lbl_cargando.AutoSize = true;
            this.lbl_cargando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_cargando.Location = new System.Drawing.Point(587, 359);
            this.lbl_cargando.Name = "lbl_cargando";
            this.lbl_cargando.Size = new System.Drawing.Size(0, 17);
            this.lbl_cargando.TabIndex = 21;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 398);
            this.Controls.Add(this.lbl_cargando);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.lbl_kiosko);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_precioParcial);
            this.Controls.Add(this.lbl_totalParcial);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancelarVenta);
            this.Controls.Add(this.btn_registrarVenta);
            this.Controls.Add(this.lst_venta);
            this.Controls.Add(this.btn_restarStock);
            this.Controls.Add(this.btn_agregarStock);
            this.Controls.Add(this.btn_bajaProducto);
            this.Controls.Add(this.btn_agregarProducto);
            this.Controls.Add(this.btn_cambiarPrecio);
            this.Controls.Add(this.btn_ventas);
            this.Controls.Add(this.dgv_productos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_productos;
        private System.Windows.Forms.Button btn_ventas;
        private System.Windows.Forms.Button btn_cambiarPrecio;
        private System.Windows.Forms.Button btn_agregarProducto;
        private System.Windows.Forms.Button btn_bajaProducto;
        private System.Windows.Forms.Button btn_agregarStock;
        private System.Windows.Forms.Button btn_restarStock;
        private System.Windows.Forms.ListBox lst_venta;
        private System.Windows.Forms.Button btn_registrarVenta;
        private System.Windows.Forms.Button btn_cancelarVenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_totalParcial;
        private System.Windows.Forms.Label lbl_precioParcial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_kiosko;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label lbl_cargando;
    }
}