using System.Linq;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingScores.Tests
{
    [TestClass]
    public class BowlingScoresTests
    {
        private ThrowParser _throwParser;
        private Game _game;
        [TestInitialize]
        public void Init()
        {
            _throwParser = new ThrowParser();
            _game = new Game(_throwParser);
        }

        [TestMethod]
        public void GetTurns_PassStringOf10Turns_Return10TurnObjects()
        {  
            var turns = _throwParser.Parse("[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0]");
            Assert.AreEqual(10, turns.Count());
        }

        [TestMethod]
        public void GetTurns_PassStringOfTurns_ReturnCorrectThowsScores()
        {
            var turns = _throwParser.Parse("[0,6],[0,0],[0,0],[0,0],[7,0],[0,0],[0,0],[0,0],[0,0],[0,9]");
            Assert.AreEqual(6, turns.First().SecondThrow.Score);
            Assert.AreEqual(7, turns[4].FirstThrow.Score);
            Assert.AreEqual(9, turns.Last().SecondThrow.Score);
        }

        [TestMethod]
        public void GetScores_Gutter_Ball_ReturnCorrectScores()
        {
            var scores = _game.GetScores("[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0]");
            Assert.AreEqual(0, scores);

            scores = _game.GetScores("[3,3],[3,3],[3,3],[3,3],[3,3],[3,3],[3,3],[3,3],[3,3],[3,3]");
            Assert.AreEqual(60, scores);

        }

        [TestMethod]
        public void GetScores_All_Spares_With_First_All_At_4()
        {
            var scores = _game.GetScores("[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6,4]");
            Assert.AreEqual(140, scores);
        }


        [TestMethod]
        public void GetScores_9_Spares_With_First_All_At_4()
        {
            var scores = _game.GetScores("[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[4,6],[0,0]");
            Assert.AreEqual(122, scores);
        }

        [TestMethod]
        public void GetScores_Nine_Strikes_Followed_By_A_Gutter_Ball()
        {
            var scores = _game.GetScores("[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[0,0]");
            Assert.AreEqual(240, scores);
        }

        [TestMethod]
        public void GetScores_PerfetGame()
        {
            var scores = _game.GetScores("[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,0],[10,10,10]");
            Assert.AreEqual(300, scores);
        }

        [TestCleanup]
        public void Clean()
        {
            _throwParser = null;
            _game = null;
        }
    }
}
