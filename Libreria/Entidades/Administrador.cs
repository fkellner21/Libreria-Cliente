using LogicaDeNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Administrador : Usuario
    {
        public bool ModificaUsuario { get; set; }
        public Administrador() : base() { }
        public Administrador(bool modificaUsuario, string Email, string Password, string Nombre, string Apellido) : base(Email, Password, Nombre, Apellido)
        {
            ModificaUsuario = modificaUsuario;
        }

        public override void Validar()
        {
            base.Validar();
            if (ModificaUsuario == null)
            {
                throw new AdministradorInvalidoException();
            }
        }
        public override void Update(Usuario obj)
        {
            base.Update(obj);
            Administrador admin= obj as Administrador;
            admin.Validar();
            ModificaUsuario=admin.ModificaUsuario;
        }
    }
}
