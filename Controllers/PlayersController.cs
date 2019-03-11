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
   public class PlayersController : Controller
   {
      private readonly IUserService _userService;

      private readonly IScoreService _scoreService;

      public PlayersController(IUserService userService,
                              IScoreService scoreService)
      {
         _userService = userService;
         _scoreService = scoreService;
      }

      public async Task<IActionResult> Show(string id)
      {
         var user = await _userService.GetUserById(id);
         var highscores = await _scoreService.GetHighscoresByUserIdAsync(id);

         if (user == null)
         {
            return NotFound();
         }

         var viewModel = new PlayerViewModel
         {
            Alias = user.Alias,
            Highscores = highscores.Select(x => new HighscoreViewModel {
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
