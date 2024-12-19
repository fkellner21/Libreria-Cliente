using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Usuario
{
    public class NombreInvalidoException:UsuarioInvalidoException
    {
        public NombreInvalidoException() : base("El valor recibido de Nombre, es invalido.") { }
    }
}
