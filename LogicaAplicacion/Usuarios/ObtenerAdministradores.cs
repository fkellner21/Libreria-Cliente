using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerAdministradores:IObtenerTodos<Administrador>
    {
        IRepositorioUsuario _repositorioUsuario;
        public ObtenerAdministradores(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public IEnumerable<Administrador> Ejecutar()
        {
            return _repositorioUsuario.GetAllAdministrador();
        }
    }
}
