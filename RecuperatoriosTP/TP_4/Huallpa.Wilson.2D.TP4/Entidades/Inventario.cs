using Archivos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    public delegate void MiInventario();
    //public delegate void FuncionesVenta();
    public static class Inventario
    {
        #region Campos
        static List<Producto> listaProductos;
        static List<Venta> listaventas;
        static string nombreComercio;
       
        static public event MiInventario CargaDedatos;
        #endregion

        #region Constructores
        /// <summary>
        /// constructor por defecto.
        /// </summary>
        static Inventario()
        {
            nombreComercio = "MiNegocio";
            listaProductos = new List<Producto>();
            listaventas = new List<Venta>();

            CargaDedatos += BaseDeDatos.GetProductos;
            CargaDedatos += LeerVentasRealizadas;

        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad get,set listaventas.
        /// </summary>
        public static List<Venta> Listaventas { get => listaventas; set => listaventas = value; }

        /// <summary>
        /// Propiedad get de nombreComercio.
        /// </summary>
        public static string NombreComercio { get => nombreComercio; set => nombreComercio = value; }

        /// <summary>
        /// Propiedad de get,set de listaProduco.
        /// </summary>
        public static List<Producto> ListaProductos { get => listaProductos; set => listaProductos = value; }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida si el valor de stock solicitado es menor al disponible.
        /// </summary>
        /// <param name="idProducto"> id del producto.</param>
        /// <param name="auxCantidad">Cantidad sugerida</param>
        /// <returns>true si auxcantidad es menor o igual al stock de producto.</returns>
        //public static bool ValidarCantidad(int idProducto, int auxCantidad)
        //{
        //    for (int i = 0; i < ListaProductos.Count; i++)
        //    {
        //        if (ListaProductos[i].Codigo == idProducto && ListaProductos[i].Stock >= auxCantidad)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Guarda el listado de ventas en archivo XML
        /// </summary>
        /// <param name="inv"></param>
        /// <returns>true si lo guardo, false caso contrario</returns>
        public static bool GuardarVentas(List<Venta> ventas)
        {
            string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Ventas.xml");

            Xml<List<Venta>> auxUni = new Xml<List<Venta>>();

            return auxUni.Guardar(path, ventas);
        }

        /// <summary>
        /// Lee el listado de ventas guardado en un archivo XML
        /// </summary>
        /// <returns>una lista de tipo List<Venta></returns>
        public static void LeerVentasRealizadas()
        {
            List<Venta> datos = new List<Venta>();
            string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Ventas.xml");
            Xml<List<Venta>> inv = new Xml<List<Venta>>();
            
            if (inv.Leer(path, out datos))
            {
                for (int i = 0; i < datos.Count; i++)
                {
                    listaventas.Add(datos[i]);
                }
            }
        }

        /// <summary>
        /// Carga productos al carrito de compras.
        /// </summary>
        /// <returns>Un lista de todo los productos cargados </returns>
        private static List<Carrito> GeneraCarrito()
        {
            List<Carrito> auxlista = new List<Carrito>();

            Random nRand = new Random(DateTime.Now.Millisecond);

            int index;

            int cantProducto = nRand.Next(1, 3);

            while (cantProducto > 0)
            {
                index = nRand.Next(0,listaProductos.Count);

                if (ListaProductos[index].Stock >= 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                      auxlista.Add(new Carrito(listaProductos[index].Descripcion, listaProductos[index].Precio, listaProductos[index].Codigo));
                    }
                    listaProductos[index].Stock -= 2;
                    cantProducto--;
                }     
            }
            return auxlista;
        }

        /// <summary>
        /// Genera un hardcodeo de ventas a traves de un hilo
        /// </summary>
        public static void Cajero_01()
        {
            Venta auxVenta;
            List<Carrito> lisCarrito;
            int i = 0;
            try
            {
                do {
                    lisCarrito = GeneraCarrito();

                    if (lisCarrito != null)
                    {

                        Thread.Sleep(2000);
                        auxVenta = new Venta("_01", lisCarrito);

                        listaventas.Add(auxVenta);

                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: { auxVenta.TicketNro}");

                        if (Venta.PrintTicket(auxVenta))
                        {
                            Console.WriteLine("Se genero un ticke de el {0}.txt ", auxVenta.TicketNro);
                        }
                       
                        i++;
                    }
                } while (i < 3);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }

        /// <summary>
        /// Genera un hardcodeo de ventas a traves de un hilo
        /// </summary>
        public static void Cajero_02()
        {
            Venta auxVenta;
            List<Carrito> lisCarrito;
            int i = 0;
            try
            {
                do
                {
                    lisCarrito = GeneraCarrito();

                    if (lisCarrito != null)
                    {
                        Thread.Sleep(1000);

                        auxVenta = new Venta("_02", lisCarrito);

                        if (CargarVenta(auxVenta) && Venta.PrintTicket(auxVenta))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;

                            Console.WriteLine($"Se genero una nueva venta en {Thread.CurrentThread.Name} ticket Nro.: { auxVenta.TicketNro}");

                            Console.WriteLine("Se genero un ticke de el {0}.txt ", auxVenta.TicketNro);
                        }
  
                        i++;
                    }
                } while (i < 3);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Agrega una nueva venta a la lista de inventario
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>true si se cargo, false caso contrario</returns>
        public static bool CargarVenta(Venta venta)
        {
            if (venta != null)
            {
                Inventario.listaventas.Add(venta);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Invoca al evento CargarComercio
        /// </summary>
        public static void Iniciar()
        {
            CargaDedatos.Invoke();
        }

        #endregion

    }
}
