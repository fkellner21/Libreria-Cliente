using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class NombreNoVacioException : ArticuloInvalidoException
    {
        public NombreNoVacioException(): base("El nombre no tiene que estar vacio") { }
    }
}
