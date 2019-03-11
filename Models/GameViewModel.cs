using System;
using System.Collections.Generic;
using Highscore.Domain.Entities;

namespace Highscore.Models
{
   public class GameViewModel
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string ImageUrl { get; set; }
      public string ImageDescription { get; set; }
      public IEnumerable<HighscoreViewModel> Highscores = new List<HighscoreViewModel>();
   }
}
