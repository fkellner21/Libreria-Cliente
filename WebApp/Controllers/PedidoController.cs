using LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Articulos;
using LogicaDeNegocio.Dtos;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Excepciones;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.ComponentModel;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class PedidoController : Controller
    {
        IObtenerTodos<PedidoDto> _obtenerPedidos;
        IObtener<PedidoDto> _obtenerPedido;
        IObtenerTodos<Articulo> _obtenerArticulos;
        IObtener<Articulo> _obtenerArticulo;
        IAlta<PedidoDto> _altaPedido;
        IObtenerTodos<ClienteDto> _obtenerClientes;
        IObtener<ClienteDto> _obtenerCliente;
        IObtenerAanular<PedidoDto> _obtenerPedidosAanular;
        IAnularPedido _anularPedido;
        static List<ArticuloPedido> compras = new List<ArticuloPedido>();
        public PedidoController(IObtenerTodos<PedidoDto> pedidos, 
                                IObtener<PedidoDto> obtenerPedido,
                                IObtenerTodos<Articulo> obtenerArticulos,
                                IObtener<Articulo> obtenerArticulo,
                                IAlta<PedidoDto> altaPedido,
                                IObtenerTodos<ClienteDto> obtenerClientes,
                                IObtener<ClienteDto> obtenerCliente,
                                IObtenerAanular<PedidoDto> obtenerPedidosAanular,
                                IAnularPedido anularPedido)
        {
            _obtenerPedidos = pedidos;
            _obtenerPedido = obtenerPedido;
            _obtenerArticulos = obtenerArticulos;
            _obtenerArticulo = obtenerArticulo;
            _altaPedido = altaPedido;
            _obtenerClientes = obtenerClientes;
            _obtenerCliente = obtenerCliente;
            _obtenerPedidosAanular = obtenerPedidosAanular;
            _anularPedido = anularPedido;
        }
        [Admin]
        public IActionResult Index(string mensaje, string color)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.Color = color;
            return View(_obtenerPedidos.Ejecutar());
        }
        [Admin]
        public IActionResult ElegirArticulos(string mensaje, string color) 
        {
            ViewBag.Mensaje= mensaje;
            ViewBag.Color = color;
            ViewBag.Lista=compras;
            return View(_obtenerArticulos.Ejecutar());
        }
        [Admin]
        public IActionResult Agregar(int id, int cantidad)
        {
            try
            {
                for (int i = 0; i < compras.Count; i++)
                {
                    if (compras[i].Articulo.Id == id)
                    {
                        return RedirectToAction("ElegirArticulos", new { mensaje = "No puede elegir mas de 1 vez el mismo articulo" , color = "alert alert-danger"});
                    }
                }
                Articulo art = _obtenerArticulo.Ejecutar(id);
                ArticuloPedido item = new ArticuloPedido(art,cantidad);
                item.Validar();
                compras.Add(item);
                ViewBag.Mensaje = "Articulo agregado con exito";
                ViewBag.Color = "alert alert-success";
                ViewBag.Lista = compras;
                return View("ElegirArticulos", _obtenerArticulos.Ejecutar());

            }catch(RepositorioException ex)
            {
                return RedirectToAction("ElegirArticulos", new { mensaje = ex.Message, color = "alert alert-danger" });
            }
            catch (DominioExcpetion ex)
            {
                return RedirectToAction("ElegirArticulos", new { mensaje = ex.Message, color = "alert alert-danger" });
            }
            catch (Exception)
            {
                return RedirectToAction("ElegirArticulos", new { mensaje = "Hubo un error, contactese con el administrador", color = "alert alert-danger" });
            }
        }
        [Admin]
        public IActionResult Cancel()
        {
            compras.Clear();
            return RedirectToAction("Index", new {mensaje = "Pedido cancelado", color = "alert alert-danger" });
        }
        [Admin]
        public IActionResult DeleteLinea(int idArt, int cantidad)
        {
            try
            {
                for (int i = 0; i < compras.Count ; i++)
                {
                    ArticuloPedido compra = compras[i];
                    if (compra.Articulo.Id == idArt && compra.Cantidad==cantidad)
                    {
                        compras.Remove(compras[i]);
                        ViewBag.Mensaje = "Se quito el articulo de la lista";
                        ViewBag.Color = "alert alert-succes";
                        i = compras.Count;
                    }
                }
                ViewBag.Lista = compras;
                return View("ElegirArticulos", _obtenerArticulos.Ejecutar());
            }
            catch(Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador.";
            }
            return RedirectToAction("Index", new { mensaje = ViewBag.mensaje, color = "alert alert-danger" });
        }
        [Admin]
        [HttpGet]
        public IActionResult Create(string mensaje, string color)
        {
            if (compras.Count == 0)
            {
                return RedirectToAction("ElegirArticulos", new { mensaje = "No tiene articulos seleccionados", color = "alert alert-danger" });
            }
            ViewBag.mensaje = mensaje;
            ViewBag.color = color;
            ViewBag.clientes=_obtenerClientes.Ejecutar();
            return View();
        }
        [Admin]
        [HttpPost]
        public IActionResult Create(PedidoDto pedidoDto)
        {

            try { 
            PedidoDto nuevoPedidoDto = new PedidoDto(0,pedidoDto.fechaDeEntrega,DateTime.Now,pedidoDto.precio, pedidoDto.recargo,pedidoDto.iva,pedidoDto.idCliente,pedidoDto.nombreCliente,compras,false,pedidoDto.esExpress);
            _altaPedido.Ejecutar(nuevoPedidoDto);
            compras.Clear();
            return RedirectToAction("Index", new { mensaje = "Pedido agregado con exito", color = "alert alert-success" });
            }
            catch (RepositorioException ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message, color = "alert alert-danger" });
            }
            catch (DominioExcpetion ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message, color = "alert alert-danger" });
            }
            catch (Exception)
            {
                return RedirectToAction("Create", new { mensaje = "Hubo un error, contactese con el administrador", color = "alert alert-danger" });
            }
        }

        [Admin]
        public IActionResult PedidosAanular()
        {
            return View();
        }
        [Admin]
        [HttpPost]
        public IActionResult PedidosAanular(DateTime fechaPedido)
        {
            try
            {
            return View(_obtenerPedidosAanular.Ejecutar(fechaPedido));

            }
            catch (RepositorioException ex)
            {
                ViewBag.mensaje = ex.Message;
                ViewBag.color = "alert alert-danger";
                return View();
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.mensaje = ex.Message;
                ViewBag.color = "alert alert-danger";
                return View();
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador";
                ViewBag.color = "alert alert-danger";
                return View();
            }
        }
        [Admin]
        public IActionResult Anular(int id)
        {
            try
            {
            _anularPedido.Ejecutar(id);
            
            ViewBag.mensaje = "Pedido anulado con exito";
            ViewBag.color = "alert alert-success";
            return View("PedidosAanular");
            }
            catch (RepositorioException ex)
            {
                ViewBag.mensaje = ex.Message;
                ViewBag.color = "alert alert-danger";
                return View("PedidosAanular");
            }
            catch (DominioExcpetion ex)
            {
                ViewBag.mensaje = ex.Message;
                ViewBag.color = "alert alert-danger";
                return View("PedidosAanular");
            }
            catch (Exception)
            {
                ViewBag.mensaje = "Hubo un error, contactese con el administrador";
                ViewBag.color = "alert alert-danger";
                return View("PedidosAanular");
            }
        }

    }
}
