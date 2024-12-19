using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeMovimientoController : ControllerBase
    {
        private IAlta<TipoDeMovimiento> _altaTipoDeMovimiento;
        private IEliminar<TipoDeMovimiento> _eliminarTipoDeMovimiento;
        private IEditar<TipoDeMovimiento> _editarTipoDeMovimiento;
        private IObtener<TipoDeMovimiento> _obtenerTipoDeMovimiento;
        private IObtenerTodos<TipoDeMovimiento> _obtenerTiposDeMovimiento;
        public TipoDeMovimientoController(
            IAlta<TipoDeMovimiento> altaTipoDeMovimiento,
            IEliminar<TipoDeMovimiento> eliminarTipoDeMovimiento,
            IEditar<TipoDeMovimiento> editarTipoDeMovimiento,
            IObtener<TipoDeMovimiento> obtenerTipoDeMovimiento,
            IObtenerTodos<TipoDeMovimiento> obtenerTiposDeMovimiento
            )
        {
            _altaTipoDeMovimiento = altaTipoDeMovimiento;
            _eliminarTipoDeMovimiento = eliminarTipoDeMovimiento;
            _editarTipoDeMovimiento = editarTipoDeMovimiento;
            _obtenerTipoDeMovimiento = obtenerTipoDeMovimiento;
            _obtenerTiposDeMovimiento = obtenerTiposDeMovimiento;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerTiposDeMovimiento.Ejecutar());

            } catch (NotFoundException e)
            {
                return StatusCode(204, e.Message);
            } catch (Exception)
            {
                return StatusCode(500, "Contacte al administrador");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_obtenerTipoDeMovimiento.Ejecutar(id));
            } catch (ArgumentNullRepositorioException e)
            {
                return StatusCode(400, e.Message);
            } catch (NotFoundException e)
            {
                return StatusCode(404, e.Message);
            } catch (Exception)
            {
                return StatusCode(500, "Contacte al administrador");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult Create(TipoDeMovimiento UnTipo)
        {
            try
            {
                if (UnTipo == null)
                {
                    throw new ArgumentException("Los valores enviados son incorrectos");
                }
                UnTipo.Validar();
                _altaTipoDeMovimiento.Ejecutar(UnTipo);
                return StatusCode(201);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (DominioExcpetion e)
            {
                return StatusCode(400, e.Message);
            }
            catch (RepositorioException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Contactese con el administrador");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _eliminarTipoDeMovimiento.Ejecutar(id);
                return StatusCode(201);
            }
            catch (RepositorioException e)
            {
                return StatusCode(400, e.Message);
            } catch (Exception)
            {
                return StatusCode(500, "Contactese con el administrador");
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, TipoDeMovimiento tipo)
        {
            try
            {
                _editarTipoDeMovimiento.Ejecutar(id, tipo);
                return StatusCode(200);
            }
            catch (DominioExcpetion e)
            {
                return StatusCode(400, e.Message);
            }
            catch (RepositorioException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Contactese con el administrador");
            }
        }
    }
}
