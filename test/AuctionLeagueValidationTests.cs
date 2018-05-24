using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Validators;
using Data.Models;
using Data.Enums;

namespace test
{
    [TestClass]
    public class AuctionLeagueValidationTests
    {
        [TestMethod]
        public void Two_GoalKeepers()
        {
            Team t = new Team();
            t.Players.Add(new Player(){Position=Position.GoalKeeper,PLTeam = new PLTeam(){ID=1,Name="TeamA"}});
            AuctionLeagueValidator v = new AuctionLeagueValidator();

            var result = v.ValidatePlayerPurchase(t,new Player(){Position=Position.GoalKeeper,PLTeam = new PLTeam(){ID=1,Name="TeamA"}});

            Assert.IsFalse(result.TeamValid);
            Assert.AreEqual(1,result.Errors.Count);
            Assert.AreEqual("Cannot have more than 1 goalkeeper",result.Errors[0].Name);
        }
    }
}
