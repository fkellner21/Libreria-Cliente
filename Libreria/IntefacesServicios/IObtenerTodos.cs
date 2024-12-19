
namespace LogicaDeNegocio.IntefacesServicios
{
    public interface IObtenerTodos <T>
    {
        public IEnumerable<T> Ejecutar();
    }
}
