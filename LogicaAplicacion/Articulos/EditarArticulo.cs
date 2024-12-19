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
    public class EditarArticulos : IEditar<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;
        public EditarArticulos(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(int id, Articulo obj)
        {
            _repositorioArticulo.Update(id, obj);
        }
    }
}
