using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Entidades;
using ManejoExcepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Wilson Huallpa 2D TP N°4";

            Thread  v_01= new Thread(Inventario.Cajero_01 );
            Thread  v_02= new Thread(Inventario.Cajero_02 );    
            
            ProductoNoPerecedero miProd1 = new ProductoNoPerecedero("trapo", 24 , 22, 22, Producto.ETipo.limpieza);
          


            try
            {
                Inventario.Iniciar();

                Console.WriteLine($"La cantidad de productos traidos de la base es {Inventario.ListaProductos.Count} y son los siguientes: \n");

                Console.WriteLine(Inventario.ListaProductos.MostrarListaProducto());

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

                if (Inventario.ListaProductos + miProd1)
                {
                    Console.WriteLine("Se agrego bueno producto ala tabla de datos:  {0}", miProd1.Descripcion);
                }
                else
                {
                    Console.WriteLine("Producto exitente se modifico la candidad {0}", miProd1.Descripcion);
                }
              
                Console.WriteLine($"La cantidad de productos traidos de la base es {Inventario.ListaProductos.Count} y son los siguientes: \n");

                Console.WriteLine(Inventario.ListaProductos.MostrarListaProducto());

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (BaseDeDatoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Se intentará generar 6 nuevas ventas aleatorias, en diferentes cajerros");

            try
            {
                v_01.Name = "Cajero 1";
                v_02.Name = "Cajero 2";
                Console.WriteLine("SE GENERAN VENTAS DESDE DOS HILOS DIFERENTES");
                v_01.Start();
                v_02.Start();
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("ventas");
            try
            {
                foreach (Venta item in Inventario.Listaventas)
                {
                    Console.WriteLine(item.DiseñoTicke());
                }

                if (Inventario.GuardarVentas(Inventario.Listaventas))
                {
                    Console.WriteLine("Todas la ventas se guardaron en Archivo  XML");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Se lee archivo de texto  de _01.txt");
            try
            {
                string ticke = Venta.Leer("_01");
                Console.WriteLine(ticke);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();


        }
    }
}
