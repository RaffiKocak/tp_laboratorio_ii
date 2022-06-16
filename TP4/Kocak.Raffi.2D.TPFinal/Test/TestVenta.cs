using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestVenta
    {
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void Venta_AltaVenta_DeberiaDarExcepcion()
        {
            //Arrange
            float precio = 150;
            string productosVendidos = null;

            //Act
            Venta venta = new Venta(precio, productosVendidos);

            //Assert
            Assert.IsTrue(true);
        }
    }
}