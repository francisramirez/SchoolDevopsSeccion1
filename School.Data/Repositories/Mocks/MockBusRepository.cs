

using School.Data.Entities;
using School.Data.Interfaces;

namespace School.Data.Repositories.Mocks
{
    public class MockBusRepository : IBusRepository
    {
        public void Actualizar(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Bus bus)
        {
            throw new NotImplementedException();
        }

        public Bus ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bus> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
