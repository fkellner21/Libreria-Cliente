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
    public class EliminarUsuario:IEliminar<Usuario>
    {
        IRepositorioUsuario _repositorioUsuarios;
        public EliminarUsuario(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }
        public void Ejecutar(int id)
        {
            _repositorioUsuarios.Delete(id);
        }
    }
}
