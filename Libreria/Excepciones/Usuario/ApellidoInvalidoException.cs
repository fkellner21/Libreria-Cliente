using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Usuario
{
    public class ApellidoInvalidoException:UsuarioInvalidoException
    {
        public ApellidoInvalidoException() : base("El valor recibido de Apellido, es invalido.") { }
    }
}
