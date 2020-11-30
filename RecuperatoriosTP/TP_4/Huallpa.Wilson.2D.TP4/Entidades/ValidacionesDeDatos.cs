using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManejoExcepciones;
namespace Entidades
{
    public static class ValidacionesDeDatos
    {

        #region Metodo
        /// <summary>
        /// Metodo validar descripcion.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string ValidarDescripcion(string dato)
        {
            if (String.IsNullOrEmpty(dato) || dato.Length < 2)
            {
                throw new StringException("Campo Descripcion vacio, o muy corto ");
            }

            for (int i = 0; i < dato.Length; i++)
            {
                if (((int)dato[i] >= 32 && dato[i] <= 64) || ((int)dato[i] >= 91 && (int)dato[i] <= 96) || ((int)dato[i] >= 123 && (int)dato[i] <= 255))
                {
                    throw new StringException("Solo Se puede ingresar letras");
                }
            }

            return dato;
        }
        /// <summary>
        /// valida el campo precio que sea solo double
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static double ValidarPrecio(string datos)
        {
            double flotante;

            if (!double.TryParse(datos, out flotante))
            {
                throw new Exception("Error.. en Precio, Ingrese correctamente.");
            }
            return flotante;
        }
        /// <summary>
        /// valida el campo entero de codigo y stock que solo se entero.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static int ValidarEntero(string datos)
        {
            int entero;
            if (!int.TryParse(datos, out entero))
            {
                throw new Exception("Error.. en (codigo o cantida), Ingrese correctamente.");
            }
            return entero;
        }
        #endregion
    }
}
