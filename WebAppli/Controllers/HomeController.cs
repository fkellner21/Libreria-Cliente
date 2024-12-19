using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.Excepciones.MovimientoDeStock;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebAppli.Filter;
using WebAppli.Models;

namespace WebAppli.Controllers
{
    public class HomeController : Controller
    {
        private IObtenerTodosPaginado<MovimientoDeStock> _obtenerMovimientos;
        private ICantidadTotal<MovimientoDeStock> _cantidadMovimientos;
        private IAlta<MovimientoDeStockDto> _alta;
        private IObtenerDosFiltros<MovimientoDeStock> _dosFiltros;
        private ICantidadDosFiltros<MovimientoDeStock> _cantidadDosFiltros;
        private ICantidadPorFecha<Articulo> _cantidadPorFecha;
        private IObtenerPorFecha<Articulo> _obtenerPorFecha;
        private IObtenerResumen _obtenerResumen;
     //   private IObtenerTodos<TipoDeMovimiento> _obtenerTipos;
        private IObtenerTodos<Articulo> _obtenerArticulos;
        private static IEnumerable<Articulo> articulos;
        private static IEnumerable<TipoDeMovimiento> tipos;

        private int pageSize = 0;
        private int totalItems = 0;
        public HomeController(IObtenerTodosPaginado<MovimientoDeStock> obtenerMovimientos,
                                            ICantidadTotal<MovimientoDeStock> cantidadMovimientos,
                                            IAlta<MovimientoDeStockDto> altaMovimiento,
                                            IObtenerDosFiltros<MovimientoDeStock> dosFiltros,
                                            ICantidadDosFiltros<MovimientoDeStock> cantidadDosFiltros,
                                            ICantidadPorFecha<Articulo> cantidadPorFecha,
                                            IObtenerPorFecha<Articulo> obtenerPorFecha, 
                                            IObtenerResumen obtenerResumen,
                                            IObtenerTodos<TipoDeMovimiento> obtenerTipos)
        {
            pageSize = ParametrosGenerales.pageSize;
            _obtenerMovimientos = obtenerMovimientos;
            _cantidadMovimientos = cantidadMovimientos;
            _alta = altaMovimiento;
            _dosFiltros = dosFiltros;
            _cantidadDosFiltros = cantidadDosFiltros;
            _cantidadPorFecha = cantidadPorFecha;
            _obtenerPorFecha = obtenerPorFecha;
            _obtenerResumen = obtenerResumen;
          //  _obtenerTipos = obtenerTipos;
        }

        [AutEncargado]
        public IActionResult Index(int pageNumber)
        {
            try
            {
                totalItems = _cantidadMovimientos.Ejecutar();
                IEnumerable<MovimientoDeStock> _movimientos = _obtenerMovimientos.Ejecutar(pageNumber);
                PageMovimientosViewModel page = new PageMovimientosViewModel();
                page.Items = _movimientos;
                page.TotalItems = totalItems;
                page.PageNumber = pageNumber;
                page.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                if (totalItems == 0)
                {
                    throw new DominioExcpetion("No hay datos para mostrar");
                }
                return View(page);
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (EmptyException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View();
        }

        [AutEncargado]
        public IActionResult Create()
        {

            string mail = HttpContext.Session.GetString("mail");
            ViewBag.Mail = mail;
            return View();
        }

        [AutEncargado]
        [HttpPost]
        public IActionResult Create(MovimientoDeStockDto unMovimiento)
        {
            try
            {
                if (unMovimiento == null)
                {
                    throw new ArgumentException("Los valores enviados son incorrectos");
                }
                if (unMovimiento.articuloId == null)
                {
                    throw new ArticuloDeMovimientoInvalidoException();
                }
                if (unMovimiento.ejecutorEmail == null)
                {
                    throw new RolUsuarioInvalidoException();
                }
                if (unMovimiento.cantidad == null || unMovimiento.cantidad > ParametrosGenerales.cantMaxPorMovimiento || unMovimiento.cantidad <= 0)
                {
                    throw new CantidadInvalidaException();
                }
                _alta.Ejecutar(unMovimiento);
                TempData["Mensaje"] = "Movimiento ingresado con éxito.";
                return RedirectToAction("Index");
            }
            catch (DominioExcpetion ex)
            {
                string mail = HttpContext.Session.GetString("mail");
                ViewBag.Mail = mail;
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch (EmptyException ex)
            {
                string mail = HttpContext.Session.GetString("mail");
                ViewBag.Mail = mail;
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch (Exception)
            {
                string mail = HttpContext.Session.GetString("mail");
                ViewBag.Mail = mail;
                ViewBag.Mensaje = "Hubo un error, contactese con el administrador.";
                return View();
            }
        }

        [AutEncargado]
        public IActionResult FiltroXArtTipoPag(int idArticulo = 0, int idTipo = 0, int pagina = 0)
        {
            try
            {
                if(idArticulo == 0 && idTipo == 0)
                {
                    throw new ArgumentException("Seleccione los campos de su interes");
                }
                totalItems = _cantidadDosFiltros.Ejecutar(idArticulo, idTipo);
                IEnumerable<MovimientoDeStock> _movimientos = _dosFiltros.Ejecutar(idArticulo, idTipo, pagina);
                PageMovimientosViewModel page = new PageMovimientosViewModel();
                page.Items = _movimientos;
                if (_movimientos.Count() == 0)
                {
                    throw new EmptyException();
                }
                page.TotalItems = totalItems;
                page.PageNumber = pagina;
                page.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                ViewBag.idArt=idArticulo;
                ViewBag.idTipo=idTipo;
                if (totalItems == 0)
                {
                    throw new DominioExcpetion("No hay datos para mostrar");
                }
                return View(page);
            }
            catch(ArgumentException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (EmptyException)
            {
                ViewBag.Mensaje = "No hay datos para mostrar";
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View();
        }

        [AutEncargado]
        public IActionResult FiltroXFecha(string desde, string hasta, int pagina = 0)
        {
            try
            {
                DateTime d = DateTime.Now;
                DateTime h = DateTime.Now;
                if (desde != null)
                {
                    var okd = DateTime.TryParse(desde, out d);
                }
                if (hasta != null)
                {
                    var okd = DateTime.TryParse(hasta, out h);

                }
                totalItems = _cantidadPorFecha.Ejecutar(d, h);
                IEnumerable<Articulo> _articulos = _obtenerPorFecha.Ejecutar(d, h, pagina);
                PageArticulosViewModel page = new PageArticulosViewModel();
                page.Items = _articulos;
                page.TotalItems = totalItems;
                page.PageNumber = pagina;
                page.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                ViewBag.desdestr = d.ToString("yyyy-MM-ddTHH:mm");
                ViewBag.hastastr = h.ToString("yyyy-MM-ddTHH:mm");
                if (totalItems == 0)
                {
                    throw new DominioExcpetion("No hay datos para mostrar");
                }
                return View(page);
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (EmptyException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View();
        }

        [AutEncargado]
        public IActionResult Resumen()
        {
            try
            {
                return View(_obtenerResumen.Ejecutar());
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (EmptyException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Hubo un error, contactese con el administrador.";
            }
            return View();
        }
    }
}