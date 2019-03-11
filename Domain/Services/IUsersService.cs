using System.Collections.Generic;
using System.Threading.Tasks;
using Highscore.Domain.Entities;

namespace Highscore.Domain.Services
{
   public interface IUserService
   {
      Task<User> GetUserById(string id);
   }
}
