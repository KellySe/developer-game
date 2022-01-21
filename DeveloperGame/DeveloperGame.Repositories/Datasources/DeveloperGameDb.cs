using DeveloperGame.Repositories.Models;
using System;
using System.Collections.Generic;

namespace DeveloperGame.Repositories.Datasources
{
    public class DeveloperGameDb : IDeveloperGameDb
    {
        /// <summary>
        /// As discussed this constructor will generate our database. In this solution we are using Guids 
        /// for our IDs. In reality our Id fields would be generated automatically but here we are faking up our DB
        /// so to ensure our objects are linked correctly we are using constructors that allow us to manually
        /// set the Ids i.e. new Guid("....
        /// </summary>
        public DeveloperGameDb()
        {
            GameDetails = new List<GameDetail>
            {
                new GameDetail(new Guid("a94d1f2d-f50b-44db-a6df-297d1d3728a3"))
                {
                    Name = "Number Guessing Game",
                    Description = "A game where the player has to guess the number chosen by the computer.",
                    CreatedBy = "John Cobley",
                    CreatedOn = new DateTime(2021, 11, 26),
                }
            };


            Players = new List<Player> { 
                new Player(new Guid("568da951-22e4-432c-9b4b-71b1c804c8c7"))
                {
                    Name = "John Cobley"
                }
            };

            Scores = new List<Score> {
                new Score
                {
                    GameId = new Guid("a94d1f2d-f50b-44db-a6df-297d1d3728a3"),
                    PlayerId = new Guid("568da951-22e4-432c-9b4b-71b1c804c8c7"),
                    ScoreValue = 5
                }
            };

            Achievements = new List<Achievement> {
                new Achievement(new Guid("4b509db6-9735-4d0c-8f00-7dbcc7e18a6d"))
                {
                    GameId = new Guid("a94d1f2d-f50b-44db-a6df-297d1d3728a3"),
                    Name = "Got it in One!",
                    Description = "You guessed the number in one guess!"
                }
            };

            PlayerAchievements = new List<PlayerAchievement>
            {
                new PlayerAchievement
                {
                    AchievementId = new Guid("4b509db6-9735-4d0c-8f00-7dbcc7e18a6d"),
                    PlayerId = new Guid("568da951-22e4-432c-9b4b-71b1c804c8c7")
                }
            };
        }

        public List<GameDetail> GameDetails { get; set; }
        public List<Score> Scores { get; set; }
        public List<Player> Players { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<PlayerAchievement> PlayerAchievements { get; set; }
    }
}
