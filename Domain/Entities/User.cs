using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Highscore.Domain.Entities
{
   public class User : IdentityUser
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Alias { get; set; }
   }
}
