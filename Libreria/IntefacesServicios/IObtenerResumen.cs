using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface IObtenerResumen
    {
        public IEnumerable<Resultado> Ejecutar();
    }
}
