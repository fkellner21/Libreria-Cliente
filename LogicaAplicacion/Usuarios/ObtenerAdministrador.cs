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
    public class ObtenerAdministrador:IObtener<Administrador>
    {
        IRepositorioUsuario _repositorioUsuarios;
        public ObtenerAdministrador(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuarios = repositorioUsuario;
        }
        public Administrador Ejecutar(int id)
        {
            return _repositorioUsuarios.GetAdminById(id);
        }
    }
}
