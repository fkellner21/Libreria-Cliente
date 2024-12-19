using LogicaDeNegocio.Excepciones.Usuario;
using LogicaDeNegocio.InterfacesDominio;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Usuario: IValidable, IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Discriminator { get; set; }
        public Usuario() { }
        public Usuario(string email, string password, string nombre, string apellido)
        {
            Email = email;
            Password = password;
            Nombre = nombre;
            Apellido = apellido;
        }
        public virtual void Validar()
        {
            ValidarEmail();
            ValidarNombre();
            ValidarApellido();
            ValidarPassword();
        }
        public void ValidarEmail()
        {
            if (!EsCorreoElectronicoValido(Email))
            {
                throw new EmailInvalidoException();
            }
        }
        static bool EsCorreoElectronicoValido(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            // Explicación del patrón:
            // ^: inicio de la cadena
            // [a-zA-Z0-9._%+-]+: nombre de usuario; al menos un carácter alfanumérico, punto, guión bajo, porcentaje o signo más o menos
            // @: símbolo de arroba
            // [a-zA-Z0-9.-]+: nombre de dominio; al menos un carácter alfanumérico, punto o guion
            // \.: un punto literal
            // [a-zA-Z]{2,}: extensión de dominio; al menos dos caracteres alfabéticos
            // $: final de la cadena

            return Regex.IsMatch(correo, patron);
        }

        public void ValidarNombre()
        {
            if(!EsNombreApellidoValido(Nombre))
            {
                throw new NombreInvalidoException();
            }
        }
        static bool EsNombreApellidoValido(string texto)
        {
            string patron = @"^[a-zA-Z]+(?:[' -][a-zA-Z]+)*$";
            // Explicación del patrón:
            // ^[a-zA-Z]+: Comienza con uno o más caracteres alfabéticos.
            // (?:[' -][a-zA-Z]+)*: Seguido por cero o más grupos que contienen un apóstrofe,
            // espacio o guión del medio, seguido de uno o más caracteres alfabéticos.
            // $: Termina con la cadena.

            return Regex.IsMatch(texto, patron);
        }
        public void ValidarApellido()
        {
            if (!EsNombreApellidoValido(Apellido))
            {
                throw new ApellidoInvalidoException();
            }
        }
        public void ValidarPassword()
        {
            if (!EsPasswordValida(Password))
            {
                throw new PasswordInvalidoException();
            }
        }
        static bool EsPasswordValida(string pass)
        {
            string patron = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;!?])[A-Za-z\d.,;!?@_.\-]{6,}$";
            // Explicación del patrón:
            // ^: inicio de la cadena
            // (?=.*[A-Z]): al menos una letra mayúscula
            // (?=.*[a-z]): al menos una letra minúscula
            // (?=.*\d): al menos un dígito
            // (?=.*[.,;!?]): al menos un carácter de puntuación (punto, punto y coma, coma o signo de admiración de cierre)
            // [A-Za-z\d.,;!?@_.\-]{6,}: caracteres alfabéticos, dígitos y caracteres de puntuación, con un largo mínimo de 6
            // $: final de la cadena

            return Regex.IsMatch(pass, patron);
        }
        public virtual void Update(Usuario obj)
        {
            obj.Validar();
            Password = obj.Password;
            PasswordHash = obj.PasswordHash;
            Nombre = obj.Nombre;
            Apellido = obj.Apellido;
        }
    }
}
