using DeveloperGame.Repositories.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

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
            LoadFromDb();
        }

        public List<GameDetail> GameDetails { get; set; }
        public List<Score> Scores { get; set; }
        public List<Player> Players { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<PlayerAchievement> PlayerAchievements { get; set; }

        public void SaveChanges()
        {
            var dbFile = new JObject();
            dbFile[nameof(GameDetails)] = JArray.FromObject(GameDetails);
            dbFile[nameof(Scores)] = JArray.FromObject(Scores);
            dbFile[nameof(Players)] = JArray.FromObject(Players);
            dbFile[nameof(Achievements)] = JArray.FromObject(Achievements);
            dbFile[nameof(PlayerAchievements)] = JArray.FromObject(PlayerAchievements);

            File.WriteAllText($@"{(Directory.Exists("Databases") ? "." : "..")}/Databases/{nameof(DeveloperGameDb)}.json", dbFile.ToString());
        }

        private void LoadFromDb()
        {
            var jsonText = File.ReadAllText($@"{(Directory.Exists("Databases") ? "." : "..")}/Databases/{nameof(DeveloperGameDb)}.json");

            if(jsonText == String.Empty)
            {
                jsonText = "{}";
            }

            var dbFile = JObject.Parse(jsonText);

            GameDetails = dbFile[nameof(GameDetails)]?.ToObject<List<GameDetail>>() ?? new List<GameDetail>();
            Scores = dbFile[nameof(Scores)]?.ToObject<List<Score>>() ?? new List<Score>();
            Players = dbFile[nameof(Players)]?.ToObject<List<Player>>() ?? new List<Player>();
            Achievements = dbFile[nameof(Achievements)]?.ToObject<List<Achievement>>() ?? new List<Achievement>();
            PlayerAchievements = dbFile[nameof(PlayerAchievements)]?.ToObject<List<PlayerAchievement>>() ?? new List<PlayerAchievement>();
        }
    }
}
