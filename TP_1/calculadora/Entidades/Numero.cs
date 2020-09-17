using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        
        /// <summary>
        /// valida el valor resivido, y luego le asigna a numero.
        /// </summary>
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        /// <summary>
        /// constructor por defecto, se asigna 0 al numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="numero">Recibe por paramero un numero tipo double</param>
        public Numero(double numero): this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="strNumero">Recibe por parametro un numero tipo string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Convierte un numero binario a numero decimal.
        /// </summary>
        /// <param name="binario">Recibe por parametro un binario tipo string</param>
        /// <returns>Numero convertido en decimal</returns>
        public static string BinarioDecimal(string binario)
        {
            int numero = 0;
            string resultado = "Valor invalido";
            char[] list = binario.ToCharArray();

            Array.Reverse(list);

            if (EsBinario(binario))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == '1')
                    {
                        numero += (int)Math.Pow(2, i);
                    }
                }

                resultado = numero.ToString();
            }
            
            return resultado;
        }
        /// <summary>
        /// Convierte un numero decimal en numero binario.
        /// </summary>
        /// <param name="numero">Recibe un numero de tipo double</param>
        /// <returns>Numero convertido a binario</returns>
        public static string DecimalBinario(double numero)
        {

            int num = (int)numero;

            string binario = "";

            if( num > 0)
            {
                while (num > 0)
                {

                    binario = num % 2 + binario;
                    num = num / 2;
                }
            }
            else
            {
                if(num == 0)
                {
                    binario = "0";
                }
                else
                {
                    binario = "Valor invalido";
                }
            }

            return binario;
        }
        /// <summary>
        /// Convierte un numero decimal en numero binario.
        /// </summary>
        /// <param name="numero">Recibe por parametro un nuemro de tipo string</param>
        /// <returns>El numero convertido a binario</returns>
        public static string DecimalBinario(string numero)
        {
            string binario;
            double validar;
            if(double.TryParse(numero, out validar))
            {
                binario = DecimalBinario(Convert.ToDouble(numero));
                return binario;
            }
            else
            {
                return "Valor invalido";
            }
                
            
        }
        /// <summary>
        /// valida si un numero es binario
        /// </summary>
        /// <param name="binario">Recibe como parametro un numero tipo string</param>
        /// <returns>False si no es binario, true si lo es.</returns>
        public static bool EsBinario(string binario)
        {

            char[] array = binario.ToCharArray();

            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '0' && array[i] != '1')
                {
                        return false;
                     
                }
            }

            return true ;
        }
        /// <summary>
        /// Resta dos objeto de tipo Numero. 
        /// </summary>
        /// <param name="num1">Recibe un objeto de tipo Numero</param>
        /// <param name="num2">Recibe un objerto de tipo Numero</param>
        /// <returns>la resta de los dos elemento </returns>
        public static double operator - (Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        /// <summary>
        /// Multiplica dos objeto tipo Numero
        /// </summary>
        /// <param name="num1">Recibe un objeto de tipo Numero</param>
        /// <param name="num2">Recibe un objeto de tipo Numero</param>
        /// <returns>la multiplicaion de los elemento.</returns>
        public static double operator * (Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        /// <summary>
        /// Divide dos objeto de tipo Numero
        /// </summary>
        /// <param name="num1">Recibe un objeto de tipo Numero</param>
        /// <param name="num2">Recibe un objeto de tipo Numero</param>
        /// <returns>la divicion de los elementos</returns>
        public static double operator / (Numero num1, Numero num2)
        {
            if (num2.numero == 0 )
            {
                return double.MinValue;
            }
            else
            {
                return num1.numero / num2.numero;
            }
           
        }
        /// <summary>
        /// suma dos objeto de tipo Numero
        /// </summary>
        /// <param name="num1">Recibe un objeto de tipo Numero</param>
        /// <param name="num2">Recibe un objeto de tipo Numero</param>
        /// <returns>la suma  de los elemento</returns>
        public static double operator + (Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        /// <summary>
        /// valida si se trata de un numero
        /// </summary>
        /// <param name="strNumero">Recibe como parametro un numero de tipo string</param>
        /// <returns>false si no es un numero, true si lo es</returns>
        private double ValidarNumero(string strNumero)
        {
           
            double flotante;

            if ( !double.TryParse(strNumero, out flotante))
            {
                flotante = 0;
            }

            return flotante;
        }




    }
}
