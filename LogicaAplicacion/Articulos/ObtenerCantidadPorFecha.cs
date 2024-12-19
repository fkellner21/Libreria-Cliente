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
    public class ObtenerCantidadPorFecha : ICantidadPorFecha<Articulo>
    {
        IRepositorioMovimientoDeStock _repositorioMovimientos;
        public ObtenerCantidadPorFecha(IRepositorioMovimientoDeStock repositorioMovimientos)
        {
            _repositorioMovimientos = repositorioMovimientos;
        }
        public int Ejecutar(DateTime desde, DateTime hasta)
        {
            return _repositorioMovimientos.GetCantidadPorFecha(desde, hasta);
        }
    }
}
