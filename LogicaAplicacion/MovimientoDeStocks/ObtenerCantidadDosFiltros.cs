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
    public class ObtenerCantidadDosFiltros:ICantidadDosFiltros<MovimientoDeStock>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientos;
        public ObtenerCantidadDosFiltros(IRepositorioMovimientoDeStock repositorioMovimientos)
        {
            _repositorioMovimientos = repositorioMovimientos;
        }

        public int Ejecutar(int idArt, int idTipo)
        {
            return _repositorioMovimientos.GetCantidadDosFiltros(idArt, idTipo);
        }
    }
}
