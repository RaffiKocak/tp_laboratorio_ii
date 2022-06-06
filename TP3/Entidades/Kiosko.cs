using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Kiosko
    {
        public static List<Producto> listaProductos;
        public static List<Venta> registroVentas;

        static Kiosko()
        {
            listaProductos = new List<Producto>();
            registroVentas = new List<Venta>();
        }

        /// <summary>
        /// Carga los productos desde el archivo ListaProductos.json, si existe. 
        /// Si no, crea productos para tener a modo de demostracion
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void CargarProductos()
        {
            try
            {
                string nombreArchivo = "ListaProductos";
                string rutaAChequear = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo + ".json";
                if (File.Exists(rutaAChequear))
                {
                    listaProductos = Archivo<List<Producto>>.LeerJson(nombreArchivo);
                } else
                {
                    listaProductos.Add(new Producto(Producto.TipoProducto.Comestible, "Alfajor Capitan del Espacio 40g", 100, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Comestible, "Alfajor Jorgito 55g", 120, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Comestible, "Alfajorcitos x6 Jorgito 155g", 200, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Bebida, "Coca-Cola 500ml", 100, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Bebida, "Coca-Cola 1.5l", 130, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Bebida, "Agua KIN 500ml", 100, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Varios, "Pack x10 Figuritas Mundial 2022 VAMO MESSI", 80, 50));
                    listaProductos.Add(new Producto(Producto.TipoProducto.Varios, "Preservativos PRIME x6 - Version Star Wars", 200, 50));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en carga forzda de productos", ex);
            }
        }

        /// <summary>
        /// Carga ventas que hayan sido guardadas desde el archivo ListaVentas.xml, si es que existen.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void CargarVentas()
        {
            try
            {
                string nombreArchivo = "ListaVentas";
                string rutaAChequear = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo + ".xml";

                if (File.Exists(rutaAChequear))
                {
                    registroVentas = Archivo<List<Venta>>.LeerXml(nombreArchivo);
                }
            } catch (Exception ex)
            {
                throw new Exception("Error en carga forzada de ventas", ex);
            }
        }
    }
}
