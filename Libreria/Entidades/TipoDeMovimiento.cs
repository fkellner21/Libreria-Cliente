using LogicaDeNegocio.Excepciones.TipoDeMovimiento;
using LogicaDeNegocio.InterfacesDominio;


namespace LogicaDeNegocio.Entidades
{
    public class TipoDeMovimiento:IValidable,IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set;}
        public bool aumentaStock { get; set; }

        public TipoDeMovimiento() { }
        public TipoDeMovimiento(int id, string nombre, bool aumentaStock)
        {
            Id = id;
            Nombre = nombre;
            this.aumentaStock = aumentaStock;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new TipoDeMovimientoInvalidoException();
            }
        }

        public void Update(TipoDeMovimiento obj)
        {
            obj.Validar();
            Nombre = obj.Nombre;
            aumentaStock = obj.aumentaStock;
        }
    }
}
