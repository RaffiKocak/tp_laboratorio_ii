using System;

namespace Excepciones
{
    public class CamposVaciosException : Exception
    {
        public CamposVaciosException(string mensaje) : base(mensaje)
        {
            
        }

        public CamposVaciosException(string mensaje, Exception innerException) : base(mensaje, innerException   )
        {

        }
    }
}
