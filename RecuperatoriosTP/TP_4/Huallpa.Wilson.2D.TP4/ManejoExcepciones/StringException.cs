using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExcepciones
{
    public class StringException: Exception
    {
        /// <summary>
        /// se lanza un string exception en caso de error de formato.
        /// </summary>
        /// <param name="mensaje"></param>
        public StringException(string mensaje) : base(mensaje)
        {

        }
    }
}
