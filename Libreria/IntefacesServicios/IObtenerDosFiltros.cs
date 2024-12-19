using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface IObtenerDosFiltros<T>
    {
        public IEnumerable<T> Ejecutar(int filtro, int segundo, int page);
    }
}
