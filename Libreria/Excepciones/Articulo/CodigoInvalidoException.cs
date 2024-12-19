using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class CodigoInvalidoException : ArticuloInvalidoException
    {
        public CodigoInvalidoException() : base("El codico no tiene el rango solicitado (13)") { }
    }
}
