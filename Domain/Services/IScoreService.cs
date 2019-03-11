using System.Collections.Generic;
using System.Threading.Tasks;
using Highscore.Domain.Entities;

namespace Highscore.Domain.Services
{
   public interface IScoreService
   {
      Task<IList<Score>> GetHighscoresAsync();
      Task<IList<Score>> GetHighscoresByUserIdAsync(string id);
      Task<IList<Score>> GetHighscoresByGameIdAsync(int id);
   }
}
