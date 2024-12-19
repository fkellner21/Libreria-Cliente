using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Usuario
{
    public class PasswordInvalidoException:UsuarioInvalidoException
    {
        public PasswordInvalidoException() : base("El password recibido no cumple con las exigencias minimas de seguridad.") { }
    }
}
