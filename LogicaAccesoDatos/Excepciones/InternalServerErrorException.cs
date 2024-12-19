
namespace LogicaAccesoDatos.Excepciones
{
    public class InternalServerErrorException : InfrastructuraException
    {
        public InternalServerErrorException() { }
        public InternalServerErrorException(string message) : base(message) { }

        public override int statusCode()
        {
            return 500;
        }
    }
}
