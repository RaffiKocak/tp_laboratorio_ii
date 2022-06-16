using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class TestProducto
    {
        [TestMethod]
        public void Producto_AltaProducto_DeberiaSerExitosa()
        {
            //Arrange
            Producto.TipoProducto tipo = Producto.TipoProducto.Comestible;
            string descripcion = "ProductoPrueba";
            float precio = 150;
            int cantidad = 30;

            //Act
            Producto producto = new Producto(tipo, descripcion, precio, cantidad);

            //Assert
            Assert.IsNotNull(producto);
        }
    }
}
