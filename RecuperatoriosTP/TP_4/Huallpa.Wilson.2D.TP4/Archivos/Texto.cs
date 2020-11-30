﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ManejoExcepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        /// <summary>
        /// Guarda un archivo en formato texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si se guardo correctamente, false caso contrario</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
                {
                    using (StreamWriter sw = new StreamWriter(archivo, true))
                    {
                        sw.WriteLine(datos);
                    }
                    return true;
                }
            }
            catch(Exception)
            {
                throw new ArchivosException("Error al intentar guardar archivo de texto");
            }
            return false;
        }
        /// <summary>
        /// Lee archivos en formato texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si se leyo correctamente, false caso contrario</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                datos = String.Empty;

                if (File.Exists(archivo))
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        datos = sr.ReadToEnd();
                        return true;
                    }
                }
            }
            catch(Exception)
            {
                throw new ArchivosException("Error al intentar leer archivo de texto");
            }
            return false;
        }
        #endregion
    }
}
