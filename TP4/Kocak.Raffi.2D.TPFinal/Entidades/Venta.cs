using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Venta : IInformacion
    {
        private int id;
        private DateTime fechaVenta;
        private float precio;
        private string productosVendidos;

        public int Id { get { return id; } set { id = value; } }

        public DateTime FechaVenta { get { return fechaVenta; } set { fechaVenta = value; } }
        
        public float Precio { get { return precio; } set { precio = value; } }

        public string ProductosVendidos {
            get 
            { 
                return productosVendidos; 
            } 
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    productosVendidos = value;
                } else
                {
                    throw new Exception("Error al construir objeto venta");
                }
                
            } 
        }

        public Venta()
        {

        }

        public Venta(float precio, string productosVendidos)
        {
            try
            {
                //this.id = Venta.ObtenerUltimoId();
                this.id = 0;
                this.fechaVenta = DateTime.Now;
                this.precio = precio;
                this.ProductosVendidos = productosVendidos;
                //Venta.IncrementarUltimoId(this.id);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Constructor para traer datos desde BBDD
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fechaVenta"></param>
        /// <param name="precio"></param>
        /// <param name="productosVendidos"></param>
        public Venta(DateTime fechaVenta, float precio, string productosVendidos)
        {
            try 
            {
                this.fechaVenta = fechaVenta;
                this.precio = precio;
                this.productosVendidos = productosVendidos;
                if (precio <= 0 || string.IsNullOrEmpty(productosVendidos))
                {
                    throw new Exception("Error en datos");
                }
            } catch(Exception ex)
            {
                throw ex;
            }

            
        }

        /// <summary>
        /// Registra las descripciones y cantidades de los productos correspondientes a una venta.
        /// </summary>
        /// <param name="carritoProductos"></param>
        /// <returns></returns>
        public static string RegistrarProductosVendidos(List<Producto> carritoProductos)
        {
            StringBuilder sb = new StringBuilder();
            if (carritoProductos != null)
            {
                foreach (Producto item in carritoProductos)
                {
                    sb.AppendLine(item.Descripcion + " x " + item.Cantidad.ToString());
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Cuenta la cantidad de ventas que hay registradas en total
        /// </summary>
        /// <returns></returns>
        public static int ContarCantidadVentas()
        {
            List<Venta> ventasdeBBDD = BaseDatos.TraerVentas();
            return ventasdeBBDD.Count;
        }
        
        /// <summary>
        /// Calcula el total recaudado que hay en todas las ventas registradas
        /// </summary>
        /// <returns></returns>
        public static float ContarTotalRecaudado()
        {
            float acumulador = 0;
            List<Venta> ventasdeBBDD = BaseDatos.TraerVentas();
            foreach (Venta item in ventasdeBBDD)
            {
                acumulador += item.Precio;
            }

            return acumulador;
        }

        /// <summary>
        /// Obtiene el ID a asignar a una nueva venta desde un archivo de texto.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArchivoException"></exception>
        /// <exception cref="Exception"></exception>
        private static int ObtenerUltimoId()
        {
            try
            {
                string ultimoId = String.Empty;
                ultimoId = Archivo<string>.LeerTxt("ultimoIdVenta");
                return int.Parse(ultimoId);
            }
            catch (ArchivoException ex)
            {
                throw new ArchivoException("Error en obtención de último ID", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        /// <summary>
        /// Incrementa el numero almacenado en un archivo de texto para que la proxima venta
        /// lo pueda utilizar al momento de crearse
        /// </summary>
        /// <param name="ultimoId"></param>
        /// <exception cref="Exception"></exception>
        private static void IncrementarUltimoId(int ultimoId)
        {
            try
            {
                ultimoId += 1;
                Archivo<string>.EscribirTxt("ultimoIdVenta", ultimoId.ToString());
            }
            catch (ArchivoException ex)
            {
                throw new Exception("Error al escribir el último ID", ex);
            }
        }

        /// <summary>
        /// Metodo implementado de interfaz.
        /// Devuelve un string con toda la informacion de la venta
        /// </summary>
        /// <returns></returns>
        public string DarInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Fecha: {this.fechaVenta}");
            sb.AppendLine("");
            sb.AppendLine($"Productos comprados:");
            sb.AppendLine($"{this.productosVendidos}");
            sb.AppendLine($"Precio cobrado: ${this.precio}");

            return sb.ToString();
        }
    }
}
