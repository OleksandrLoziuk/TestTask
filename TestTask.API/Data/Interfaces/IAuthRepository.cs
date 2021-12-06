using System.Threading.Tasks;
using TestTask.API.Models;

namespace TestTask.API.Data.Interfaces
{
    public interface IAuthRepository
    {
       Task<User> Register (User user, string password);
       Task<User> Login (string username, string password);
       Task<bool> UserExists (string usernsme);  
    }
}