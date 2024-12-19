using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.IntefacesServicios
{
    public interface ILogin<Usuario>
    {
        public Usuario Ejecutar(string email, string password);
    }
}
