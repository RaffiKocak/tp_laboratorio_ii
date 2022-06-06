using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.IO;
using System;

namespace Test
{
    [TestClass]
    public class TestArchivo
    {
        [TestMethod]
        public void Archivo_EscribirJson_DeberiaEscribirCorrectamente()
        {
            //Arrange
            string nombreArchivo = "EscribirJsonTest";
            string datoAGuardar = "Hola, naci porque necesito justificar que Raffi sabe hacer testing unitario";

            //Act
            Archivo<string>.EscribirJson(nombreArchivo, datoAGuardar);

            //Assert
            Assert.IsTrue(File.Exists(AppDomain.CurrentDomain.BaseDirectory + nombreArchivo + ".json"));
        }
    }
}