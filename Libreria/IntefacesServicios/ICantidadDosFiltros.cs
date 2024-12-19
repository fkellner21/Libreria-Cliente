using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface ICantidadDosFiltros<T>
    {
        public int Ejecutar(int idArt, int idTipo);
    }
}
