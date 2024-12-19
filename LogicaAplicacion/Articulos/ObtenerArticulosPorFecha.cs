using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticulosPorFecha:IObtenerPorFecha<Articulo>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientos;
        public ObtenerArticulosPorFecha(IRepositorioMovimientoDeStock repositorioMovimientos)
        {
            _repositorioMovimientos = repositorioMovimientos;
        }
        public IEnumerable<Articulo> Ejecutar(DateTime desde, DateTime hasta, int page)
        {
            return _repositorioMovimientos.GetPorFecha(desde, hasta, page);
        }
    }
}
