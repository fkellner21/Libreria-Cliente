using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class AltaUsuario:IAlta<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;
        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public void Ejecutar(Usuario usuario)
        {
//            usuario.Password = PasswordHasher.HashPassword(usuario.Password); asi deberia ser
            usuario.PasswordHash = PasswordHasher.HashPassword(usuario.Password);
            _repositorioUsuario.Add(usuario);
        }
    }
}
