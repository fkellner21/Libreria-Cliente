using System.Text.Json;
using LogicaNegocio.Dtos.Dto;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaAccesoDatos.RestFull;

namespace Infraestructura.LogicaAccesoDatos.RestFull
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private IRestFull _clientRest;


        public RepositorioUsuario(IRestFull clientRest)
        {
            _clientRest = clientRest;

        }

        public void Add(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Administrador GetAdminById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Administrador> GetAllAdministrador()
        {
            throw new NotImplementedException();
        }

        public Usuario GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            var user = new UserDto()
            {
                Email = email,
                Pass = password,
            };

            string jsonEntity = JsonSerializer.Serialize(user);
            const string endPoint = "Usuario/Login"; 
            string json = _clientRest.Post("", endPoint, jsonEntity);
            Usuario u = ToolsEntity<Usuario>.ObjetcFromJson(json);
            return u;
        }

        public string Token(Usuario usuario)
        {
            var user = new UserDto()
            {
                Email = usuario.Email,
                Pass = usuario.PasswordHash,
            };

            string jsonEntity = JsonSerializer.Serialize(user);
            const string endPoint = "Usuario";
            string json = _clientRest.Post("", endPoint, jsonEntity);
            string token = ToolsEntity<string>.ObjetcFromJson(json);
            return token;
        }

        public void Update(int id, Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdmin(int id, Administrador administrador)
        {
            throw new NotImplementedException();
        }
    }
}
