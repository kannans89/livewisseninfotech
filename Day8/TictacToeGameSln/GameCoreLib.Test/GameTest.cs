using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib.Test
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void Play_ShouldMarkCellAndChangePlayer()
        {
            var board = new Board();
            var player1 = new Player { Name = "Player1", Mark = MarkType.X };
            var player2 = new Player { Name = "Player2", Mark = MarkType.O };
            var players = new Player[] { player1, player2 };
            var resultAnalyzer = new ResultAnalyzer(board);
            var game = new Game(board, players, resultAnalyzer);

            game.Play(0);
            Assert.That(game.Status, Is.EqualTo(ResultType.InProgress));
            Assert.That(game.CurrentPlayer, Is.EqualTo(player2));
        }
        [Test]
        public void Play_ShouldMarkCellAndChangePlayer2()
        {
            var board = new Board();
            var player1 = new Player { Name = "Player1", Mark = MarkType.X };
            var player2 = new Player { Name = "Player2", Mark = MarkType.O };
            var players = new Player[] { player1, player2 };
            var resultAnalyzer = new ResultAnalyzer(board);
            var game = new Game(board, players, resultAnalyzer);

            game.Play(0);
            game.Play(1);
            Assert.That(game.Status, Is.EqualTo(ResultType.InProgress));
            Assert.That(game.CurrentPlayer, Is.EqualTo(player1));
        }
        [Test]
        public void Player_AfterWin_ShouldNotChangePlayer()
        {
            var board = new Mock<IBoard>();
            var player1 = new Player { Name = "Player1", Mark = MarkType.X };
            var player2 = new Player { Name = "Player2", Mark = MarkType.O };
            var players = new Player[] { player1, player2 };
            var resultAnalyzer = new Mock<IResultAnalyzer>();

            var game = new Game(board.Object, players, resultAnalyzer.Object);

            resultAnalyzer.Setup(x => x.Analyze()).Returns(ResultType.Win);
           
            game.Play(0);
            Assert.That(game.Status, Is.EqualTo(ResultType.Win));
            Assert.That(game.CurrentPlayer, Is.EqualTo(player1));

            
        }
    }
}
