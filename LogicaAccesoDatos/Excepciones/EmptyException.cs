using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class EmptyException:Exception
    {
        public EmptyException() { }
        public EmptyException(string message):base("No existen datos") { }
    }
}
