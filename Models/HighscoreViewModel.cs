using System;
using System.Collections.Generic;
using Highscore.Domain.Entities;

namespace Highscore.Models
{
   public class HighscoreViewModel
   {
      public PlayerViewModel Player { get; set; }
      public GameViewModel Game { get; set; }
      public int Points { get; set; }
      public DateTime Date { get; set; }
   }
}
