﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExcepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(string mensaje) : base(mensaje)
        {

        }
    }
}
