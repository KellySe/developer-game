using DeveloperGame.Repositories.Datasources;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace DeveloperGameTests
{
    public class DeveloperGameDb_Tests
    {
        [Fact]
        public void DeveloperGameDb_PersistsData()
        {
            var gameDbConnection = new DeveloperGameDb();

            // Assert that the player "John Cobley" doesn't already exist before adding him.
            Assert.DoesNotContain(gameDbConnection.Players, player => player.Name == "John Cobley");

            gameDbConnection.Players.Add(new DeveloperGame.Repositories.Models.Player
            {
                Name = "John Cobley"
            });

            gameDbConnection.SaveChanges();

            var newGameDbConnection = new DeveloperGameDb();
            // Assert that the player "John Cobley" was added to the DB when SaveChanges was run above
            Assert.Contains(newGameDbConnection.Players, player => player.Name == "John Cobley");
        }
    }
}
