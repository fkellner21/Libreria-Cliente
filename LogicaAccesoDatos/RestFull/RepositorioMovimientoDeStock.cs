using Azure;
using Infraestructura.LogicaAccesoDatos.RestFull;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RestFull
{
    public class RepositorioMovimientoDeStock : IRepositorioMovimientoDeStock

    {
        private IRestFull _clientRest;
        private string token;

        public RepositorioMovimientoDeStock(IRestFull clientRest, ITokenService tokenService)
        {
            _clientRest = clientRest;
            token = tokenService.GetToken();
        }
        public void Add(MovimientoDeStockDto obj)
        {
            string jsonEntity = JsonSerializer.Serialize(obj);
            const string endPoint = "MovimientoDeStock";
            string json = _clientRest.Post(token, endPoint, jsonEntity);
            //obj = ToolsEntity<MovimientoDeStockDto>.ObjetcFromJson(json);
        }

        public IEnumerable<MovimientoDeStock> GetAll(int page=0)
        {
            string resource = $"MovimientoDeStock?page={page}";
            string json = _clientRest.Get(token, resource);
            return ToolsEntity<MovimientoDeStock>.ListFromJson(json);
        }

        public IEnumerable<MovimientoDeStock> GetAllXArtTipoPagl(int idArticulo, int idTipo, int page)
        {
            string resource = $"MovimientoDeStock/FiltroXArtTipoPag?idArticulo={idArticulo}&idTipo={idTipo}&page={page}";
            string json = _clientRest.Get(token, resource);
            return ToolsEntity<MovimientoDeStock>.ListFromJson(json);
        }

        public MovimientoDeStock GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCantidadDosFiltros(int idArt, int idTipo)
        {
            string resource = $"MovimientoDeStock/GetCountDosFiltros?idArticulo={idArt}&&idTipo={idTipo}";
            string json = _clientRest.Get(token, resource);
            double cantPaginas;
            double.TryParse(json, out cantPaginas);
            return (int)cantPaginas;
        }

        public int GetCantidadTotal()
        {
            string resource = "MovimientoDeStock/GetCount";
            string json = _clientRest.Get(token, resource);
            double cantPaginas;
            double.TryParse(json, out cantPaginas);
            return (int)cantPaginas;
        }
        public int GetCantidadPorFecha(DateTime desde, DateTime hasta)
        {
            string resource = $"MovimientoDeStock/GetCountPorFecha?desdestr={desde.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)}&hastastr={hasta.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)}";
            string json = _clientRest.Get(token, resource);
            double cantPaginas;
            double.TryParse(json, out cantPaginas);
            return (int)cantPaginas;
        }

        public IEnumerable<MovimientoDeStock> GetMovPorFecha(DateTime desde, DateTime hasta, int page)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articulo> GetPorFecha(DateTime desde, DateTime hasta, int page)
        {
            string resource = $"MovimientoDeStock/FiltroXFecha?desdestr={desde.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)}&hastastr={hasta.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)}&page={page}";
            string json = _clientRest.Get(token, resource);
            return ToolsEntity<Articulo>.ListFromJson(json);
        }

        public IEnumerable<Resultado> GetResumen()
        {
            string resource = "MovimientoDeStock/GetResumen";
            string json = _clientRest.Get(token, resource);
            return ToolsEntity<Resultado>.ListFromJson(json);
        }
    }
}
