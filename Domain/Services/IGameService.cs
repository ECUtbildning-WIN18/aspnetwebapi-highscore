using System.Collections.Generic;
using System.Threading.Tasks;
using Highscore.Domain.Entities;

namespace Highscore.Domain.Services
{
   public interface IGameService
   {
      Task<IEnumerable<Game>> GetAllGamesAsync();
      Task<Game> GetGameByIdAsync(int id);
   }
}