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
    public class EditarTipoDeMovimiento : IEditar<TipoDeMovimiento>
    {
        IRepositorioTipoDeMovimiento _repositorioTipoDeMovimiento;
        public EditarTipoDeMovimiento(IRepositorioTipoDeMovimiento repositorioTipoDeMovimiento)
        {
            _repositorioTipoDeMovimiento = repositorioTipoDeMovimiento;
        }

        public void Ejecutar(int id, TipoDeMovimiento obj)
        {
            _repositorioTipoDeMovimiento.Update(id, obj);
        }
    }
}
