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
using Excepciones;

namespace Formularios
{
    public partial class FormCantidadPrecio : Form
    {
        bool afectaCantidad;
        float precioADevolver;
        int cantidadADevolver;

        public FormCantidadPrecio()
        {
            InitializeComponent();
        }

        public FormCantidadPrecio(bool afectaCantidad) : this()
        {
            this.afectaCantidad = afectaCantidad;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormCantidadPrecio_Load(object sender, EventArgs e)
        {
            if (!afectaCantidad)
            {
                this.lbl_cantidadPrecio.Text = "Precio:";
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!afectaCantidad)
                {
                    precioADevolver = Validacion.ValidarPrecio(this.txt_cantidadPrecio.Text);
                    this.DialogResult = DialogResult.OK;
                } else
                {
                    cantidadADevolver = Validacion.ValidarCantidad(this.txt_cantidadPrecio.Text);
                    this.DialogResult = DialogResult.OK;
                }
            } catch(DatosInvalidosException ex)
            {
                this.lbl_error.Text = ex.Message;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Devuelve la cantidad ingresada en el TextBox
        /// </summary>
        /// <returns></returns>
        public int DevolverCantidad()
        {
            return cantidadADevolver;
        }

        /// <summary>
        /// Devuelve el precio ingresado en el TextBox
        /// </summary>
        /// <returns></returns>
        public float DevolverPrecio()
        {
            return precioADevolver;
        }
    }
}
