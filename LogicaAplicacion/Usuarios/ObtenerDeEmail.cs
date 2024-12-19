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
    public class ObtenerDeEmail:IObtenerDeString<Usuario>
    {
        IRepositorioUsuario _repositorioUsuarios;
        public ObtenerDeEmail(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuarios = repositorioUsuario;
        }
        public Usuario Ejecutar(string email)
        {
            return _repositorioUsuarios.GetByEmail(email);
        }
    }
}
