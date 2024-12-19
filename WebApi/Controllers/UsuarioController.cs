using LogicaAplicacion.Usuarios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IObtener<Usuario> _obtenerUsuario;//todo si no lo uso, lo borro
        private ILogin<Usuario> _login;

        public UsuarioController(IObtener<Usuario> obtener,
                                 ILogin<Usuario> login)
        {
            _obtenerUsuario=obtener;
            _login = login;
        }
        [HttpPost]
        public IActionResult Token(string email, string pass)
        {
            try
            {
                Usuario usuario = _login.Ejecutar(email, pass);
                var token = ManejadorJwt.GenerarToken(usuario);
                return Ok(token);
            }catch (Exception ex)//todo arreglar los catch
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Usuario/Login")]
        public IActionResult Login(string email, string pass)
        {
            try
            {
                Usuario usuario = _login.Ejecutar(email, pass);
                return Ok(usuario);
            }
            catch (Exception ex)//todo arreglar los catch
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
