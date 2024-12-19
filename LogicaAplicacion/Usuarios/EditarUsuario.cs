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
    public class EditarUsuario:IEditar<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;
        public EditarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public void Ejecutar(int id, Usuario usuario)
        {
            _repositorioUsuario.Update(id, usuario);
        }
    }
}
