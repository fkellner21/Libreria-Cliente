using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.Excepciones.MovimientoDeStock;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoDeStockController : ControllerBase
    {
        private IAlta<MovimientoDeStock> _altaMovimiento;
        private IObtener<MovimientoDeStock> _obtenerMovimiento;
        private IObtenerTodos<MovimientoDeStock> _obtenerTodos;
        private IObtenerDosFiltros<MovimientoDeStock> _getAllXArtTipoPag;
        private IObtener<Articulo> _obtenerArticulo;
        private IObtener<TipoDeMovimiento> _obtenerTipo;
        private IObtener<Usuario> _obtenerUsuario;
        private IObtenerDeString<Usuario> _obtenerUsuarioDesdeEmail;
        private IObtenerPorFecha<MovimientoDeStock> _obtenerMovimientosPorFecha;

        public MovimientoDeStockController(IAlta<MovimientoDeStock> alta,
                                  IObtener<MovimientoDeStock> obtenerMovimiento,
                                  IObtenerTodos<MovimientoDeStock> obtenerTodos,
                                  IObtenerDosFiltros<MovimientoDeStock> getAllXArtTipoPag,
                                  IObtener<Articulo> obtenerArticulo,
                                  IObtener<TipoDeMovimiento> obtenerTipo,
                                  IObtener<Usuario> obtenerUsuario,
                                  IObtenerDeString<Usuario> obtenerUsuarioDesdeEmail,
                                  IObtenerPorFecha<MovimientoDeStock> obtenerMovimientosPorFecha)
        {
            _altaMovimiento = alta;
            _obtenerMovimiento = obtenerMovimiento;
            _obtenerTodos = obtenerTodos;
            _getAllXArtTipoPag = getAllXArtTipoPag;
            _obtenerArticulo = obtenerArticulo;
            _obtenerTipo = obtenerTipo;
            _obtenerUsuario = obtenerUsuario;
            _obtenerUsuarioDesdeEmail = obtenerUsuarioDesdeEmail;
            _obtenerMovimientosPorFecha = obtenerMovimientosPorFecha;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerTodos.Ejecutar());

            }
            catch (NotFoundException e)
            {
                return StatusCode(204, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Contacte al administrador");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_obtenerMovimiento.Ejecutar(id));
            }
            catch (ArgumentNullRepositorioException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Contacte al administrador");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
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
                if (unMovimiento.cantidad == null||unMovimiento.cantidad>ParametrosGenerales.cantMaxPorMovimiento||unMovimiento.cantidad<=0)
                {
                    throw new CantidadInvalidaException();
                }
                MovimientoDeStock movimiento = new MovimientoDeStock()
                {
                    articulo = _obtenerArticulo.Ejecutar(unMovimiento.articuloId),
                    tipo = _obtenerTipo.Ejecutar(unMovimiento.tipoId),
                    cantidad = unMovimiento.cantidad,
                    ejecutor = _obtenerUsuarioDesdeEmail.Ejecutar(unMovimiento.ejecutorEmail),
                };
                if(movimiento.ejecutor.Discriminator != "Encargado")
                {
                    throw new RolUsuarioInvalidoException();
                }
                movimiento.Validar();
                _altaMovimiento.Ejecutar(movimiento);
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpGet]
        [Route("api/MovimientoDeStock/FiltroXArtTipoPag")]
        public IActionResult FiltroXArtTipoPag(int idArticulo, int idTipo, int page)
        {
            try
            {
                return Ok(_getAllXArtTipoPag.Ejecutar(idArticulo, idTipo, page));
            }
            catch (NotFoundException e)
            {
                return StatusCode(204, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Contacte al administrador");
            }
        }
    }
}
