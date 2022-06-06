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
        private List<string> productosVendidos;

        public int Id { get { return id; } set { id = value; } }

        public DateTime FechaVenta { get { return fechaVenta; } set { fechaVenta = value; } }
        
        public float Precio { get { return precio; } set { precio = value; } }

        public List<string> ProductosVendidos { get { return productosVendidos; } set { productosVendidos = value; } }

        public Venta()
        {

        }

        public Venta(float precio, List<string> productosVendidos)
        {
            try
            {
                this.id = Venta.ObtenerUltimoId();
                this.fechaVenta = DateTime.Now;
                this.precio = precio;
                this.productosVendidos = productosVendidos;
                Venta.IncrementarUltimoId(this.id);
            } catch(Exception)
            {
                throw new Exception("Error en construcción de venta");
            }
            
        }

        /// <summary>
        /// Registra las descripciones y cantidades de los productos correspondientes a una venta.
        /// </summary>
        /// <param name="carritoProductos"></param>
        /// <returns></returns>
        public static List<string> RegistrarProductosVendidos(List<Producto> carritoProductos)
        {
            List<string> listaProductos = null;
            StringBuilder sb = new StringBuilder();
            if (carritoProductos != null)
            {
                listaProductos = new List<string>();

                foreach (Producto item in carritoProductos)
                {
                    sb.AppendLine(item.Descripcion + " x " + item.Cantidad.ToString());
                }

                listaProductos.Add(sb.ToString());
            }

            return listaProductos;
        }

        /// <summary>
        /// Cuenta la cantidad de ventas que hay registradas en total
        /// </summary>
        /// <returns></returns>
        public static int ContarCantidadVentas()
        {
            return Kiosko.registroVentas.Count;
        }
        
        /// <summary>
        /// Calcula el total recaudado que hay en todas las ventas registradas
        /// </summary>
        /// <returns></returns>
        public static float ContarTotalRecaudado()
        {
            float acumulador = 0;
            foreach(Venta item in Kiosko.registroVentas)
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
            foreach(string item in this.productosVendidos)
            {
                sb.AppendLine(item);
            }
            sb.AppendLine($"Precio cobrado: ${this.precio}");

            return sb.ToString();
        }
    }
}
