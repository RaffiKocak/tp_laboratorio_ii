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

namespace Formularios
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            Logica.ActualizarDGV(dgv_ventas, BaseDatos.TraerVentas());
            this.lbl_cantidad.Text = Venta.ContarCantidadVentas().ToString();
            this.lbl_recaudacion.Text = "$" + Venta.ContarTotalRecaudado().ToString();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgv_productos_DoubleClick(object sender, EventArgs e)
        {
            Venta ventaAMostrar = dgv_ventas.CurrentRow.DataBoundItem as Venta;
            MessageBox.Show(ventaAMostrar.DarInfo());
        }
    }
}
