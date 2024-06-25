

using School.Data.Entities;

namespace School.Data.Interfaces
{
    public interface IBusRepository
    {
        void Agregar(Bus bus);
        void Actualizar(Bus bus);
      
        List<Bus> TraerTodos();
        Bus ObtenerPorId(int id);
    }
}
