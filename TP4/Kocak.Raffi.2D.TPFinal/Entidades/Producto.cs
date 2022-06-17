﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Producto : IInformacion
    {
        public enum TipoProducto
        {
            Comestible, Bebida, Varios
        }
        private int id;
        private TipoProducto tipo;
        private string descripcion;
        private float precioUnitario;
        private int cantidad;
        public event StockAcabado onStockAcabado;

        public int Id { get { return id; } set { id = value; } }

        public TipoProducto Tipo { get { return tipo; } set { tipo = value; } }

        public string Descripcion { get { return descripcion; } set { descripcion = value; } }

        public float Precio { get { return precioUnitario; } set { precioUnitario = value; } }

        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        //static Producto()
        //{
        //    string nombreArchivo = "ListaProductos";
        //    string rutaAChequear = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo + ".json";
        //    if (!File.Exists(rutaAChequear))
        //    {
        //        Producto.IncrementarUltimoId(0);
        //    }
        //}

        public Producto()
        {

        }

        public Producto(TipoProducto tipo, string descripcion, float precioUnitario, int cantidad)
        {
            try
            {
                //this.id = Producto.ObtenerUltimoId();
                this.id = 0;
                this.tipo = tipo;
                this.descripcion = descripcion;
                this.precioUnitario = precioUnitario;
                this.cantidad = cantidad;
                //Producto.IncrementarUltimoId(this.id);
                if (!Enum.IsDefined(typeof(TipoProducto), tipo) || string.IsNullOrEmpty(descripcion) 
                    || precioUnitario <= 0 || cantidad < 0)
                {
                    throw new Exception("Error en datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en construcción de producto", ex);
            }
        }

        private Producto(Producto producto)
        {
            this.id = producto.Id;
            this.tipo = producto.tipo;
            this.descripcion = producto.descripcion;
            this.precioUnitario = producto.precioUnitario;
            this.cantidad = 1;
        }

        public override string ToString()
        {
            return $"{this.descripcion} -- {this.cantidad} x ${this.precioUnitario} = ${this.cantidad * this.precioUnitario}";
        }

        /// <summary>
        /// Obtiene el ID a asignar a un nuevo producto desde un archivo de texto.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArchivoException"></exception>
        /// <exception cref="Exception"></exception>
        private static int ObtenerUltimoId()
        {
            try
            {
                string ultimoId = String.Empty;
                ultimoId = Archivo<string>.LeerTxt("ultimoIdProducto");
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
        /// Incrementa el numero almacenado en un archivo de texto para que el proximo producto 
        /// lo pueda utilizar al momento de crearse
        /// </summary>
        /// <param name="ultimoId"></param>
        /// <exception cref="Exception"></exception>
        private static void IncrementarUltimoId(int ultimoId)
        {
            try
            {
                ultimoId += 1;
                Archivo<string>.EscribirTxt("ultimoIdProducto", ultimoId.ToString());
            }
            catch (ArchivoException ex)
            {
                throw new Exception("Error al escribir el último ID", ex);
            }
        }

        /// <summary>
        /// Agrega una cantidad del producto al carrito de la compra que se esté efectuando en ese momento.
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns></returns>
        public bool AgregarProductoACarrito(List<Producto> carrito)
        {
            Producto productoAVender = null;
            int index;
            if (carrito != null && this.Cantidad > 0)
            {
                index = carrito.FindIndex( (x) => x.Id == this.Id);
                //index = ExisteProductoEnCarrito(carrito, this.id);
                if (index == -1)
                {
                    productoAVender = new Producto(this);
                    carrito.Add(productoAVender);
                }
                else
                {
                    carrito[index].cantidad++;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// En desuso, reemplazado por expresión lambda
        /// Verifica si el producto ya existe en el carrito de la compra a través de su ID.
        /// Retorna el índice si existe o -1 si no existe.
        /// </summary>
        /// <param name="carrito"></param>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        //public int ExisteProductoEnCarrito(List<Producto> carrito, int idProducto)
        //{
        //    if (carrito != null && idProducto > 0)
        //    {
        //        foreach (Producto item in carrito)
        //        {
        //            if (item.id == idProducto)
        //            {
        //                return carrito.IndexOf(item);
        //            }
        //        }
        //    }

        //    return -1;
        //}

        /// <summary>
        /// Devuelve toda la cantidad de los productos contenidos en el carrito al stock de productos.
        /// </summary>
        /// <param name="carrito"></param>
        public static void DevolverProductosAStock(List<Producto> carrito)
        {
            List<Producto> listaProductosBBDD = BaseDatos.TraerProductos();

            if (carrito != null && carrito.Count > 0)
            {
                foreach (Producto itemCarrito in carrito)
                {
                    foreach (Producto itemStock in listaProductosBBDD)
                    {
                        if (itemStock.id == itemCarrito.id)
                        {
                            itemStock.cantidad += itemCarrito.cantidad;
                            BaseDatos.ModificarCantidadProducto(itemStock.Id, itemStock.Cantidad);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Resta de forma segura varias cantidades de stock de un producto. 
        /// </summary>
        /// <param name="cantidadARestar"></param>
        /// <returns></returns>
        public void RestarStock(int cantidadARestar)
        {
            if (cantidadARestar >= this.Cantidad)
            {
                this.Cantidad = 0;
                onStockAcabado?.Invoke(this.Descripcion);
            } else
            {
                this.Cantidad -= cantidadARestar;
            }
        }

        /// <summary>
        /// Resta una cantidad del producto seleccionado en el carrito y la devuelve al stock de productos.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="carrito"></param>
        public static void RestarUnProductoDeCarrito(Producto producto, List<Producto> carrito)
        {
            if (producto != null)
            {
                List<Producto> listaProductosBBDD = BaseDatos.TraerProductos();
                producto.Cantidad--;
                foreach (Producto item in listaProductosBBDD)
                {
                    if (item.Id == producto.Id)
                    {
                        item.Cantidad++;
                        BaseDatos.ModificarCantidadProducto(item.Id, item.Cantidad);
                        break;
                    }
                }

                if (producto.Cantidad == 0)
                {
                    carrito.Remove(producto);
                }
            }
        }

        /// <summary>
        /// Metodo implementado de interfaz.
        /// Devuelve un string con toda la informacion del producto
        /// </summary>
        /// <returns></returns>
        public string DarInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo: {this.Tipo}");
            sb.AppendLine($"Descripcion: {this.Descripcion}");
            sb.AppendLine($"Precio: ${this.Precio}");
            sb.AppendLine($"Cantidad en stock: {this.Cantidad}");

            return sb.ToString();
        }
    }
}
