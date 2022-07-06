using System.Linq;
using AuthenticationAPI.Data;
using AuthenticationAPI.Data.Entities;

namespace AuthenticationAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AuthenticationAPIContext context;

        public UserRepo(AuthenticationAPIContext context)
        {
            this.context = context;
        }
        public User GetUserCredentials(User user)
        {
            return context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
        }
    }
}
