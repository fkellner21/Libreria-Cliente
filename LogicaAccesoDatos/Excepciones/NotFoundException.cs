
namespace LogicaAccesoDatos.Excepciones
{
    public class NotFoundException : InfrastructuraException
    {

        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }

        public override int statusCode()
        {
            return 404;
        }
    }
}
