using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace System.Collections.Generic
{
    public static class ListExtension
    {
        /// <summary>
        /// Muestra un lista de todos lo producto cargados.
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static string MostrarListaProducto(this List<Producto> productos)
        {
            StringBuilder sb = new StringBuilder();

            string titulo = "-------------------" + "Lista Producto" + "-------------------";
            string asterisquitos = string.Empty;
            string codigo = "CODIGO";
            string descripcion ="DESCRIPCION";
            string precio = "PRECIO";
            string cantidad = "CANTIDA";
            for (int i = 0; i < titulo.Length; i++)
            {
                asterisquitos += "*";
            }

            sb.AppendLine(asterisquitos);
            sb.AppendLine(titulo);
            sb.AppendLine(asterisquitos);
            sb.AppendLine(String.Format("{0,-12}|{1,-12}|{2,-12}|{3,-12}|",codigo,descripcion,precio,cantidad));

            foreach (Producto item in productos) 
            {
                sb.AppendLine(String.Format("{0,-12}|{1,-12}|${2,-11: #,###.00}|{3,-12}|", item.Codigo, item.Descripcion, item.Precio,item.Stock));
            }
            sb.AppendLine(asterisquitos);

            return sb.ToString();
        }

        /// <summary>
        /// Crea un diseño de ticke de todos los campos de la venta.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>string del diseño del ticke</returns>
        public static string DiseñoTicke(this Venta v)
        {
            StringBuilder sb = new StringBuilder();
            DateTime dateTime = DateTime.Now;
            string titulo = "****************" + "FACTURA: " + v.TicketNro.ToString() + "****************";
            string asterisquitos = string.Empty;
            for (int i = 0; i < titulo.Length; i++)
            {
                asterisquitos += "*";
            }

            sb.AppendLine(asterisquitos);
            sb.AppendLine(titulo);
            sb.AppendLine(asterisquitos);
            sb.AppendLine($"Enpresa::{Inventario.NombreComercio}");
            sb.AppendLine($"Fecha:: {dateTime.ToString("MM/dd/yyy")} Hora:: {dateTime.ToString("HH:mm")}");
            foreach (Carrito item in v.ListaProducto)
            {
                sb.AppendLine(String.Format("Descripcion: {0} Precio: ${1: #,###.00}", item.Descripcion, item.Precio));
            }

            sb.AppendLine(String.Format("Monto total: ${0: #,###.00}", v.MontoTotal));
            sb.AppendLine(asterisquitos);
            return sb.ToString();
        }

    }
}