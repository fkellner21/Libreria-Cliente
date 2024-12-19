using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Usuario
{
    public class UsuarioInvalidoException:DominioExcpetion
    {
        public UsuarioInvalidoException() { }
        public UsuarioInvalidoException(string message) : base(message) { }
    }
}
