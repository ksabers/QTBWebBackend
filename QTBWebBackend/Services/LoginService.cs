using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using QTBWebBackend.Models;
using QTBWebBackend.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace QTBWebBackend.Services
{
    public interface ILoginService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Login> GetAll();
        Login GetById(int id);
    }

    public class LoginService : ILoginService
    {

        private List<Login> _logins;
        private QTBWebDBContext _contesto;

        private readonly AppSettings _appSettings;

        public LoginService(IOptions<AppSettings> appSettings, QTBWebDBContext contesto)
        {
            _appSettings = appSettings.Value;
            _contesto = contesto;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var login = _contesto.Login
                .Where(log => log.Email.Trim().ToLower() == model.Email.Trim().ToLower() && log.Password == model.Password)
                .Select(log => new AuthenticateResponse 
                    { 
                        Id = log.Id,
                        Email = log.Email,
                        Persona = log.Persona,
                        Nome = log.PersonaNavigation.Nome,
                        Cognome = log.PersonaNavigation.Cognome,
                        MinutiPregressi = log.PersonaNavigation.MinutiPregressi,
                        MinutiVoloDaPilota = log.PersonaNavigation.VoliPilotaNavigation.Sum(volo => volo.Durata),
                        Ruolo = log.RuoloNavigation.Descrizione        
                    }
                )
                .FirstOrDefault();

            // return null if user not found
            if (login == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(login.Id);
            login.Token = token;
            return login;
        }

        public IEnumerable<Login> GetAll()
        {
            return _logins;
        }

        public Login GetById(int id)
        {
            return _logins.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(long loginID)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", loginID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}