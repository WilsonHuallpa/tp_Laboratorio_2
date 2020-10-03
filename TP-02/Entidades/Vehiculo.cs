using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #pragma warning disable CS0660
    #pragma warning disable CS0661

    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>

    public abstract class Vehiculo

    {
        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault, 
            Toyota, 
            BMW, 
            Honda,
            HarleyDavidson
        }

        public enum ETamanio
        {
            Chico, 
            Mediano, 
            Grande
        }

        EMarca marca;
        string chasis;
        ConsoleColor color;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }



        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio {get;} 

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns> un string con todos los datos </returns>
        
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA: {this.marca.ToString()}");
            sb.AppendLine($"COLOR: {this.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
  
        /// <summary>
        /// Sobrecarga de operador
        /// </summary>
        /// <param name="p"> Metodo mostrar del vehiculo en cuestion</param>
        public static explicit operator string (Vehiculo p)
        {
            return p.Mostrar();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator == (Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>true si comparten el mismo chasism, false caso contrario</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }

    }
}
