using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class DescripcionInvalidoException : ArticuloInvalidoException
    {
        public DescripcionInvalidoException() : base("La Descripcion no cumple con el largo (5)") { }
    }
}
