using LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Administradores;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class IndexController : Controller
    {

        ILogin<Usuario> _login;
        //IAlta<Usuario> _altaUsuario; //1er ejecucion necesario debido al hash

        public IndexController(ILogin<Usuario> login
                               //, IAlta<Usuario> altaUsuario //1er ejecucion hasta obtener Hash e incorporarlo en la migracion
                               )
        {
            _login = login;
            // _altaUsuario = altaUsuario;//1er ejecucion
            // _altaUsuario.Ejecutar(new Administrador(true, "fran@mail.com", "Asd123!", "fran", "kell")); //1er ejecucion

        }
        [Admin]
        public IActionResult Index()
        {
            return View();
        }
        [Admin]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {

            try
            {
                Usuario unU = _login.Ejecutar(Email, Password);

                if (unU is Administrador)
                {
                    HttpContext.Session.SetString("rol", "Admin");
                    Administrador administrador = unU as Administrador;
                    if (administrador.ModificaUsuario)
                    {
                        HttpContext.Session.SetString("super", "True");
                    }

                    HttpContext.Session.SetString("Nombre", unU.Nombre);

                    return Redirect("/Index/Index");
                }
            }
            catch (LoginException e)
            {
                ViewBag.mensaje = e.Message;
                
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un inconveniente, contactese con el administrador.";
            }
            
            return View("Login");
        }
        
    }
}
