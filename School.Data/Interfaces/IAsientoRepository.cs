
using School.Data.Entities;

namespace School.Data.Interfaces
{
    public interface IAsientoRepository
    {
        void Agregar(Asiento asiento);
        void Actualizar(Asiento asiento);
        void Remover(Asiento asiento);
        List<Asiento> TraerTodos();
        Asiento ObtenerPorId(int asientoId);
    }
}
