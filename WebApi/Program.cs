
using LogicaAccesoDatos.EF;
using LogicaAplicacion.Usuarios;
using LogicaAplicacion.Articulos;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.IntefacesServicios;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.TipoDeMovimientos;
using LogicaAplicacion.MovimientoDeStocks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // En caso que de problemas al consumir el api con las
            // referencias ciclicas
            builder.Services.AddControllers().AddJsonOptions(
                option =>
                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                );

            //Configuración de Swagger
            builder.Services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "LibreriaInterna API",
                    Description = "Ejercicio obligatorio P3 2a entrega 2024",

                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Coloque el token JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            //Configuracion de JWT
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //REPOSITORIOS
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioMovimientoDeStock, RepositorioMovimientoDeStock>();
            builder.Services.AddScoped<IRepositorioTipoDeMovimiento, RepositorioTipoDeMovimiento>();


            //CASOS DE USO
            builder.Services.AddScoped<ILogin<Usuario>, Login>();
            builder.Services.AddScoped<IObtener<Usuario>, ObtenerUsuario>();
            builder.Services.AddScoped<IObtenerDeString<Usuario>, ObtenerDeEmail>();

            builder.Services.AddScoped<IObtener<Articulo>, ObtenerArticulo>();
            builder.Services.AddScoped<IObtenerTodos<Articulo>, ObtenerArticulos>();

            builder.Services.AddScoped<IAlta<TipoDeMovimiento>, AltaTipoDeMovimiento>();
            builder.Services.AddScoped<IEliminar<TipoDeMovimiento>, EliminarTipoDeMovimiento>();
            builder.Services.AddScoped<IEditar<TipoDeMovimiento>, EditarTipoDeMovimiento>();
            builder.Services.AddScoped<IObtener<TipoDeMovimiento>, ObtenerTipoDeMovimiento>();
            builder.Services.AddScoped<IObtenerTodos<TipoDeMovimiento>, ObtenerTiposDeMovimiento>();

            builder.Services.AddScoped<IAlta<MovimientoDeStock>, AltaMovimientoDeStock>();
            builder.Services.AddScoped<IObtener<MovimientoDeStock>, ObtenerMovimientoDeStock>();
            builder.Services.AddScoped<IObtenerTodos<MovimientoDeStock>, ObtenerMovimientosDeStock>();
            builder.Services.AddScoped<IObtenerDosFiltros<MovimientoDeStock>, GetAllXArtTipoPag>();
            builder.Services.AddScoped<IObtenerPorFecha<MovimientoDeStock>, ObtenerMovimientosPorFecha>();

            //toma del Json los parametros generales
            var config = new ConfigurationBuilder()
            .AddJsonFile("parametros.json", optional: true, reloadOnChange: true)
            .Build();
            ParametrosGenerales.cantMaxPorMovimiento = config.GetValue<int>("cantMaxPorMovimiento");

            //CONXION A LA BD

            builder.Services.AddDbContext<LibreriaContext>(
            options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("libreriaInterna")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
