using System.Collections.Generic;
using System.Threading.Tasks;
using Highscore.Domain.Entities;

namespace Highscore.Domain.Repositories
{
   public interface IGameRepository
   {
      Task<IEnumerable<Game>> GetAllAsync();
      Task<Game> GetByIdAsync(int id);
   }
}