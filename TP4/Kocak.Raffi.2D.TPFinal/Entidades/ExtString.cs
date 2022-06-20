using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtString
    {
		/// <summary>
		/// Método extendido de la clase String. Le da un formato prolijo a la descripción de un producto.
		/// </summary>
		/// <param name="descripcion"></param>
		/// <returns></returns>
        public static string FormatearDescripcionProducto(this string descripcion)
        {
			string descripcionFormateada = string.Empty;
			descripcion = descripcion.ToLower().Trim();

			char[] descArray = descripcion.ToCharArray();

			descArray[0] = char.ToUpper(descripcion[0]);
			descripcionFormateada += descArray[0];
			for (int i = 1; i < descripcion.Length; i++)
			{
				if (descripcion[i] == ' ' || descripcion[i] == '-')
				{
					descArray[i + 1] = char.ToUpper(descArray[i+1]);
				}

				descripcionFormateada += descArray[i];
			}

			return descripcionFormateada;
		}
    }
}
