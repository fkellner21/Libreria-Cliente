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
    public class Login:ILogin<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;
        public Login(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public Usuario Ejecutar(string email, string password)
        {
            password = PasswordHasher.HashPassword(password);
            return _repositorioUsuario.Login(email, password);
        }
    }
}
