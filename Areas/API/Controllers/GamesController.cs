using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Highscore.Models;
using Highscore.Domain.Services;
using System.Collections;
using Highscore.Domain.Entities;

namespace Highscore.Areas.API.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
       private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            var games = await _gameService.GetAllGamesAsync();

            return games;
        }
    }
}
