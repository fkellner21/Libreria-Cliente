using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.MovimientoDeStock
{
    public class MovimientoDeStockInvalidoException:DominioExcpetion
    {
            public MovimientoDeStockInvalidoException() { }
            public MovimientoDeStockInvalidoException(string message) : base("Movimiento invalido") { }

    }
}
