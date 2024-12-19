using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones.TipoDeMovimiento
{
    public class TipoDeMovimientoInvalidoException:DominioExcpetion
    {
            public TipoDeMovimientoInvalidoException() { }
            public TipoDeMovimientoInvalidoException(string message) : base("Tipo de movimiento invalido, asegurese de completar todos los campos") { }

    }
}
