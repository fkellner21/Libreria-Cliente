
namespace LogicaAccesoDatos.Excepciones
{
    public class BadRequestException : InfrastructuraException
    {
        public BadRequestException() { }
        public BadRequestException(string message) : base(message) { }

        public override int statusCode()
        {
            return 400;
        }
    }
}
