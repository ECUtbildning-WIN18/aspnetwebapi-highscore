using System.Collections.Generic;
using System.Threading.Tasks;
using Highscore.Data;
using Highscore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Highscore.Domain.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GameRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;    
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _dbContext.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}