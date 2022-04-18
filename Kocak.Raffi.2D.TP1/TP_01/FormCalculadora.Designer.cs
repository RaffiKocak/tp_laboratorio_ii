namespace TP_01
{
    partial class FormCalculadora
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_numeroUno = new System.Windows.Forms.TextBox();
            this.cmb_operador = new System.Windows.Forms.ComboBox();
            this.txt_numeroDos = new System.Windows.Forms.TextBox();
            this.btn_operar = new System.Windows.Forms.Button();
            this.btn_convertirABinario = new System.Windows.Forms.Button();
            this.btn_convertirADecimal = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.lst_operaciones = new System.Windows.Forms.ListBox();
            this.lbl_resultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_numeroUno
            // 
            this.txt_numeroUno.Location = new System.Drawing.Point(21, 43);
            this.txt_numeroUno.Name = "txt_numeroUno";
            this.txt_numeroUno.Size = new System.Drawing.Size(96, 23);
            this.txt_numeroUno.TabIndex = 0;
            // 
            // cmb_operador
            // 
            this.cmb_operador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_operador.FormattingEnabled = true;
            this.cmb_operador.Location = new System.Drawing.Point(144, 43);
            this.cmb_operador.Name = "cmb_operador";
            this.cmb_operador.Size = new System.Drawing.Size(76, 23);
            this.cmb_operador.TabIndex = 1;
            // 
            // txt_numeroDos
            // 
            this.txt_numeroDos.Location = new System.Drawing.Point(251, 43);
            this.txt_numeroDos.Name = "txt_numeroDos";
            this.txt_numeroDos.Size = new System.Drawing.Size(96, 23);
            this.txt_numeroDos.TabIndex = 2;
            // 
            // btn_operar
            // 
            this.btn_operar.Location = new System.Drawing.Point(21, 101);
            this.btn_operar.Name = "btn_operar";
            this.btn_operar.Size = new System.Drawing.Size(96, 37);
            this.btn_operar.TabIndex = 3;
            this.btn_operar.Text = "Operar";
            this.btn_operar.UseVisualStyleBackColor = true;
            this.btn_operar.Click += new System.EventHandler(this.btn_operar_Click);
            // 
            // btn_convertirABinario
            // 
            this.btn_convertirABinario.Location = new System.Drawing.Point(21, 158);
            this.btn_convertirABinario.Name = "btn_convertirABinario";
            this.btn_convertirABinario.Size = new System.Drawing.Size(156, 37);
            this.btn_convertirABinario.TabIndex = 6;
            this.btn_convertirABinario.Text = "Convertir a Binario";
            this.btn_convertirABinario.UseVisualStyleBackColor = true;
            this.btn_convertirABinario.Click += new System.EventHandler(this.btn_convertirABinario_Click);
            // 
            // btn_convertirADecimal
            // 
            this.btn_convertirADecimal.Location = new System.Drawing.Point(191, 158);
            this.btn_convertirADecimal.Name = "btn_convertirADecimal";
            this.btn_convertirADecimal.Size = new System.Drawing.Size(156, 37);
            this.btn_convertirADecimal.TabIndex = 7;
            this.btn_convertirADecimal.Text = "Convertir a Decimal";
            this.btn_convertirADecimal.UseVisualStyleBackColor = true;
            this.btn_convertirADecimal.Click += new System.EventHandler(this.btn_convertirADecimal_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(134, 101);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(96, 37);
            this.btn_limpiar.TabIndex = 4;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(251, 101);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(96, 37);
            this.btn_cerrar.TabIndex = 5;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // lst_operaciones
            // 
            this.lst_operaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lst_operaciones.FormattingEnabled = true;
            this.lst_operaciones.ItemHeight = 25;
            this.lst_operaciones.Location = new System.Drawing.Point(359, 12);
            this.lst_operaciones.Name = "lst_operaciones";
            this.lst_operaciones.Size = new System.Drawing.Size(232, 204);
            this.lst_operaciones.TabIndex = 9;
            this.lst_operaciones.TabStop = false;
            // 
            // lbl_resultado
            // 
            this.lbl_resultado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_resultado.Location = new System.Drawing.Point(21, 12);
            this.lbl_resultado.Name = "lbl_resultado";
            this.lbl_resultado.Size = new System.Drawing.Size(326, 25);
            this.lbl_resultado.TabIndex = 9;
            this.lbl_resultado.Text = "0";
            this.lbl_resultado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 242);
            this.Controls.Add(this.lbl_resultado);
            this.Controls.Add(this.lst_operaciones);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_convertirADecimal);
            this.Controls.Add(this.btn_convertirABinario);
            this.Controls.Add(this.btn_operar);
            this.Controls.Add(this.txt_numeroDos);
            this.Controls.Add(this.cmb_operador);
            this.Controls.Add(this.txt_numeroUno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Raffi Kocak del curso 2D";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalculadora_FormClosing);
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_numeroUno;
        private System.Windows.Forms.ComboBox cmb_operador;
        private System.Windows.Forms.TextBox txt_numeroDos;
        private System.Windows.Forms.Button btn_operar;
        private System.Windows.Forms.Button btn_convertirABinario;
        private System.Windows.Forms.Button btn_convertirADecimal;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.ListBox lst_operaciones;
        private System.Windows.Forms.Label lbl_resultado;
    }
}
