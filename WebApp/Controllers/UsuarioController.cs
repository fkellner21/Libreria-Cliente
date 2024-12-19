using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        IAlta<Usuario> _altaUsuario;
        IEditar<Usuario> _editarUsuario;
        IEliminar<Usuario> _eliminarUsuario;
        IObtener<Usuario> _obtenerUsuario;
        IObtenerTodos<Usuario> _obtenerUsuarios;


        IObtener<Administrador> _obtenerAdministrador;
        IEditar<Administrador> _editarAdministrador;
        IObtenerTodos<Administrador> _obtenerAdministradores;

        public UsuarioController(IAlta<Usuario> altaUsuario,
            IEditar<Usuario> editarUsuario,
            IEliminar<Usuario> eliminarUsuario,
            IObtener<Usuario> obtenerUsuario,
            IObtenerTodos<Usuario> obtenerUsuarios,


            IObtener<Administrador> obtenerAdministrador,
            IEditar<Administrador> editarAdministrador,
            IObtenerTodos<Administrador> obtenerAdministradores)
        {
            _altaUsuario = altaUsuario;
            _editarUsuario = editarUsuario;
            _eliminarUsuario = eliminarUsuario;
            _obtenerUsuario = obtenerUsuario;
            _obtenerUsuarios = obtenerUsuarios;


            _obtenerAdministrador = obtenerAdministrador;
            _editarAdministrador = editarAdministrador;
            _obtenerAdministradores = obtenerAdministradores;

        }
        [Admin]
        public IActionResult AdminIndex(string mensaje)
        {
            ViewBag.Mensaje = mensaje;

            return View(_obtenerAdministradores.Ejecutar());
        }
        public IActionResult AdminCreate()
        {
            return View();
        }
        [Admin]
        [HttpPost]
        public IActionResult AdminCreate(Administrador administrador)
        {
            try
            {
                administrador.Validar();
                _altaUsuario.Ejecutar(administrador);
                return RedirectToAction("AdminIndex", new { mensaje = "Admin creado con exito." });
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (RepositorioException ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View(administrador);
        }
        [Admin]
        public IActionResult AdminDelete(int id)
        {
            try
            {
                Administrador admin = _obtenerAdministrador.Ejecutar(id);
                return View(admin);
            }
            catch (DominioExcpetion ex)
            {
                return RedirectToAction("AdminIndex", new { mensaje = ex.Message });
            }
            catch (RepositorioException ex)
            {
                return RedirectToAction("AdminIndex", new { mensaje = ex.Message });
            }
            catch (Exception)
            {
            return RedirectToAction("AdminIndex", new { mensaje = "Hubo un error, contactese con el administrador." } );
            }

        }
        [Admin]
        [HttpPost]
        public IActionResult AdminDelete(Administrador admin)
        {
            try
            {
                _eliminarUsuario.Ejecutar(admin.Id);
                return RedirectToAction("AdminIndex", new {mensaje = "Administrador eliminado con exito."});
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (RepositorioException ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View(admin);
        }
        [AdminAutorizado]
        public IActionResult AdminEdit(int id)
        {
            try
            {
                Administrador admin = _obtenerAdministrador.Ejecutar(id);
                return View(admin);
            }
            catch (DominioExcpetion ex)
            {
                return RedirectToAction("AdminIndex", new { mensaje = ex.Message });
            }
            catch (RepositorioException ex)
            {
                return RedirectToAction("AdminIndex", new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("AdminIndex", new { mensaje = "Hubo un error, contactese con el administrador." });
            }
        }
        [AdminAutorizado]
        [HttpPost]
        public IActionResult AdminEdit(int id, Administrador admin)
        {
            try
            {
                _editarAdministrador.Ejecutar(id, admin);
                return RedirectToAction("AdminIndex", new { mensaje = "Administrador modificado con exito." });
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (RepositorioException ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View(admin);
        }
    }
}
