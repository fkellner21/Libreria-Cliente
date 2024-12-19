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
    public class ObtenerMovimientosDeStock : IObtenerTodosPaginado<MovimientoDeStock>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientoDeStock;
        public ObtenerMovimientosDeStock(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            _repositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }
        public IEnumerable<MovimientoDeStock> Ejecutar(int page)
        {
            return _repositorioMovimientoDeStock.GetAll(page);
        }
    }
}
