using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Usuario
{
    internal class AdministradorInvalidoException:UsuarioInvalidoException
    {
        public AdministradorInvalidoException() : base("El valor recibido de Administrador, es inválido.") { }
    }
}
