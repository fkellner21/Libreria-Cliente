using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebAppli.Controllers
{
    public class UsuarioController : Controller
    {
        private IObtenerToken _obtenerToken;
        private ILogin<Usuario> _login;

        public UsuarioController(IObtenerToken obtenerToken, ILogin<Usuario> login)
        {
            _login = login;
            _obtenerToken = obtenerToken;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bienvenida()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            try
            {
               Usuario usu = _login.Ejecutar(email, password);
               HttpContext.Session.SetString("rol", usu.Discriminator);
               HttpContext.Session.SetString("mail", usu.Email);
               var token = _obtenerToken.Ejecutar(usu);
               HttpContext.Session.SetString("token", token);
            }
            catch (Exception ex) {
                ViewBag.Mensaje=ex.Message;
                return View("Index");
            }

            return RedirectToAction("Bienvenida", "Usuario");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
