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
   public class HomeController : Controller
   {
      private readonly IScoreService _scoreService;

      public HomeController(IScoreService scoreService)
      {
         _scoreService = scoreService;
      }

      public async Task<IActionResult> Index()
      {
         var highscores = await _scoreService.GetHighscoresAsync();

         var viewModel = new HomeViewModel
         {
            Highscores = highscores
         };

         return View(viewModel);
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
