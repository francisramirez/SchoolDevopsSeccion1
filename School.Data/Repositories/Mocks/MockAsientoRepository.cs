using School.Data.Context;
using School.Data.Entities;
using School.Data.Exceptions;
using School.Data.Interfaces;
using System.Runtime.InteropServices;

namespace School.Data.Repositories.Mocks
{
    public class MockAsientoRepository : IAsientoRepository
    {
        private readonly BoletosContext context;

        public MockAsientoRepository(BoletosContext context)
        {
            this.context = context;

            this.CargarDatos();

        }
        public void Actualizar(Asiento asiento)
        {
            if (EsAsientoNull(asiento))
                throw new AsientoNullException("El objeto asiento no debe de ser nulo.");


            Asiento asientoToUpdate = this.context.Asientos.Find(asiento.AsientoId);

            if (asientoToUpdate is null)
                throw new AsientoNotExistsException("El asiento no se encuentra registrado.");


            asientoToUpdate.BusId = asiento.BusId;
            asientoToUpdate.NumeroAsiento = asiento.NumeroAsiento;
            asientoToUpdate.NumeroPiso = asiento.NumeroPiso;
            asientoToUpdate.FechaCreacion = asiento.FechaCreacion;

            this.context.Asientos.Update(asientoToUpdate);
            this.context.SaveChanges();

        }

        public void Agregar(Asiento asiento)
        {
            if (EsAsientoNull(asiento))
                throw new AsientoNullException("El objeto asiento no debe de ser nulo.");


            if (ExisteAsiento(asiento.AsientoId, asiento.BusId))
                throw new AsientoDuplicadoException($"Este asiento {asiento.AsientoId} para este bus: {asiento.BusId} se encuentra registrado.");

            

             Asiento asientoToAdd = new Asiento()
            {
                AsientoId = asiento.AsientoId,
                BusId = asiento.BusId,
                FechaCreacion = asiento.FechaCreacion,
                NumeroAsiento = asiento.NumeroAsiento,
                NumeroPiso = asiento.NumeroPiso,
            };

            this.context.Asientos.Add(asientoToAdd);
            this.context.SaveChanges();
        }

        public Asiento ObtenerPorId(int asientoId)
        {
            return this.context.Asientos.Find(asientoId);
        }

        public void Remover(Asiento asiento)
        {

            if (EsAsientoNull(asiento))
                throw new AsientoNullException("El objeto asiento no debe de ser nulo.");


            Asiento asientoToRemove = this.context.Asientos.Find(asiento.AsientoId);

            if (asientoToRemove is null)
                throw new AsientoNotExistsException("El asiento no se encuentra registrado.");



            this.context.Asientos.Remove(asientoToRemove);
            this.context.SaveChanges();

        }

        public List<Asiento> TraerTodos()
        {
            return this.context.Asientos.ToList();
        }

        private void CargarDatos()
        {

            if (!this.context.Asientos.Any())
            {
                List<Asiento> asientos = new List<Asiento>()
            {
                new Asiento()
                {
                    AsientoId = 1,
                    BusId = 1,
                    FechaCreacion = DateTime.Now,
                    NumeroAsiento = 100,
                    NumeroPiso = 1,
                },
                new Asiento()
                {
                    AsientoId = 2,
                    BusId = 1,
                    FechaCreacion = DateTime.Now,
                    NumeroAsiento = 101,
                    NumeroPiso = 1,
                },
                new Asiento()
                {
                    AsientoId = 3,
                    BusId = 1,
                    FechaCreacion = DateTime.Now,
                    NumeroAsiento = 102,
                    NumeroPiso = 1,
                },
                new Asiento()
                {
                    AsientoId = 4,
                    BusId = 1,
                    FechaCreacion = DateTime.Now,
                    NumeroAsiento = 103,
                    NumeroPiso = 1,
                }
            };


                this.context.Asientos.AddRange(asientos);
                this.context.SaveChanges();
            }



        }

        private bool EsAsientoNull(Asiento asiento)
        {
            bool result = false;

            if (asiento == null)
                result = true;

            return result;
        }

        private bool ExisteAsiento(int asientoId, int busId)
        {
            return this.context.Asientos.Any(cd => cd.AsientoId == asientoId && cd.BusId == busId);
        }

        private void LimpiarDatos(List<Asiento> asientos)
        {
            this.context.Asientos.RemoveRange(asientos);
            this.context.SaveChanges();
        }
    }
}
