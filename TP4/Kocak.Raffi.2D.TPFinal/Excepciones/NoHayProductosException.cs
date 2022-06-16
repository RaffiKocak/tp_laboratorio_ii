using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NoHayProductosException : Exception
    {
        public NoHayProductosException(string mensaje) : base(mensaje)
        {

        }

        public NoHayProductosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
