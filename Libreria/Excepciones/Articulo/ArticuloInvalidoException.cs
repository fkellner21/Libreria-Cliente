using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class ArticuloInvalidoException : DominioExcpetion
    {
        public ArticuloInvalidoException() { }
        public ArticuloInvalidoException(string message) : base(message) { }
    }
}
