namespace WebApp.Models
{
    public class VMAdministrador
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool ModificaUsuario { get; set; }

    }
}
