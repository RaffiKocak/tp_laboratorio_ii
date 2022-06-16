using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException(string mensaje) : base(mensaje)
        {

        }

        public DatosInvalidosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
