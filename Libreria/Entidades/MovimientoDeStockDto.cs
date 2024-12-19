using LogicaDeNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class MovimientoDeStockDto
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public int articuloId { get; set; }
        public int tipoId { get; set; }
        public string ejecutorEmail { get; set; }
        public int cantidad { get; set; }
    }
}
