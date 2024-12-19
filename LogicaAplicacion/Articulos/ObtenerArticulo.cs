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
    public class ObtenerArticulo : IObtener<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;
        public ObtenerArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public Articulo Ejecutar(int id)
        {
            return _repositorioArticulo.GetById(id);
        }
    }
}
