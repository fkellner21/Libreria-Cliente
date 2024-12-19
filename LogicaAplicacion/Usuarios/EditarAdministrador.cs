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
    public class EditarAdministrador:IEditar<Administrador>
    {
        IRepositorioUsuario _repositorioUsuario;
        public EditarAdministrador(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public void Ejecutar(int id, Administrador admin)
        {
            admin.PasswordHash=PasswordHasher.HashPassword(admin.Password);
            _repositorioUsuario.UpdateAdmin(id, admin);
        }
    }
}
