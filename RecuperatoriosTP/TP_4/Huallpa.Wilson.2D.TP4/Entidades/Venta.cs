using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManejoExcepciones;
using Archivos;
using System.Threading;

namespace Entidades
{
    public class Venta
    {
        #region Campos
        string ticketNro;
        List<Carrito> listaProducto;
        double montoTotal;
        #endregion
        /// <summary>
        /// Constructor estatico. Asocia los metodos al delegado.
        /// </summary>
        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Venta()
        {
            ticketNro = "sin numero";
            listaProducto = new List<Carrito>();
            montoTotal = 0;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="productos"></param>
        public Venta(string ticket, List<Carrito> productos):this()
        {
            this.TicketNro = ticket;
            this.listaProducto = productos;
            this.MontoCalcular = productos;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Getter / Setter numero de ticket
        /// </summary>
        public string TicketNro { get => ticketNro; set => ticketNro = value; }

        /// <summary>
        /// Getter / Setter lista de productos
        /// </summary>
        public List<Carrito> ListaProducto { get => listaProducto; set => listaProducto = value; }

        /// <summary>
        /// Getter / Setter monto total a abonar
        /// </summary>
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }

        /// <summary>
        /// Setter del total de monto, 
        /// </summary>
        public List<Carrito> MontoCalcular {

            set{ this.montoTotal = CalcularTotal(value); }
        }


        #endregion

        #region Metodos


        /// <summary>
        /// Imprime un diseño de un ticket en formato txt
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>true si imprimio el ticket, caso contrario false</returns>
        public static bool PrintTicket(Venta venta)
        {
            bool retorno = false;
            string path;

            if(venta != null)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + venta.ticketNro;
                Texto texto = new Texto();
                return texto.Guardar(path, venta.DiseñoTicke());
            }

            return retorno;
        }

        /// <summary>
        /// lee un ticket guardado en formato txt
        /// </summary>
        /// <param name="path"></param>
        /// <returns>los datos guardados</returns>
        public static string Leer(string path)
        {
            string datos;
            Texto auxTexto = new Texto();

            auxTexto.Leer(path, out datos);

            return datos;
        }

        /// <summary>
        /// Calcula y asigna el valor del monto total
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>Devuelve el total de la lista de producto, o si es null (cero)/returns>
        private double CalcularTotal(List<Carrito> Productos)
        {
            double acumulador = 0;

            if (Productos != null)
            {
                foreach (Carrito item in Productos)
                {
                    acumulador += item.Precio;
                }
                return acumulador;
            }
            return acumulador;
        }

        #endregion


    }
}
