using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class FormPrincipal : Form
    {
        List<Producto> carritoProductos;
        float precioParcial;

        public FormPrincipal()
        {
            InitializeComponent();
            carritoProductos = new List<Producto>();
            precioParcial = 0;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Kiosko.CargarProductos();
                Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                Kiosko.CargarVentas();
            } catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                while (ex.InnerException != null)
                {
                    sb.AppendLine(ex.Message);
                    ex = ex.InnerException;
                }

                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dgv_productos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Producto productoAAgregar = TraerProductoDesdeDGV();

                if (productoAAgregar.AgregarProductoACarrito(carritoProductos))
                {
                    productoAAgregar.Cantidad--;
                    this.precioParcial += productoAAgregar.Precio;
                    Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                    ActualizarListBox();
                    this.lbl_precioParcial.Text = "$" + this.precioParcial.ToString();
                }
            } catch (NoHayProductosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_registrarVenta_Click(object sender, EventArgs e)
        {
            if (carritoProductos.Count > 0)
            {
                Venta nuevaVenta = new Venta(this.precioParcial, Venta.RegistrarProductosVendidos(carritoProductos));
                Kiosko.registroVentas.Add(nuevaVenta);
                MessageBox.Show($"Venta registrada!\n{nuevaVenta.DarInfo()}", "", MessageBoxButtons.OK);
                FinalizarVenta();
            }
        }

        private void btn_cancelarVenta_Click(object sender, EventArgs e)
        {
            if (carritoProductos.Count > 0 && 
                MessageBox.Show("¿Cancelar Venta?", "", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CancelarVenta();
                Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
            }
        }
       

        /// <summary>
        /// Actualiza la listbox que corresponde al carrito de la compra
        /// </summary>
        private void ActualizarListBox()
        {
            lst_venta.DataSource = null;
            lst_venta.DataSource = carritoProductos;
        }

        /// <summary>
        /// Quita todos los productos del carrito, reinicia el precio parcial y actualiza la vista de la listbox
        /// </summary>
        private void FinalizarVenta()
        {
            carritoProductos.Clear();
            this.precioParcial = 0;
            this.lbl_precioParcial.Text = "$" + this.precioParcial.ToString();
            ActualizarListBox();
        }

        /// <summary>
        /// Devuelve toda la cantidad de los productos del carrito al stock y llama al metodo FinalizarVenta
        /// </summary>
        private void CancelarVenta()
        {
            Producto.DevolverProductosAStock(carritoProductos);
            FinalizarVenta();
        }

        private void btn_ventas_Click(object sender, EventArgs e)
        {
            FormVentas frmVentas = new FormVentas();

            if (frmVentas.ShowDialog() == DialogResult.OK)
            {
                frmVentas.Dispose();
            }
        }

        private void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            FormNuevoProducto frmNuevo = new FormNuevoProducto();

            if (frmNuevo.ShowDialog() == DialogResult.OK)
            {
                Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                frmNuevo.Dispose();
            }
        }

        private void btn_bajaProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.carritoProductos.Count == 0)
                {
                    Producto productoABorrar = TraerProductoDesdeDGV();

                    if (MessageBox.Show($"¿Está seguro que desea borrar este producto?\n{productoABorrar.DarInfo()}",
                        "Borrar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Kiosko.listaProductos.Remove(productoABorrar);
                        Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                    }
                } else
                {
                    MessageBox.Show("Por favor finalice la venta antes de eliminar elementos.", 
                        "Borrar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NoHayProductosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cambiarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = TraerProductoDesdeDGV();

                FormCantidadPrecio frmCantPrecio = new FormCantidadPrecio(false);
                if (frmCantPrecio.ShowDialog() == DialogResult.OK)
                {
                    producto.Precio = frmCantPrecio.DevolverPrecio();
                    frmCantPrecio.Dispose();
                    Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                }
            } catch(NoHayProductosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Rescata el dato obtenido a través del DataGridView, si es que existe.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoHayProductosException"></exception>
        private Producto TraerProductoDesdeDGV()
        {
            if (dgv_productos.CurrentRow != null)
            {
                return (Producto)dgv_productos.CurrentRow.DataBoundItem;
            }

            throw new NoHayProductosException("No hay ningún producto seleccionado");
        }

        private void btn_agregarStock_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = TraerProductoDesdeDGV();

                FormCantidadPrecio frmCantPrecio = new FormCantidadPrecio(true);
                if (frmCantPrecio.ShowDialog() == DialogResult.OK)
                {
                    producto.Cantidad += frmCantPrecio.DevolverCantidad();
                    frmCantPrecio.Dispose();
                    Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                }
            }
            catch (NoHayProductosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_restarStock_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = TraerProductoDesdeDGV();

                FormCantidadPrecio frmCantPrecio = new FormCantidadPrecio(true);
                if (frmCantPrecio.ShowDialog() == DialogResult.OK)
                {
                    producto.Cantidad -= frmCantPrecio.DevolverCantidad();
                    if (producto.Cantidad < 0)
                    {
                        producto.Cantidad = 0;
                    }
                    frmCantPrecio.Dispose();
                    Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);
                }
            }
            catch (NoHayProductosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lst_venta_DoubleClick(object sender, EventArgs e)
        {
            Producto productoABorrar = (Producto)lst_venta.SelectedItem;

            if (productoABorrar != null)
            {
                Producto.RestarUnProductoDeCarrito(productoABorrar, carritoProductos);
                precioParcial -= productoABorrar.Precio;

                this.lbl_precioParcial.Text = "$" + this.precioParcial.ToString();
                ActualizarListBox();
                Logica.ActualizarDGV(dgv_productos, Kiosko.listaProductos);

            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (carritoProductos.Count == 0)
            {
                Archivo<List<Producto>>.EscribirJson("ListaProductos", Kiosko.listaProductos);
                Archivo<List<Venta>>.EscribirXml("ListaVentas", Kiosko.registroVentas);
            } else
            {
                MessageBox.Show("Guarde antes o después de finalizar una venta por favor.",
                    "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"¿Está seguro que desea salir?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
