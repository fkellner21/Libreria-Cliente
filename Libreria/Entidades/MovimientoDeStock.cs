using LogicaDeNegocio.Excepciones.MovimientoDeStock;
using LogicaDeNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class MovimientoDeStock : IValidable, IEntity
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public Articulo articulo { get; set; }
        public TipoDeMovimiento tipo { get; set; }
        public Usuario ejecutor { get; set; }
        public int cantidad { get; set; }


        public MovimientoDeStock() 
        {
        fecha= DateTime.Now;
        }
        public MovimientoDeStock(int id, Articulo articulo, TipoDeMovimiento tipo, Usuario ejecutor, int cantidad)
        {
            Id = id;
            fecha = DateTime.Now;
            this.articulo = articulo;
            this.tipo = tipo;
            this.ejecutor = ejecutor;
            this.cantidad = cantidad;
        }
        public void Validar()
        {
            if (fecha == null || articulo == null || tipo == null || ejecutor == null || cantidad <= 0)
            {
                throw new MovimientoDeStockInvalidoException();
            }
            if (cantidad > ParametrosGenerales.cantMaxPorMovimiento)
            {
                throw new CantidadInvalidaException();
            }
        }
    }
}
