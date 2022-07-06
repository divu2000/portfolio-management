using AuthenticationAPI.Models;

namespace AuthenticationAPI.Service
{
    public interface IUserService
    {
        public LoginCredentials AuthenticateUser(LoginCredentials loginCredentials);
        public string GenerateJSONWebToken(LoginCredentials userInfo);
    }
}
