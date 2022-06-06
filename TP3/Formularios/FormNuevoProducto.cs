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
    public partial class FormNuevoProducto : Form
    {
        public FormNuevoProducto()
        {
            InitializeComponent();
        }

        private void FormNuevoProducto_Load(object sender, EventArgs e)
        {
            cmb_tipo.DataSource = Enum.GetValues(typeof(Producto.TipoProducto));
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            float precioNuevoProducto;
            int cantidad;
            try
            {
                ValidarTextosNoVacios(this);

                Validacion.ValidarDescripcionUnica(this.txt_descripcion.Text);
                precioNuevoProducto = Validacion.ValidarPrecio(this.txt_precio.Text);
                cantidad = Validacion.ValidarCantidad(this.txt_cantidad.Text);

                Producto nuevoProducto = new Producto((Producto.TipoProducto)this.cmb_tipo.SelectedItem,
                this.txt_descripcion.Text, precioNuevoProducto, cantidad);

                Kiosko.listaProductos.Add(nuevoProducto);

                MessageBox.Show($"Producto agregado\n{nuevoProducto.DarInfo()}");

                this.DialogResult = DialogResult.OK;
                
            }catch(CamposVaciosException ex)
            {
                this.lbl_error.Text = ex.Message;   
            }
            catch(DescripcionRepetidaException ex)
            {
                this.lbl_error.Text = ex.Message;
            }
            catch(DatosInvalidosException ex)
            {
                this.lbl_error.Text = ex.Message;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Valida que los campos de texto de este formulario no se encuentren vacios
        /// </summary>
        /// <param name="formAVerificar"></param>
        /// <exception cref="CamposVaciosException"></exception>
        private static void ValidarTextosNoVacios(Form formAVerificar)
        {
            foreach (Control item in formAVerificar.Controls)
            {
                if (item is TextBox && string.IsNullOrEmpty(item.Text))
                {
                    throw new CamposVaciosException("Complete todos los campos por favor");
                }
            }
        }

        
    }
}
