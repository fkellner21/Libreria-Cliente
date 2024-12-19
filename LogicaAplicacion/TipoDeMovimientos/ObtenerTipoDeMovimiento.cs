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
    public class ObtenerTipoDeMovimiento : IObtener<TipoDeMovimiento>
    {
		IRepositorioTipoDeMovimiento _repositorioTipoDeMovimiento;
        public ObtenerTipoDeMovimiento(IRepositorioTipoDeMovimiento repositorioTipoDeMovimiento)
        {
			_repositorioTipoDeMovimiento = repositorioTipoDeMovimiento;
        }

        public TipoDeMovimiento Ejecutar(int id)
        {
            return _repositorioTipoDeMovimiento.GetById(id);
        }
    }
}
