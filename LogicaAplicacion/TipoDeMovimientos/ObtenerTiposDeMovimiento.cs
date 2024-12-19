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
    public class ObtenerTiposDeMovimiento:IObtenerTodos<TipoDeMovimiento>
    {
        IRepositorioTipoDeMovimiento _repositorioTipoDeMovimiento;
        public ObtenerTiposDeMovimiento(IRepositorioTipoDeMovimiento repositorioTipoDeMovimiento)
        {
            _repositorioTipoDeMovimiento = repositorioTipoDeMovimiento;
        }
        public IEnumerable<TipoDeMovimiento> Ejecutar()
        {
            return _repositorioTipoDeMovimiento.GetAll();
        }
    }
}
