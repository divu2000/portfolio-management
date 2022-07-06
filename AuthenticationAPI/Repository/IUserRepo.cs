using AuthenticationAPI.Data.Entities;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public interface IUserRepo
    {
        public User GetUserCredentials(User user);
    }
}
