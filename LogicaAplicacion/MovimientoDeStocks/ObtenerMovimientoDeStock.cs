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
    public class ObtenerMovimientoDeStock : IObtener<MovimientoDeStock>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientoDeStock;
        public ObtenerMovimientoDeStock(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            _repositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }

        public MovimientoDeStock Ejecutar(int id)
        {
            return _repositorioMovimientoDeStock.GetById(id);
        }
    }
}
