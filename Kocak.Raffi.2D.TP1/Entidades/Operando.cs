using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        // Atributos
        double numero;

        // -------------------Constructores-------------------

        /// <summary>
        /// Construye el objeto e inicializa el atributo numero en 0.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Construye el objeto y define el atributo numero con el valor ingresado por parámetro.
        /// </summary>
        /// <param name="numero">Valor con el cual se inicializará el atributo numero.</param>
        public Operando(double numero) : this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// Construye el objeto y define el atributo numero a través de la propiedad Numero.
        /// </summary>
        /// <param name="numero">Valor en texto con el cual intentará definirse el atributo numero.</param>
        public Operando(string numero) : this()
        {
            this.Numero = numero;
        }

        // -------------------Propiedades-------------------

        /// <summary>
        /// Define el atributo numero, siendo previamente validado.
        /// </summary>
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        // -------------------Validaciones-------------------

        /// <summary>
        /// Valida una cadena de texto, intentando darle un valor numérico.
        /// </summary>
        /// <param name="strNumero">Valor en texto a validar.</param>
        /// <returns>Retornará el valor numérico de la cadena. En caso de ser imposible, retornará el valor 0.</returns>
        private static double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double operandoValido))
            {
                return operandoValido;
            }

            return 0;
        }

        /// <summary>
        /// Comprueba que una cadena de texto sólo esté compuesta de los números 0 y 1.
        /// </summary>
        /// <param name="binario">Binario a validar</param>
        /// <returns>Retornará true si está compuesto solamente por caracteres 0 o 1. Si no, retornará false.</returns>
        private static bool EsBinario(string binario)
        {
            foreach (char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }

        // -------------------Conversiones-------------------

        /// <summary>
        /// Convierte un número binario a decimal.
        /// </summary>
        /// <param name="binario">Número binario a convertir.</param>
        /// <returns>Retorna la cadena de caracteres del número convertido. Si no es posible, retornará "Valor inválido".</returns>
        public static string BinarioDecimal(string binario)
        {
            int longitud = binario.Length - 1;
            double numeroDecimal = 0;
            int contador = 0;

            if (EsBinario(binario))
            {
                for (int i = longitud; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        numeroDecimal += Math.Pow(2, contador);
                    }

                    contador++;
                }

                return numeroDecimal.ToString();
            }

            return "Valor inválido";
        }

        /// <summary>
        /// Convierte un número decimal a binario.
        /// </summary>
        /// <param name="numero">Número decimal a convertir.</param>
        /// <returns>Retorna la cadena de caracteres del número convertido. En caso de no ser posible, retornará una cadena vacía.</returns>
        public static string DecimalBinario(double numero)
        {
            string binarioADevolver = "";
            int numeroAbsoluto = (int)Math.Abs(numero);
            int resto;

            if (numeroAbsoluto == 0)
            {
                binarioADevolver = "0";
            }

            while (numeroAbsoluto > 0)
            {
                resto = numeroAbsoluto % 2;
                numeroAbsoluto /= 2;

                binarioADevolver = resto + binarioADevolver;
            }

            return binarioADevolver;
        }

        /// <summary>
        /// Convierte un número decimal a binario.
        /// </summary>
        /// <param name="numero">Número decimal a convertir.</param>
        /// <returns>Retorna la cadena de caracteres del número convertido. En caso de no ser posible, retornará "Valor inválido".</returns>
        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double numeroAConvertir))
            {
                return DecimalBinario(numeroAConvertir);
            }

            return "Valor inválido";
        }

        // -------------------Sobrecargas operadores-------------------

        /// <summary>
        /// Suma los valores del atributo numero de 2 operandos.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Retorna el resultado de la operación realizada.</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta los valores del atributo numero de 2 operandos.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Retorna el resultado de la operación realizada.</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica los valores del atributo numero de 2 operandos.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Retorna el resultado de la operación realizada.</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }


        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }

            return double.MinValue;
        }

    }
}