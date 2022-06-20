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
using System.Threading;

namespace Formularios
{
    public partial class FormPrincipal : Form
    {
        List<Producto> carritoProductos;
        float precioParcial;
        CancellationTokenSource cts;

        public FormPrincipal()
        {
            InitializeComponent();
            carritoProductos = new List<Producto>();
            precioParcial = 0;
            
        }

        private async void FormPrincipal_Load(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            this.lbl_cargando.Text = "Conectando con base de datos...";
            this.dgv_productos.Enabled = false;
            this.lst_venta.Enabled = false;
            this.btn_agregarProducto.Enabled = false;
            this.btn_agregarStock.Enabled = false;
            this.btn_bajaProducto.Enabled = false;
            this.btn_cambiarPrecio.Enabled = false;
            this.btn_cancelarVenta.Enabled = false;
            this.btn_registrarVenta.Enabled = false;
            this.btn_restarStock.Enabled = false;
            this.btn_ventas.Enabled = false;
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                List<Producto> lista = BaseDatos.TraerProductos();
                if (this.btn_agregarProducto.InvokeRequired) // uno de los tantos botones que generó el hilo principal
                {
                    this.btn_agregarProducto.BeginInvoke(new Action(() => 
                    {
                        EvaluarConexionBDD(lista, HabilitarControles, NotificarConexionFallida);
                    }));
                }
            }, cts.Token);
        }

        /// <summary>
        /// Ejecuta las funciones ingresadas por parámetro según el estado de la lista de productos traída desde
        /// la base de datos.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="funcBien"></param>
        /// <param name="funcMal"></param>
        private void EvaluarConexionBDD(List<Producto> lista, EstadoConexionBBDD funcBien, EstadoConexionBBDD funcMal)
        {
            if (lista != null)
            {
                Logica.ActualizarDGV(dgv_productos, lista);
                funcBien("Conexion establecida");
            } else
            {
                funcMal("Conexión fallida");
            }
        }

        /// <summary>
        /// Habilita los controles bloqueados del formulario y esconde el mensaje exitoso después de 1 segundo.
        /// </summary>
        /// <param name="mensaje"></param>
        private void HabilitarControles(string mensaje)
        {
            this.lbl_cargando.Text = mensaje;
            this.dgv_productos.Enabled = true;
            this.lst_venta.Enabled = true;
            this.btn_agregarProducto.Enabled = true;
            this.btn_agregarStock.Enabled = true;
            this.btn_bajaProducto.Enabled = true;
            this.btn_cambiarPrecio.Enabled = true;
            this.btn_cancelarVenta.Enabled = true;
            this.btn_registrarVenta.Enabled = true;
            this.btn_restarStock.Enabled = true;
            this.btn_ventas.Enabled = true;
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                if (this.lbl_cargando.InvokeRequired)
                {
                    this.lbl_cargando.BeginInvoke(new Action(() =>
                    {
                        this.lbl_cargando.Visible = false;
                    }));
                }
            });
        }

        /// <summary>
        /// Informa que la conexión a la BBDD falló
        /// </summary>
        /// <param name="mensaje"></param>
        private void NotificarConexionFallida(string mensaje)
        {
            MessageBox.Show(mensaje + ". Verifique su conexión y reinicie el programa.", "Error en conexión", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.lbl_cargando.Text = mensaje;
        }

        private void dgv_productos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Producto productoAAgregar = TraerProductoDesdeDGV();
                productoAAgregar.onStockAcabado += AvisarQueNoHayStock;

                if (productoAAgregar.AgregarProductoACarrito(carritoProductos))
                {
                    productoAAgregar.RestarStock(1);
                    BaseDatos.ModificarCantidadProducto(productoAAgregar.Id, productoAAgregar.Cantidad);
                    this.precioParcial += productoAAgregar.Precio;
                    Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
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
                BaseDatos.AgregarVenta(nuevaVenta);
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
                Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
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
            try
            {
                Producto.DevolverProductosAStock(carritoProductos);
                FinalizarVenta();
            } catch(Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    sb.AppendLine(ex.Message);
                }

                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
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
                        BaseDatos.BorrarProducto(productoABorrar.Id); 
                        Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
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
                float nuevoPrecioProducto = 0;

                FormCantidadPrecio frmCantPrecio = new FormCantidadPrecio(false);
                if (frmCantPrecio.ShowDialog() == DialogResult.OK)
                {
                    nuevoPrecioProducto = frmCantPrecio.DevolverPrecio();
                    frmCantPrecio.Dispose();
                    BaseDatos.ModificarPrecioProducto(producto.Id, nuevoPrecioProducto);
                    Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
                }
            } catch(NoHayProductosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch(Exception ex)
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
                    BaseDatos.ModificarCantidadProducto(producto.Id, producto.Cantidad);
                    frmCantPrecio.Dispose();
                    Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
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
                producto.onStockAcabado += AvisarQueNoHayStock;

                FormCantidadPrecio frmCantPrecio = new FormCantidadPrecio(true);
                if (frmCantPrecio.ShowDialog() == DialogResult.OK)
                {
                    producto.RestarStock(frmCantPrecio.DevolverCantidad());

                    frmCantPrecio.Dispose();
                    BaseDatos.ModificarCantidadProducto(producto.Id, producto.Cantidad);
                    Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());
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
                Logica.ActualizarDGV(dgv_productos, BaseDatos.TraerProductos());

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
                cts.Cancel();
                if (this.carritoProductos.Count > 0)
                {
                    CancelarVenta();
                }
                this.Dispose();
            }
        }

        /// <summary>
        /// Este método fue creado para ser asociado al evento de un producto, cuando este ya no tiene más cantidad en stock.
        /// </summary>
        /// <param name="descripcionProducto"></param>
        private void AvisarQueNoHayStock(string descripcionProducto)
        {
            MessageBox.Show($"{descripcionProducto} no tiene más stock!\n" +
                $"Comunicarse con el proveedor correspondiente.");
        }

       
    }
}
