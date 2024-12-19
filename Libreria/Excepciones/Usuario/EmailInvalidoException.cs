using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Usuario
{
    internal class EmailInvalidoException:UsuarioInvalidoException
    {
        public EmailInvalidoException() : base("El valor recibido de Email, es invalido.") { }
    }
}
