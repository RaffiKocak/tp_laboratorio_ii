using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public static class Validacion
    {
        /// <summary>
        /// Valida que el string ingresado por parametro cumpla con el formato de un numero flotante.
        /// Tambien que no sea negativo o sea excesivamente alto.
        /// </summary>
        /// <param name="numeroIngresado"></param>
        /// <returns></returns>
        public static float ValidarPrecio(string numeroIngresado)
        {
            int contadorComas = 0;
            float precio = 0;
            DatosInvalidosException excepcion = new DatosInvalidosException("Los datos ingresados no son válidos");

            numeroIngresado = numeroIngresado.Replace('.', ',');

            foreach (char c in numeroIngresado)
            {
                if (!char.IsDigit(c))
                {
                    if (c == ',')
                    {
                        contadorComas++;
                        if (contadorComas > 2)
                        {
                            throw excepcion;
                        }
                    }
                    else
                    {
                        throw excepcion;
                    }
                }
            }

            precio = float.Parse(numeroIngresado);

            if (precio <= 0 || precio > 50000)
            {
                throw excepcion;
            }

            return precio;
        }

        /// <summary>
        /// Valida que el string ingresado cumpla con el formato de un numero entero.
        /// Tambien que no sea negativo o excesivamente alto.
        /// </summary>
        /// <param name="numeroIngresado"></param>
        /// <returns></returns>
        /// <exception cref="DatosInvalidosException"></exception>
        public static int ValidarCantidad(string numeroIngresado)
        {
            if (int.TryParse(numeroIngresado, out int numero) && numero >= 0 && numero <= 1000)
            {
                return numero;
            }

            throw new DatosInvalidosException("Los datos ingresados no son válidos");
        }

        /// <summary>
        /// Valida que el string ingresado no se encuentre repetido en las descripciones del stock ya existente.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <exception cref="DescripcionRepetidaException"></exception>
        public static void ValidarDescripcionUnica(string descripcion)
        {
            List<Producto> listaProductosBBDD = BaseDatos.TraerProductos();
            if (!string.IsNullOrEmpty(descripcion))
            {
                descripcion = descripcion.ToLower();
                foreach (Producto item in listaProductosBBDD)
                {
                    if (item.Descripcion.ToLower() == descripcion)
                    {
                        throw new DescripcionRepetidaException("Este producto ya existe");
                    }
                }
            }
        }
    }
}
