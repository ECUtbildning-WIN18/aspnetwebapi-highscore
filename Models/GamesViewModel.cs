using System;
using System.Collections.Generic;
using Highscore.Domain.Entities;

namespace Highscore.Models
{
   public class GamesViewModel
   {
      public IEnumerable<Game> Games { get; set; }
   }
}
