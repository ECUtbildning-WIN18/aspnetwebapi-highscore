using System.Collections.Generic;
using Highscore.Domain.Entities;

namespace Highscore.Models
{
   public class HomeViewModel
   {
      public IEnumerable<Score> Highscores { get; set; }
   }
}
