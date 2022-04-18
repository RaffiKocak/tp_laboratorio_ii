using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP_01
{
    public partial class FormCalculadora : Form
    {
        
        /// <summary>
        /// Constructor del formulario. Inicializa sus componentes.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los componentes del formulario con los valores dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmb_operador.Items.Add(" ");
            this.cmb_operador.Items.Add("+");
            this.cmb_operador.Items.Add("-");
            this.cmb_operador.Items.Add("*");
            this.cmb_operador.Items.Add("/");
            this.Limpiar();
        }

        /// <summary>
        /// Llama al método Limpiar al realizar el evento click sobre el btn_limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Establece los TextBox, ComboBox, Botones y Label del formulario en su estado inicial.
        /// </summary>
        private void Limpiar()
        {
            this.cmb_operador.SelectedIndex = 0;
            this.lbl_resultado.Text = "0";
            this.txt_numeroUno.Clear();
            this.txt_numeroDos.Clear();
            this.btn_convertirABinario.Enabled = false;
            this.btn_convertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Realiza una operación matemática entre 2 números.
        /// </summary>
        /// <param name="numeroUno">Primer número a operar.</param>
        /// <param name="numeroDos">Segundo número a operar.</param>
        /// <param name="operador">Operación a realizar</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        private static double Operar (string numeroUno, string numeroDos, string operador)
        {
            Operando operandoUno = new Operando(numeroUno);
            Operando operandoDos = new Operando(numeroDos);
            char operadorCaracter;
            double resultado;

            char.TryParse(operador, out operadorCaracter);

            resultado = Calculadora.Operar(operandoUno, operandoDos, operadorCaracter);

            return resultado;
        }

        /// <summary>
        /// Llama al método Operar al realizar el evento click sobre el btn_operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_operar_Click(object sender, EventArgs e)
        {
            double resultado;
            StringBuilder sb = new StringBuilder();

            this.txt_numeroUno.Text = this.txt_numeroUno.Text.Replace('.', ',');
            this.txt_numeroDos.Text = this.txt_numeroDos.Text.Replace('.', ',');

            if (double.TryParse(this.txt_numeroUno.Text, out double numeroUno) && 
                double.TryParse(this.txt_numeroDos.Text, out double numeroDos))
            {
                if (this.cmb_operador.Text == " ")
                {
                    this.cmb_operador.SelectedIndex = 1;
                }
                resultado = Operar(this.txt_numeroUno.Text, this.txt_numeroDos.Text, cmb_operador.Text);

                if (resultado != double.MinValue)
                {
                    
                    this.btn_convertirADecimal.Enabled = false;
                    this.btn_convertirABinario.Enabled = true;
                    sb.Append($"{this.txt_numeroUno.Text} ");
                    sb.Append($"{this.cmb_operador.Text} ");
                    sb.Append($"{this.txt_numeroDos.Text} = ");
                    sb.Append($"{resultado}");
                    lst_operaciones.Items.Add(sb.ToString());
                    this.lbl_resultado.Text = resultado.ToString(); 
                } else
                {
                    MessageBox.Show("No es posible dividir por 0.",
                        "Operación inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            } else
            {
                MessageBox.Show("Los operandos no son válidos.",
                        "Operandos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
           
        }

        /// <summary>
        /// Convierte el número almacenado en lbl_resultado de decimal a binario, al realizar el evento
        /// click en btn_convertirABinario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_convertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            resultado = this.lbl_resultado.Text;
            this.lbl_resultado.Text = Operando.DecimalBinario(resultado);
            this.lst_operaciones.Items.Add($"{resultado} = {this.lbl_resultado.Text}");
            this.btn_convertirABinario.Enabled = false;
            this.btn_convertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Convierte el número almacenado en lbl_resultado de binario a decimal, al realizar el evento
        /// click en btn_convertirADecimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_convertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado;
            resultado = this.lbl_resultado.Text;
            this.lbl_resultado.Text = Operando.BinarioDecimal(resultado);
            this.lst_operaciones.Items.Add($"{resultado} = {this.lbl_resultado.Text}");
            this.btn_convertirABinario.Enabled = true;
            this.btn_convertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Pregunta al usuario si está seguro de cerrar el formulario al detectar que se está cerrando.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar el programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Dispose();
            }
        }

        /// <summary>
        /// Cierra el formulario al realizar el evento click en btn_cerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
