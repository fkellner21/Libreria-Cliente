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
    public class AltaMovimientoDeStock : IAlta<MovimientoDeStockDto>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientoDeStock;
        public AltaMovimientoDeStock(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            _repositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }

        public void Ejecutar(MovimientoDeStockDto movimientoDeStock)
        {
            _repositorioMovimientoDeStock.Add(movimientoDeStock);
        }
    }
}
