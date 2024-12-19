using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Dtos;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        IObtenerTodos<ClienteDto> _obtenerClientesDto;
        IObtenerFiltroString<ClienteDto> _obtenerClientesXRazonSocial;
        IObtenerFiltroInt<ClienteDto> _obtenerClientesXMonto;

        public ClienteController(IObtenerTodos<ClienteDto> obtenerTodos,
            IObtenerFiltroString<ClienteDto> obtenerClientesXRazonSocial,
            IObtenerFiltroInt<ClienteDto> obtenerClientesXMonto)
        {
            _obtenerClientesDto = obtenerTodos;
            _obtenerClientesXRazonSocial = obtenerClientesXRazonSocial;
            _obtenerClientesXMonto = obtenerClientesXMonto;
        }
        [Admin]
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje= mensaje;
            return View(_obtenerClientesDto.Ejecutar());
        }

        [Admin]
        public IActionResult FiltroXRazonSocial(string filtro)
        {
            try
            {
            if (filtro != null)
            {
               ViewBag.filtroRazonSocial= filtro;
               return View("Index", _obtenerClientesXRazonSocial.Ejecutar(filtro));
            }
            return RedirectToAction("Index");

            }
            catch (RepositorioException ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "Hubo un error, contacte al administrador." });
            }
        }
        [Admin] 
        public IActionResult FiltroXMonto(int filtro)
        {
            try
            {
                if (filtro >= 0)
                {
                    ViewBag.filtroXMonto = filtro;
                }
                return View("Index", _obtenerClientesXMonto.Ejecutar(filtro));

            }
            catch (RepositorioException ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "Hubo un error, contacte al administrador." });
            }
        }
    }
}
