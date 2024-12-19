using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class PrecioDeVentaInvalidoException:ArticuloInvalidoException
    {
        public PrecioDeVentaInvalidoException() : base("El precio debe ser un valor positivo.") { }
    }
}
