using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using ManejoExcepciones;
using Archivos;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class TestMetodos
    {
        /// <summary>
        /// testea si se enprime correctamente el ticke de una venta.
        /// </summary>
        [TestMethod]
        public void InprimirTicke()
        {
            Venta venta01;
            List<Carrito> carroDecompra = new List<Carrito>();

            carroDecompra.Add(new Carrito("leche", 70, 12));
            carroDecompra.Add(new Carrito("azucar", 30, 11));
            carroDecompra.Add(new Carrito("escoba", 30, 10));
            carroDecompra.Add(new Carrito("trapo", 30, 9));
            venta01 = new Venta("01", carroDecompra);

            Assert.IsTrue(Venta.PrintTicket(venta01));
        }
        /// <summary>
        /// testea que no devuelva null al crear un carrito de ventas.
        /// </summary>
        [TestMethod]
        public void CrearCarrito()
        {
            List<Producto> list = new List<Producto>();
            list.Add(new ProductoPerecedero("ala", 3, 50, 20, Producto.ETipo.limpieza));
            list.Add(new ProductoPerecedero("queso", 3, 50, 20, Producto.ETipo.lacteo));
            list.Add(new ProductoPerecedero("vino", 3, 50, 20, Producto.ETipo.bebidas));
            list.Add(new ProductoPerecedero("escoba", 3, 50, 20, Producto.ETipo.limpieza));

            Assert.IsNotNull(Inventario.GeneraCarrito(list));
        }


    }
}
