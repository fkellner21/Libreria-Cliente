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
    public class AltaTipoDeMovimiento : IAlta<TipoDeMovimiento>
    {
        IRepositorioTipoDeMovimiento _repositorioTiposDeMovimiento;
        public AltaTipoDeMovimiento(IRepositorioTipoDeMovimiento repositorioTiposDeMovimiento)
        {
            _repositorioTiposDeMovimiento = repositorioTiposDeMovimiento;
        }

        public void Ejecutar(TipoDeMovimiento tipoDeMovimiento)
        {
            _repositorioTiposDeMovimiento.Add(tipoDeMovimiento);
        }
    }
}
