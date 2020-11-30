using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExcepciones
{
    public class BaseDeDatoException : Exception
    {
        public BaseDeDatoException()
        {

        }
        public BaseDeDatoException(string mesaje):base(mesaje)
        {

        }
    }
}
