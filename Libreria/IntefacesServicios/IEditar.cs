
namespace LogicaDeNegocio.IntefacesServicios
{
    public interface IEditar <T>
    {
        public void Ejecutar(int id, T obj);
    }
}
