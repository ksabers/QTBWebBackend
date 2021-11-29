
using System.Linq;

namespace QTBWebBackend.Models
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public long Persona { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Ruolo { get; set; }
        public string? Token { get; set; }


        //public AuthenticateResponse(Login login, string token)
        //{
        //    Id = login.Id;
        //    Email = login.Email;
        //    Persona = login.Persona;
        //    Ruolo = login.RuoloNavigation.Descrizione;
        //    Token = token;
        //}
    }
}
