using System;
using Microsoft.AspNetCore.Identity;

namespace Highscore.Domain.Entities
{
   public class Score
   {  
      public int Id { get; set; }
      public Game Game { get; set; }
      public User Player { get; set; }
      public DateTime Date { get; set; }
      public int Points { get; set; }
   }
}
