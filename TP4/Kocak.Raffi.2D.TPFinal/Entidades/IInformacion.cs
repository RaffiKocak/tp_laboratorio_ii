using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal interface IInformacion
    {
        /// <summary>
        /// Metodo para mostrar toda la informacion referida a la instancia
        /// del objeto de la clase que lo implementa
        /// </summary>
        /// <returns></returns>
        string DarInfo();
    }
}
