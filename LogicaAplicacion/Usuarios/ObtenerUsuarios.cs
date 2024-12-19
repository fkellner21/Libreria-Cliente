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
    public class ObtenerUsuarios:IObtenerTodos<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;
        public ObtenerUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public IEnumerable<Usuario> Ejecutar()
        {
            return _repositorioUsuario.GetAll();
        }
    }
}
