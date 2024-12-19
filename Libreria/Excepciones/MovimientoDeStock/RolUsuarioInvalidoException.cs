using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.MovimientoDeStock
{
    public class RolUsuarioInvalidoException:MovimientoDeStockInvalidoException
    {
        public RolUsuarioInvalidoException() : base("El ejecutor debe ser un encargado") { }

    }
}
