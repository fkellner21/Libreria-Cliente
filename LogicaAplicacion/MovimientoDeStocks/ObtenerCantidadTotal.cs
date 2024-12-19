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
    public class ObtenerCantidadTotal : ICantidadTotal<MovimientoDeStock>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientos;
        public ObtenerCantidadTotal(IRepositorioMovimientoDeStock repositorioMovimientos)
        {
            _repositorioMovimientos = repositorioMovimientos;
        }

        public int Ejecutar()
        {
            return _repositorioMovimientos.GetCantidadTotal();
        }
    }
}
