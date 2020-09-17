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
        /// validara y realizara la operaciones pedida entre ambos numero.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns> retorno el resultado.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            //que hago si el string esta vacio o no es un caracter.
            double retorno = 0;

            string validarOpe = ValidarOperador(Convert.ToChar(operador));

            switch (validarOpe)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Metodo a validar que el operador recibido sea +, -, / o *.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>retorna el operador validado</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno ;

            if ( operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno =  Convert.ToString(operador);
            }
            else
            {
                retorno = "+";
            }

            return retorno;
        }


    }
}
