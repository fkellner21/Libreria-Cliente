using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Excepciones
{
    public class DominioExcpetion : Exception
    {
        public DominioExcpetion() { }
        public DominioExcpetion(string message) : base(message) { }
    }
}
