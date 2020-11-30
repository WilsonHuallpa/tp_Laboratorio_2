using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExcepciones
{
    public class StringException: Exception
    {
        public StringException(string mensaje) : base(mensaje)
        {

        }
    }
}
