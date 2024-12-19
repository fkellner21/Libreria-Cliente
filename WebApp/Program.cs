using LogicaAccesoDatos.EF;
using LogicaAplicacion.Administradores;
using LogicaAplicacion.Clientes;
using LogicaAplicacion.Articulos;
using LogicaDeNegocio.Dtos;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Login = LogicaAplicacion.Administradores.Login;
using LogicaAplicacion.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();

            //Casos de uso
            builder.Services.AddScoped<IAlta<Usuario>, AltaUsuario>();
            builder.Services.AddScoped<IEditar<Usuario>, EditarUsuario>();
            builder.Services.AddScoped<IEliminar<Usuario>, EliminarUsuario>();
            builder.Services.AddScoped<IObtener<Usuario>, ObtenerUsuario>();
            builder.Services.AddScoped<IObtenerTodos<Usuario>, ObtenerUsuarios>();
            builder.Services.AddScoped<ILogin<Usuario>, Login>();

            builder.Services.AddScoped<IObtener<Administrador>, ObtenerAdministrador>();
            builder.Services.AddScoped<IEditar<Administrador>, EditarAdministrador>();
            builder.Services.AddScoped<IObtenerTodos<Administrador>, ObtenerAdministradores>();

            builder.Services.AddScoped<IObtenerTodos<ClienteDto>, ObtenerClientes>();
            builder.Services.AddScoped<IObtenerFiltroString<ClienteDto>, ObtenerClientesSegunRazonSocial>();
            builder.Services.AddScoped<IObtenerFiltroInt<ClienteDto>, ObtenerClientesSegunMontoPedido>();
            builder.Services.AddScoped<IObtener<ClienteDto>, ObtenerCliente>();


            builder.Services.AddScoped<IObtenerTodos<Articulo>, ObtenerArticulos>();
            builder.Services.AddScoped<IObtener<Articulo>, ObtenerArticulo>();
            builder.Services.AddScoped<IAlta<Articulo>, AltaArticulo>();
            builder.Services.AddScoped<IEliminar<Articulo>, EliminarArticulo>();
            builder.Services.AddScoped<IEditar<Articulo>, EditarArticulo>();

            builder.Services.AddScoped<IObtenerTodos<PedidoDto>, ObtenerPedidos>();
            builder.Services.AddScoped<IObtener<PedidoDto>, ObtenerPedido>();
            builder.Services.AddScoped<IAlta<PedidoDto>, AltaPedido>();
            builder.Services.AddScoped<IObtenerAanular<PedidoDto>, ObtenerAanular>();
            builder.Services.AddScoped<IAnularPedido, AnularPedido>();

            var config = new ConfigurationBuilder()
            .AddJsonFile("parametros.json", optional: true, reloadOnChange: true)
            .Build();
            ParametrosGenerales.IvaActual = config.GetValue<decimal>("ivaActual");
            ParametrosGenerales.RecargoXDistancia = config.GetValue<decimal>("recargoXDistancia");
            ParametrosGenerales.PlazoMax = config.GetValue<int>("plazoMax");
            ParametrosGenerales.RecargoEnElDia = config.GetValue<decimal>("recargoEnElDia");
            ParametrosGenerales.RecargoComun = config.GetValue<decimal>("recargoComun");


            //Contexto
            //builder.Services.AddDbContext<LibreriaContext>();
            builder.Services.AddDbContext<LibreriaContext>(
            options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("libreria")));

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Index}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
