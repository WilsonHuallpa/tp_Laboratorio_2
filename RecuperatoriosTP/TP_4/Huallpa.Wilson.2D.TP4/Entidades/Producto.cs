using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ManejoExcepciones;

namespace Entidades
{
    public abstract class Producto
    {
        #region campos
        int codigo;
        double precio;
        string descripcion;
        int stock;
        ETipo tipoProducto;
        #endregion

        #region enum de tipos
        public enum ETipo
        {
            lacteo,
            limpieza,
            bebidas,
            perfumeria
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private Producto()
        {
            this.descripcion = "sin descripcion";
            this.codigo = -1;
            this.precio = -1;
            this.stock = -1;
        }

        /// <summary>
        /// Constructor de objetos de tipo Producto
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="codigo"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="tipoProducto"></param>
        public Producto(string descripcion, int codigo, double precio, int stock, ETipo tipoProducto) : this()
        {
            this.Descripcion = descripcion;
            this.codigo = codigo;
            this.precio = precio;
            this.Stock = stock;
            this.tipoProducto = tipoProducto;
        }
        
        #endregion

        #region Propiedades
        /// <summary>
        ///  Propiedad Getter del campo codigo de barra.
        /// </summary>
        public int Codigo
        {
            get { return this.codigo; }

            set { this.codigo = value; }
        }

        /// <summary>
        ///  Propiedad Getter del campo Precio.
        /// </summary>
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        /// <summary>
        ///  Propiedad Getter del campo descripcion.
        /// </summary>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = ValidacionesDeDatos.ValidarDescripcion(value);}
        }

        public int Stock
        {
            get { return this.stock; }

            set
            {
                this.stock = value;

                if (this.stock < 0)
                {
                    this.stock = 0;
                }
            }
        }
        public ETipo Tipo
        {
            get { return this.tipoProducto; }

            set { this.tipoProducto = value; }
        }

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga operador == sobre una lista de producto y un producto.
        /// </summary>
        /// <param name="listaProductos"></param>
        /// <param name="auxProducto"></param>
        /// <returns>True si un producto es igual a uno de la lista de producto, false si no.</returns>
        public static bool operator == (List<Producto> listaProductos, Producto auxProducto)
        {
            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos[i].codigo == auxProducto.codigo)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga operador != sobre una lista de productos y un producto
        /// </summary>
        /// <param name="listaProductos"></param>
        /// <param name="auxProducto"></param>
        /// <returns>True si un producto es distinto a lista de productos, false si no.</returns>
        public static bool operator != (List<Producto> listaProductos, Producto auxProducto)
        {
            return !(listaProductos == auxProducto);
        }

        /// <summary>
        /// Sobrecarga operador +, agrega un producto ala lista de producto
        /// </summary>
        /// <param name="listaProductos"></param>
        /// <param name="auxProducto"></param>
        /// <returns>True si se agrego corectamente, false solo modificara el stock del producto.</returns>
        public static bool operator + (List<Producto> listaProductos, Producto auxProducto)
        {
            bool retorno = false;

            if (listaProductos != auxProducto)
            {
                listaProductos.Add(auxProducto);
                BaseDeDatos.InsertaProducto(auxProducto);
                retorno = true;
            }
            else
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    if (listaProductos[i].codigo == auxProducto.codigo)
                    {
                        listaProductos[i].Stock = auxProducto.Stock;
                        BaseDeDatos.ActualizarProducto(auxProducto);

                    }
                }
            }

            return retorno;
        }
        
        /// <summary>
        /// Verifica si un producto no esta cargado en la base de datos y lo elimina
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="auxProducto"></param>
        /// <returns>true si se logro eliminar correctamente</returns>
        public static bool operator - (List<Producto> listaProductos, Producto auxProducto)
        {

            if (listaProductos == auxProducto)
            {
                listaProductos.Remove(auxProducto);
                BaseDeDatos.EliminarProductos(auxProducto);
                return true;
            }
            return false;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Genera un stringbuilder con todos los datos del producto
        /// </summary>
        /// <returns>string con todo los del productos</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Descripcion: {this.descripcion}");
            sb.AppendLine($"Stock: {this.stock.ToString()}");
            sb.AppendLine($"ID Producto: {this.codigo.ToString()}");
            sb.AppendLine(String.Format("Precio: ${0: #,###.00}", this.precio));

            return sb.ToString();
        }
        #endregion
    }
}
