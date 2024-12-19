using Azure;
using Infraestructura.LogicaAccesoDatos.RestFull;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RestFull
{
    //este repositorio no lo pide la letra
    public class RepositorioTipoDeMovimiento : IRepositorioTipoDeMovimiento
    {
        private IRestFull _clientRest;

        public RepositorioTipoDeMovimiento(IRestFull clientRest)
        {
            _clientRest = clientRest;
        }
        public void Add(TipoDeMovimiento obj)
        {
            string jsonEntity = JsonSerializer.Serialize(obj);
            const string endPoint = "TipoDeMovimiento";
            string json = _clientRest.Post("", endPoint, jsonEntity);
            //obj = ToolsEntity<TipoDeMovimiento>.ObjetcFromJson(json);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoDeMovimiento> GetAll()
        {
            string resource = "TipoDeMovimiento";
            string json = _clientRest.Get("", resource);
            return ToolsEntity<TipoDeMovimiento>.ListFromJson(json);

        }

        public TipoDeMovimiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TipoDeMovimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
