using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib.Test
{
    [TestFixture]
    public class ResultAnalzyerTest
    {
        [Test]
        public void ResultAnlyser_ShouldAnalzyerEmptyBoard_ReturnsGameNotStared() { 
        
            var board = new Board();
            var resultAnalyzer = new ResultAnalyzer(board);
            var result= resultAnalyzer.Analyze();
            Assert.That(result, Is.EqualTo(ResultType.NotStarted));

        }

        [Test]
        public void ResultAnlyzer_ShouldAnalzyerInProgressBoard_ReturnsGameInProgress()
        {
        
            var board = new Board();
            board.MarkCell(0, MarkType.X);
            var resultAnalyzer = new ResultAnalyzer(board);
            var result= resultAnalyzer.Analyze();
            Assert.That(result, Is.EqualTo(ResultType.InProgress));

        }
    }
}
