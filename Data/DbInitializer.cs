using System;
using System.Collections.Generic;
using System.Linq;
using Highscore.Data;
using Highscore.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Highscore
{
   public static class DbInitializer
   {

      private static readonly IEnumerable<dynamic> Users = new List<dynamic>
      {
         new { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@nomail.com", Alias = "John", UserName = "jane.doe@nomail.com", Password = "Secret#123" },
         new { FirstName = "John", LastName = "Doe", Email = "john.doe@nomail.com", Alias = "Jane", UserName = "john.doe@nomail.com", Password = "Secret#123" }
      };

      private static readonly IEnumerable<dynamic> Games = new List<dynamic>
      {
         new { Title = "Tetris", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", ImageUrl = "https://via.placeholder.com/480x360" },
         new { Title = "Pac-Man", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", ImageUrl = "https://via.placeholder.com/480x360" },
         new { Title = "Space Invaders", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", ImageUrl = "https://via.placeholder.com/480x360" },
      };

      private static readonly IEnumerable<dynamic> Scores = new List<dynamic>
      {
         // Jane Doe
         new { User = new { UserName = "jane.doe@nomail.com" }, Game = new { Title = "Tetris" }, Date = "2017-01-21", Points = 135611 },
         new { User = new { UserName = "jane.doe@nomail.com" }, Game = new { Title = "Tetris" }, Date = "2017-10-23", Points = 298321 },
         new { User = new { UserName = "jane.doe@nomail.com" }, Game = new { Title = "Pac-Man" }, Date = "2017-01-21", Points = 135611 },
         new { User = new { UserName = "jane.doe@nomail.com" }, Game = new { Title = "Pac-Man" }, Date = "2017-10-23", Points = 298321 },
         // John Doe
         new { User = new { UserName = "john.doe@nomail.com" }, Game = new { Title = "Tetris" }, Date = "2017-11-03", Points = 293212 },
         new {  User = new { UserName = "john.doe@nomail.com" }, Game = new { Title = "Tetris" }, Date = "2018-03-05", Points = 301231 },
         new { User = new { UserName = "john.doe@nomail.com" }, Game = new { Title = "Space Invaders" }, Date = "2018-10-12", Points = 8982932 },
      };

      public static void EnsureUsersCreated(UserManager<User> userManager)
      {
         if (!userManager.Users.Any())
         {
            foreach(var user in Users)
            {
               var newUser = new User
               { 
                  UserName = user.UserName,
                  FirstName = user.FirstName,
                  LastName = user.LastName,
                  Email = user.Email,
                  Alias = user.Alias,
               };

               var result = userManager.CreateAsync(newUser, user.Password).Result;
               
               if (!result.Succeeded)
               {
                  throw new Exception($"Failed to create user {newUser.UserName}");
               }
            }
         }
      }

      public static void EnsureGamesCreated(ApplicationDbContext context)
      {
         if (!context.Games.Any())
         {
            foreach(var game in Games)
            {
               var newGame = new Game
               { 
                  Title = game.Title,
                  Description = game.Description,
                  ImageUrl = game.ImageUrl
               };

               context.Games.Add(newGame);
            }
         }

         context.SaveChanges();
      }      

      public static void EnsureScoresCreated(ApplicationDbContext context, UserManager<User> userManager)
      {
         var userDictionary = userManager.Users.ToDictionary(x => x.UserName);
         var gameDictionary = context.Games.ToDictionary(x => x.Title);

         if (!context.Scores.Any())
         {
            foreach (var score in Scores)
            {
               var user = userDictionary.ContainsKey(score.User.UserName)
                              ? userDictionary[score.User.UserName]
                              : null;

               var game = gameDictionary.ContainsKey(score.Game.Title)
                              ? gameDictionary[score.Game.Title]
                              : null;

               if (user == null || game == null) continue;

               var newScore = new Score
               {
                  Player = user,
                  Game = game,
                  Points = score.Points,
                  Date = DateTime.Parse(score.Date)
               };

               context.Scores.Add(newScore);
            }
         }

         context.SaveChanges();
      }

      public static void Seed(ApplicationDbContext context, 
                              //RoleManager<IdentityRole> roleManager, 
                              UserManager<User> userManager)
      {
         context.Database.EnsureCreated();

         EnsureUsersCreated(userManager);
         EnsureGamesCreated(context);
         EnsureScoresCreated(context, userManager);

         //var userDictionary = EnsureUsersCreated(context);
         //var scoreDictionary = EnsureHighscoresCreated(context);

         // if (!userManager.Users.Any())
         // {
         //    var userList = LoadUsers();

         //    foreach(var user in userList)
         //    {
         //       var newUser = new IdentityUser { 
         //          UserName = user.Email.Split('@')[0],
         //          // FirstName = user.FirstName,
         //          // LastName = user.LastName,
         //          Email = user.Email
         //       };

         //       userManager.CreateAsync(newUser);
         //    }
         // }

         // if (!context.Scores.Any())
         // {
         //    //var highscorse = LoadHighscores()
         // }
      }
   }
}
