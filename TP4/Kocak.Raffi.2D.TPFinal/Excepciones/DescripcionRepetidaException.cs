using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DescripcionRepetidaException : Exception
    {
        public DescripcionRepetidaException(string mensaje) : base(mensaje)
        {

        }

        public DescripcionRepetidaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
