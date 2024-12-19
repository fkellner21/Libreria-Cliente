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
    public class ObtenerUsuario:IObtener<Usuario>
    {
        IRepositorioUsuario _repositorioUsuarios;
        public ObtenerUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuarios = repositorioUsuario;
        }
        public Usuario Ejecutar(int id)
        {
            return _repositorioUsuarios.GetById(id);
        }
    }
}
