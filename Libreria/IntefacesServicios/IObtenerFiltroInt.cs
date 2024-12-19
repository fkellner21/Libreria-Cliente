using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface IObtenerFiltroInt<T>
    {
        public IEnumerable<T> Ejecutar(int filtro);

    }
}
