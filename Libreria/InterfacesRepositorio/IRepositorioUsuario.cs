using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public IEnumerable<Administrador> GetAllAdministrador();
        public Administrador GetAdminById(int id);
        public void UpdateAdmin(int id,  Administrador administrador);
        public Usuario Login(string email, string password); 
        public Usuario GetByEmail(string email);
        public string Token(Usuario usuario);
    }
}
