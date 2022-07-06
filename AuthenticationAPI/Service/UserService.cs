using AuthenticationAPI.Data.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthenticationAPI.Service
{
    public class UserService:IUserService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepo repo;

        public UserService(IConfiguration config, IUserRepo repo)
        {
            _config = config;
            this.repo = repo;
        }

        public LoginCredentials AuthenticateUser(LoginCredentials loginCredentials)
        {
            User user = repo.GetUserCredentials(new User() { Username = loginCredentials.Username, Password = loginCredentials.Password });
            if (user != null)
                return loginCredentials;
            else
                return null;
        }

        public string GenerateJSONWebToken(LoginCredentials userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                null,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
