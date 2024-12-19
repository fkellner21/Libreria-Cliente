using Infraestructura.LogicaAccesoDatos.RestFull;
using LogicaAccesoDatos.RestFull;
using LogicaAplicacion.Articulos;
using LogicaAplicacion.MovimientoDeStocks;
using LogicaAplicacion.TipoDeMovimientos;
using LogicaAplicacion.Usuarios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using System.Drawing.Printing;

namespace WebAppli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // servicio para guardar el token y solicitarlo donde lo necesite usar
            // 
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<ITokenService, TokenService>();

            builder.Services.AddSession();

            // para usar la api, debo indicar el servidor 
            // para arma el endPoint el recurso esta en cada
            // repositorio
            builder.Services.AddScoped<IRestFull>(provider => new RestContext(builder.Configuration.GetConnectionString("apiUrl")));


            //Repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioTipoDeMovimiento, RepositorioTipoDeMovimiento>();
            builder.Services.AddScoped<IRepositorioMovimientoDeStock, RepositorioMovimientoDeStock>();

            //Casos de uso
            builder.Services.AddScoped<IObtenerToken, ObtenerToken>();
            builder.Services.AddScoped<ILogin<Usuario>, Login>();

            builder.Services.AddScoped<IObtenerTodos<TipoDeMovimiento>, ObtenerTiposDeMovimiento>();

            builder.Services.AddScoped<IObtenerTodosPaginado<MovimientoDeStock>, ObtenerMovimientosDeStock>();
            builder.Services.AddScoped<ICantidadTotal<MovimientoDeStock>, ObtenerCantidadTotal>();
            builder.Services.AddScoped<IAlta<MovimientoDeStockDto>, AltaMovimientoDeStock>();
            builder.Services.AddScoped<ICantidadDosFiltros<MovimientoDeStock>, ObtenerCantidadDosFiltros>();
            builder.Services.AddScoped<IObtenerDosFiltros<MovimientoDeStock>, GetAllXArtTipoPag>();
            builder.Services.AddScoped<ICantidadPorFecha<Articulo>, ObtenerCantidadPorFecha>();
            builder.Services.AddScoped<IObtenerPorFecha<MovimientoDeStock>, ObtenerMovimientosPorFecha>();
            builder.Services.AddScoped<IObtenerPorFecha<Articulo>, ObtenerArticulosPorFecha>();
            builder.Services.AddScoped<IObtenerResumen, ObtenerResumen>();


            //toma del Json los parametros generales
            var config = new ConfigurationBuilder()
            .AddJsonFile("parametros.json", optional: true, reloadOnChange: true)
            .Build();
            ParametrosGenerales.cantMaxPorMovimiento = config.GetValue<int>("cantMaxPorMovimiento");
            ParametrosGenerales.pageSize = config.GetValue<int>("pageSize");


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Index}");

            app.Run();
        }
    }
}
