using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Highscore.Models;
using Highscore.Domain.Services;

namespace Highscore.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IScoreService _scoreService;

        public GamesController(IGameService gameService,
                               IScoreService scoreService)
        {
            _gameService = gameService;
            _scoreService = scoreService;
        }

        public async Task<IActionResult> Show(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            var highscores = await _scoreService.GetHighscoresByGameIdAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            var viewModel = new GameViewModel
            {
               Title = game.Title,
               Description = game.Description,
               ImageUrl = game.ImageUrl,
               ImageDescription = game.Title,
               Highscores = highscores.Select(x => new HighscoreViewModel {
                  Player = new PlayerViewModel
                  {
                     Id = x.Player.Id,         
                     Alias = x.Player.Alias
                  },
                  Game = new GameViewModel
                  {
                     Id = x.Game.Id,
                     Title = x.Game.Title,
                     Description = x.Game.Description
                  },
                     Points = x.Points,
                     Date = x.Date
                  })
            };

            return View(viewModel);
        }
    }
}
