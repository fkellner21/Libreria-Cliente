using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface IObtenerPorFecha<T>
    {
        public IEnumerable<T> Ejecutar(DateTime desde, DateTime hasta, int page);
    }
}
