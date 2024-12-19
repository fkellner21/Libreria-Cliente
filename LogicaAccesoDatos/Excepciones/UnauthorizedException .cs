
namespace LogicaAccesoDatos.Excepciones
{
    public class UnauthorizedException : InfrastructuraException
    {
        public override int statusCode()
        {
            return 401;
        }
    }
}
