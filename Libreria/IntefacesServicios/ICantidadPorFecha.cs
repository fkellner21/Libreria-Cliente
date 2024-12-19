using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface ICantidadPorFecha<T>
    {
        public int Ejecutar(DateTime desde, DateTime hasta);
    }
}
