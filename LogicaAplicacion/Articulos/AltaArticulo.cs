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
    public class AltaArticulo : IAlta<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;
        public AltaArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(Articulo articulo)
        {
            _repositorioArticulo.Add(articulo);
        }
    }
}
