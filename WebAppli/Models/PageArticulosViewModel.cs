using LogicaDeNegocio.Entidades;

namespace WebAppli.Models
{
    public class PageArticulosViewModel
    {
        public IEnumerable<Articulo> Items { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
