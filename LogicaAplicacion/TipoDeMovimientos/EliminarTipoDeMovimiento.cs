using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.TipoDeMovimientos
{
    public class EliminarTipoDeMovimiento : IEliminar<TipoDeMovimiento>
    {
        IRepositorioTipoDeMovimiento _repositorioTipoDeMovimiento;
        public EliminarTipoDeMovimiento(IRepositorioTipoDeMovimiento repositorioTipoDeMovimiento)
        {
            _repositorioTipoDeMovimiento = repositorioTipoDeMovimiento;
        }

        public void Ejecutar(int id)
        {
            _repositorioTipoDeMovimiento.Delete(id);
        }
    }
}
