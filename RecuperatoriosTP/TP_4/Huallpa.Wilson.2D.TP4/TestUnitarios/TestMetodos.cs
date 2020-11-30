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
        public void TestMethod1()
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

        //[TestMethod]

        //public void TestMethod1()
        //{

        //}


    }
}
