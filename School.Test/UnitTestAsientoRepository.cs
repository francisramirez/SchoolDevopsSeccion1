using Moq;
using School.Data.Context;
using School.Data.Entities;
using School.Data.Exceptions;
using School.Data.Repositories.Mocks;
namespace School.Test
{
    public class UnitTestAsientoRepository
    {
        [Fact]
        public void Actualizar_AsientoIsNull()
        {
            // Arrange //
            var context = new BoletosContext();
            var repository = new MockAsientoRepository(context);


            // Act
            Asiento asiento = null;

            // Assert//
            Assert.Throws<ArgumentNullException>(() => repository.Actualizar(asiento));

        }
        [Fact]
        public void Actualizar_Asiento_Not_Exists()
        {
            // Arrange //
            var context = new BoletosContext();
            var repository = new MockAsientoRepository(context);


            // Act
            Asiento asiento = new Asiento()
            {
                AsientoId = 8
            };

            // Assert//

            //var result = repository.Actualizar(asiento);
            //Assert.True(result);
            // Assert.IsType<ServiceResult>(result);

            Assert.Throws<AsientoNotExistsException>(() => repository.Actualizar(asiento));

        }
        [Fact]
        public void Ingresar_Asiento_Duplicado()
        {
            // Arrange //
            var context = new BoletosContext();
            var repository = new MockAsientoRepository(context);


            // Act
            Asiento asiento = new Asiento()
            {
                AsientoId = 1,
                BusId = 7
            };

            Assert.Throws<AsientoDuplicadoException>(() => repository.Agregar(asiento));

        }
        [Fact]
        public void ObtenerPorId_ReturnAsiento_WhenAsientoExist()
        {
            // Arrange //
            var context = new BoletosContext();
            var repository = new MockAsientoRepository(context);


            // Act
            int asientoId = 1;
            int busId = 1;
            var asiento = repository.ObtenerPorId(asientoId);

            // Assert //
            Assert.NotNull(asiento);
            var datos = Assert.IsType<Asiento>(asiento);
            Assert.Equal(datos.BusId, busId);
           

        }
    }
}