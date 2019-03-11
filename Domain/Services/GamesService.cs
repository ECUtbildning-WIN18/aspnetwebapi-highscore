using System.Collections.Generic;
using System.Threading.Tasks;
using Highscore.Domain.Entities;
using Highscore.Domain.Repositories;

namespace Highscore.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;    
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _gameRepository.GetAllAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }
    }
}