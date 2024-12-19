using LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Administradores;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.Excepciones.Articulo;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class ArticuloController : Controller
    {
        IObtenerTodos<Articulo> _obtenerTodos;
        IObtener<Articulo> _obtenerArticulo;
        IAlta<Articulo> _altaArticulo;
        IEliminar<Articulo> _eliminarArticulo;
        IEditar<Articulo> _editarArticulo;
        public ArticuloController(IObtenerTodos<Articulo> obtenerTodos,
                                    IObtener<Articulo> obtenerArticulo,
                                    IAlta<Articulo> altaArticulo,
                                    IEliminar<Articulo> eliminarArticulo,
                                    IEditar<Articulo> editarArticulo)
        {
            _obtenerTodos = obtenerTodos;
            _obtenerArticulo = obtenerArticulo;
            _altaArticulo = altaArticulo;
            _eliminarArticulo = eliminarArticulo;
            _editarArticulo = editarArticulo;
        }

        [Admin]
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(_obtenerTodos.Ejecutar());
        }
        [Admin]
        public IActionResult Create()
        {
            return View();
        }
        [Admin]
        [HttpPost]
        public IActionResult Create(Articulo UnArticulo)
        {
            try
            {
                if(UnArticulo == null)
                {
                    throw new ArgumentException("Los valores enviados son incorrectos");
                }
                UnArticulo.Validar();
                _altaArticulo.Ejecutar(UnArticulo);
                return RedirectToAction("Index", new {mensaje = "Se dio de alta el articulo"});
            }
            catch (DominioExcpetion e)
            {
                ViewBag.mensaje = e.Message;
            }
            catch (RepositorioException e)
            {
                ViewBag.mensaje = e.Message;
            }
            catch (Exception )
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View("Create");
        }
        [Admin]
        public IActionResult Delete(int id)
        {
            try
            {
                _eliminarArticulo.Ejecutar(id);
                ViewBag.mensaje = "Eliminado con exito.";
            }
            catch
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return RedirectToAction("Index", new { mensaje = ViewBag.mensaje } );
        }
        [Admin]
        public IActionResult Edit(int id)
        {
            try
            {
                Articulo art = _obtenerArticulo.Ejecutar(id);
                return View(art);
            }
            catch (DominioExcpetion ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            catch (RepositorioException ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "Hubo un error, contactese con el administrador." });
            }
        }
        [Admin]
        [HttpPost]
        public IActionResult Edit(int id, Articulo art)
        {
            try
            {
                _editarArticulo.Ejecutar(id, art);
                return RedirectToAction("Index", new { mensaje = "Articulo modificado con exito." });
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
            return View(art);
        }
    }
}
