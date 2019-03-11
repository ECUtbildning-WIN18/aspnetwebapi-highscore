using System.Collections.Generic;
using Highscore.Domain.Entities;

namespace Highscore.Models
{
   public class PlayerViewModel
   {
      public string Id { get; set; }
      public string Alias { get; set; }
      public IEnumerable<HighscoreViewModel> Highscores = new List<HighscoreViewModel>();      
   }
}
