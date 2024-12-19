
using LogicaAccesoDatos.Dtos;
using System.Text.Json;

namespace LogicaAccesoDatos.Excepciones
{
    public abstract class InfrastructuraException : Exception
    {
        private string _message;

        public InfrastructuraException() { }
        public InfrastructuraException(string message) : base(message) { }

        public abstract int statusCode();

        public Error Error()
        {
            Error error = new Error(
                statusCode(),
                _message
                // detalle del problema"",
                // link de la doc
                );
            return error; //
            //JsonSerializer.Serialize(error);
        }
    }
}

       



