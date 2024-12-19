using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Resultado
    {
        public int Anio { get; set; }
        public int CantidadAnual { get; set; }
        public List<ResultadoAnual> resultadoAnual { get; set; }
    }
}
