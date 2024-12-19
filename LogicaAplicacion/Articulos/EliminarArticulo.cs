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
    public class EliminarArticulo : IEliminar<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;
        public EliminarArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(int id)
        {
            _repositorioArticulo.Delete(id);
        }
    }
}
