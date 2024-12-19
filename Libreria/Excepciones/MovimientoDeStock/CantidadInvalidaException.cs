using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.MovimientoDeStock
{
    public class CantidadInvalidaException:MovimientoDeStockInvalidoException
    {
        public CantidadInvalidaException() : base("La cantidad debe estar entre 1 y el tope") { }
    }
}
