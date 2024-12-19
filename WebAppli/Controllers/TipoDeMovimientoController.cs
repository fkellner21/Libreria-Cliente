using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebAppli.Controllers
{
    //este controlador, no lo pide la letra
    public class TipoDeMovimientoController : Controller
    {
        private IObtenerTodos<TipoDeMovimiento> _obtenerTipos;

        public TipoDeMovimientoController(IObtenerTodos<TipoDeMovimiento> obtenerTipos) 
        {
            _obtenerTipos = obtenerTipos;
        }
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(_obtenerTipos.Ejecutar());
        }
    }
}
