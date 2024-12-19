using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;


namespace LogicaAplicacion.Usuarios
{
    public class ObtenerToken : IObtenerToken
    {
        IRepositorioUsuario _repositorioUsuario;
        public ObtenerToken(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public string Ejecutar(Usuario unUsuario)
        {
            return _repositorioUsuario.Token(unUsuario);
        }
    }
}
