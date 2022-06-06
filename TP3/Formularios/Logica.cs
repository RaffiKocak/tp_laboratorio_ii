using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    internal static class Logica
    {
        /// <summary>
        /// Actualiza la informacion de un DataGridView con una lista de cualquier tipo de dato.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dgv"></param>
        /// <param name="listaIngresada"></param>
        public static void ActualizarDGV<T>(DataGridView dgv, List<T> listaIngresada)
        {
            dgv.DataSource = null;
            dgv.DataSource = listaIngresada;
        }
    }
}
