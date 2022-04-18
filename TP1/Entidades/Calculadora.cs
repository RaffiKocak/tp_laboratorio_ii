using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el caracter ingresado por parámetro sea '+','-','*' o '/'
        /// </summary>
        /// <param name="operador">Caracter de operador a ser validado</param>
        /// <returns>Retorna el caracter correspondiente a la operación. Si no es ninguno, retorna '+'</returns>
        private static char ValidarOperador(char operador)
        {
            char operadorARetornar;
            switch (operador)
            {
                // asd
                case '+':
                    operadorARetornar = '+';
                    break;

                case '-':
                    operadorARetornar = '-';
                    break;

                case '*':
                    operadorARetornar = '*';
                    break;

                case '/':
                    operadorARetornar = '/';
                    break;

                default:
                    operadorARetornar = '+';
                    break;
            }

            return operadorARetornar;
        }

        /// <summary>
        /// Realiza una operación matemática, pudiendo ser una suma, resta, multiplicación o división.
        /// </summary>
        /// <param name="numUno">Primer número utilizado en la operación</param>
        /// <param name="numDos">Segundo número utilizado en la operación</param>
        /// <param name="operador">Determina qué operación se realizará.</param>
        /// <returns>Retorna el resultado de la operación matemática o 0 si no se pudo realizar.3</returns>
        public static double Operar(Operando numUno, Operando numDos, char operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = numUno + numDos;
                    break;

                case '-':
                    resultado = numUno - numDos;
                    break;

                case '*':
                    resultado = numUno * numDos;
                    break;

                case '/':
                    resultado = numUno / numDos;
                    break;
            }

            return resultado;
        }
    }
}