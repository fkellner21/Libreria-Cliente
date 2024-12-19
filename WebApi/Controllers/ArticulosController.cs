using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        IObtenerTodos<Articulo> _obtenerTodos;

        public ArticulosController(IObtenerTodos<Articulo> obtenerTodos)
        {
            _obtenerTodos = obtenerTodos;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerTodos.Ejecutar());
            }
            catch (RepositorioException)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }
        }
    }
}
