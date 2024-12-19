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
    public class ObtenerArticulos : IObtenerTodos<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;
        public ObtenerArticulos(IRepositorioArticulo repositorioArticulos)
        {
            _repositorioArticulo = repositorioArticulos;
        }
        public IEnumerable<Articulo> Ejecutar()
        {
            return _repositorioArticulo.GetAll();
        }
    }
}
