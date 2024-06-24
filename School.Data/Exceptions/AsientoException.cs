

namespace School.Data.Exceptions
{
    public class AsientoNullException : Exception
    {
        public AsientoNullException(string message) : base(message) 
        {
            // x logica para guardar el log del error y enviar la notificacion.    
        }
    }
}
