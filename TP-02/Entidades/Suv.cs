using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   
    public class Suv : Vehiculo
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {

        }

        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio 
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        /// <summary>
        /// Crea un stringbuider con todos los datos del vehiculo
        /// </summary>
        /// <returns>string con todos los datos</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
