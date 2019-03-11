using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Highscore.Domain.Entities;
using Highscore.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Highscore.Domain.Services
{
   public class UserService : IUserService
   {
      private readonly UserManager<User> _userManager;

      public UserService(UserManager<User> userManager)
      {
         _userManager = userManager;
      }

      public async Task<User> GetUserById(string id)
      {
         return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
      }
   }
}
