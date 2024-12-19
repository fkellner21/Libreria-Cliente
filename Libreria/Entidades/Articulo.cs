using LogicaDeNegocio.Excepciones.Articulo;
using LogicaDeNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Articulo: IValidable, IEntity
    {
        public int Id {  get; set; }
        public string Nombre {  get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public Articulo() {}
        public Articulo(string nombre, string descripcion, string codigo, decimal precioDeVenta)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Codigo = codigo;
            PrecioDeVenta = precioDeVenta;

        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarCodigo();
            ValidarPrecioDeVenta();
        }
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre) )
            {
                throw new NombreNoVacioException();
            }
        }
        public void ValidarDescripcion()
        {
            if(Descripcion.Length < 5)
            {
                throw new DescripcionInvalidoException();
            }
        }
        public void ValidarCodigo()
        {
            if(!EsNumeroDe13Digitos(Codigo))
            {
                throw new CodigoInvalidoException();
            }
        }
        public void ValidarPrecioDeVenta()
        {
            if (PrecioDeVenta==null||PrecioDeVenta < 0)
            {
                throw new PrecioDeVentaInvalidoException();
            }
        }

        static bool EsNumeroDe13Digitos(string numero)
        {
            string patron = @"^\d{13}$";
            // Explicación del patrón:
            // ^: inicio de la cadena
            // \d{12}: exactamente 12 numeros
            // $: final de la cadena

            return Regex.IsMatch(numero, patron);
        }
        public void Update(Articulo obj)
        {
            obj.Validar();
            Nombre=obj.Nombre;
            Descripcion=obj.Descripcion;
            Codigo=obj.Codigo;
            PrecioDeVenta=obj.PrecioDeVenta;
        }
    }
}
