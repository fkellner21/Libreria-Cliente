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
    public class GetAllXArtTipoPag:IObtenerDosFiltros<MovimientoDeStock>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientoDeStock;
        public GetAllXArtTipoPag(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            _repositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }

        public IEnumerable<MovimientoDeStock> Ejecutar(int idArticulo, int idTipo, int page)
        {
            return _repositorioMovimientoDeStock.GetAllXArtTipoPagl(idArticulo,idTipo,page);
        }
    }
}
