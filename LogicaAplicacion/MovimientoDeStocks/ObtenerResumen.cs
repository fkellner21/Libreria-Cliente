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
    public class ObtenerResumen:IObtenerResumen
    {
        IRepositorioMovimientoDeStock _repositorioMovimientoDeStock;
        public ObtenerResumen(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            _repositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }

        public IEnumerable<Resultado> Ejecutar()
        {
            return _repositorioMovimientoDeStock.GetResumen();
        }
    }
}
