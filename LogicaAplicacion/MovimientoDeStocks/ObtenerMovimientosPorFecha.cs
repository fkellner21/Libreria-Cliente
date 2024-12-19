using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.MovimientoDeStocks
{
    public class ObtenerMovimientosPorFecha:IObtenerPorFecha<MovimientoDeStock>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientoDeStock;
        public ObtenerMovimientosPorFecha(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            _repositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }
        public IEnumerable<MovimientoDeStock> Ejecutar(DateTime desde, DateTime hasta, int page)
        {
            return _repositorioMovimientoDeStock.GetMovPorFecha(desde, hasta, page);
        }
    }
}
