using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.MovimientoDeStock
{
    public class ArticuloDeMovimientoInvalidoException:MovimientoDeStockInvalidoException
    {
        public ArticuloDeMovimientoInvalidoException() : base("El movimiento no se hizo sobre un articulo valido") { }

    }
}
