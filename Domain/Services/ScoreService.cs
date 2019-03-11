using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Highscore.Data;
using Highscore.Domain.Entities;
using Highscore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Highscore.Domain.Services
{
   public class ScoreService : IScoreService
   {
      private readonly ApplicationDbContext _context;

      public ScoreService(ApplicationDbContext context)
      {
         _context = context;    
      }

      public async Task<IList<Score>> GetHighscoresAsync()
      {
         var highscores = await _context.Scores
                              .Include(x => x.Game)
                              .Include(x => x.Player)
                              .GroupBy(x => x.Game.Id)
                              .SelectMany(a => a.Where(b => b.Points == a.Max(c => c.Points)))                              
                              .ToListAsync();

         return highscores;
      }

      public async Task<IList<Score>> GetHighscoresByUserIdAsync(string id)
      {
         var highscores = await _context.Scores
                                 .Include(x => x.Game)
                                 .Include(x => x.Player)
                                 .Where(x => x.Player.Id == id)
                                 .GroupBy(x => x.Game.Id)
                                 .SelectMany(a => a.Where(b => b.Points == a.Max(c => c.Points))) 
                                 .OrderBy(x => x.Game.Title)
                                 .ToListAsync();
         
         return highscores;
      }

      public async Task<IList<Score>> GetHighscoresByGameIdAsync(int id)
      {
         var highscores = await _context.Scores
                                 .Include(x => x.Game)
                                 .Include(x => x.Player)
                                 .Where(x => x.Game.Id == id)
                                 .OrderByDescending(x => x.Points)
                                 .ToListAsync();
         
         return highscores;
      }
   }
}
