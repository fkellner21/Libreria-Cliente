using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.Articulo
{
    public class StockInvalidoException:ArticuloInvalidoException
    {
        public StockInvalidoException():base("El stock debe ser mayor a 0.") { }
    }
}
