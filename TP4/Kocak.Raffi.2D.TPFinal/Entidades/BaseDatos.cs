using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class BaseDatos
    {
        static SqlConnection conexion;
        static SqlCommand comando;

        static BaseDatos() 
        {
            conexion = new SqlConnection(@"Data Source=.;Initial Catalog=TP4_RAFFI_KOCAK;Integrated Security=True");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Conecta con la base de datos y retorna una lista con todos los productos que se encuentran en ella.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Producto> TraerProductos()
        {
            try
            {
                List<Producto> listaProductos = new List<Producto>();
                
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.CommandText = "SELECT * FROM dbo.Productos";
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Producto productoDesdeBase = new Producto(
                            (Producto.TipoProducto)Convert.ToInt32(dataReader["TipoProducto"]),
                                dataReader["Descripcion"].ToString(),
                                float.Parse(dataReader["Precio"].ToString()),
                                Convert.ToInt32(dataReader["Cantidad"]));

                        productoDesdeBase.Id = Convert.ToInt32(dataReader["ID"]);
                        listaProductos.Add(productoDesdeBase);
                    }
                    return listaProductos;
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.ManagedThreadId == 0)
                {
                    throw new Exception("Error el traer lista de productos desde BBDD", ex);
                } else
                {
                    return null; // Sí se ejecuta en otro hilo, me retorna NULL y maneja la exc en ese hilo
                }
            }
            finally 
            { 
                conexion.Close(); 
            }
        }

        /// <summary>
        /// Modifica el precio del producto deseado según el ID ingresado por parámetro.
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="nuevoPrecio"></param>
        /// <exception cref="Exception"></exception>
        public static void ModificarPrecioProducto(int idProducto, float nuevoPrecio)
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.Parameters.Clear();
                comando.CommandText = "UPDATE dbo.Productos SET Precio = @precio WHERE ID = @id";
                comando.Parameters.AddWithValue("@precio", nuevoPrecio);
                comando.Parameters.AddWithValue("@id", idProducto);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al modificar la lista de productos a la BBDD");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Modifica la cantidad en stock del producto deseado según el ID ingresado por parámetro
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="nuevaCantidad"></param>
        /// <exception cref="Exception"></exception>
        public static void ModificarCantidadProducto(int idProducto, int nuevaCantidad)
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.Parameters.Clear();
                comando.CommandText = "UPDATE dbo.Productos SET Cantidad = @cantidad WHERE ID = @id";
                comando.Parameters.AddWithValue("@cantidad", nuevaCantidad);
                comando.Parameters.AddWithValue("@id", idProducto);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al modificar la lista de productos a la BBDD");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Borra el producto deseado según el ID ingresado por parámetro
        /// </summary>
        /// <param name="idProducto"></param>
        /// <exception cref="Exception"></exception>
        public static void BorrarProducto(int idProducto)
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.Parameters.Clear();
                comando.CommandText = "DELETE FROM dbo.Productos WHERE ID = @id";
                comando.Parameters.AddWithValue("@id", idProducto);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar un producto de la BBDD");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Agrega el producto ingresado por parámetro a la base de datos.
        /// </summary>
        /// <param name="producto"></param>
        /// <exception cref="Exception"></exception>
        public static void AgregarProducto(Producto producto)
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO dbo.Productos (TipoProducto, Descripcion, Precio, Cantidad) " +
                    "VALUES (@tipoProducto, @descripcion, @precio, @cantidad)";
                comando.Parameters.AddWithValue("@tipoProducto", (int)producto.Tipo);
                comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar un producto a la BBDD");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Agrega la venta ingresada por parámetro a la base de datos
        /// </summary>
        /// <param name="venta"></param>
        /// <exception cref="Exception"></exception>
        public static void AgregarVenta(Venta venta)
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO dbo.Ventas (FechaVenta, Precio, ProductosVendidos) " +
                    "VALUES (@fechaVenta, @precio, @productosVendidos)";
                comando.Parameters.AddWithValue("@fechaVenta", venta.FechaVenta);
                comando.Parameters.AddWithValue("@precio", venta.Precio);
                comando.Parameters.AddWithValue("@productosVendidos", venta.ProductosVendidos);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar una venta a la BBDD");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Conecta con la base de datos y retorna una lista con todas las ventas que se encuentran en ella.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Venta> TraerVentas()
        {
            try
            {
                List<Venta> listaVentas = new List<Venta>();

                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.CommandText = "SELECT * FROM dbo.Ventas";
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Venta ventaDesdeBase = new Venta(DateTime.Parse(dataReader["FechaVenta"].ToString()),
                                float.Parse(dataReader["Precio"].ToString()),
                                dataReader["ProductosVendidos"].ToString());

                        ventaDesdeBase.Id = Convert.ToInt32(dataReader["Id"]);
                        listaVentas.Add(ventaDesdeBase);
                    }
                    return listaVentas;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error el traer lista de ventas desde BBDD");
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
