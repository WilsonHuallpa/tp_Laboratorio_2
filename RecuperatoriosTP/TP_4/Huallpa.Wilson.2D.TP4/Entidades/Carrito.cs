using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrito
    {
        #region Atributos
        string descripcion;
        double precio;
        int id;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructur por defecto
        /// </summary>
        public Carrito()
        {
            this.descripcion = "Sin decripcion";
            this.precio = -1;
            this.id = -1;
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="decripcion"></param>
        /// <param name="precio"></param>
        /// <param name="id"></param>
        public Carrito(string decripcion, double precio, int id) : this()
        {
            this.descripcion = decripcion;
            this.precio = precio;
            this.id = id;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propidad de Get/Set id compra
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Propiedad de Get/Set Desgreciones 
        /// </summary>
        public string Descripcion { get => descripcion; set => descripcion = value; }

        /// <summary>
        /// Propiedad Get/Set del precio.
        /// </summary>
        public double Precio { get => precio; set => precio = value; }

        #endregion

    }
}
