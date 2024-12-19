using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorioMovimientoDeStock
        //No hereda de IRepositorio porque implementa menos funcionalidades
        //La otra opcion, era que la implemente pero en el repositorio dejarla con la exception de no implementada
    {
        public void Add(MovimientoDeStockDto obj);
        public MovimientoDeStock GetById(int id);
        public IEnumerable<MovimientoDeStock> GetAll(int page);
        public IEnumerable<MovimientoDeStock> GetAllXArtTipoPagl(int idArticulo, int idTipo, int page);
        public IEnumerable<Articulo> GetPorFecha(DateTime desde, DateTime hasta, int page);
        public int GetCantidadTotal();
        public int GetCantidadDosFiltros(int idArt, int idTipo);
        public int GetCantidadPorFecha(DateTime desde, DateTime hasta);
        public IEnumerable<MovimientoDeStock> GetMovPorFecha(DateTime desde, DateTime hasta, int page);
        public IEnumerable<Resultado> GetResumen();

    }
}
