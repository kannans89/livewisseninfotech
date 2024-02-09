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
        [Test]
        public void ResultAnlyzer_ShouldAnalzyerDrawBoard_ReturnsGameDraw()
        {
        
            var board = new Board();
            board.MarkCell(0, MarkType.X);
            board.MarkCell(1, MarkType.O);
            board.MarkCell(2, MarkType.X);
            board.MarkCell(3, MarkType.X);
            board.MarkCell(4, MarkType.O);
            board.MarkCell(5, MarkType.X);
            board.MarkCell(6, MarkType.O);
            board.MarkCell(7, MarkType.X);
            board.MarkCell(8, MarkType.O);
            var resultAnalyzer = new ResultAnalyzer(board);
            var result= resultAnalyzer.Analyze();
            Assert.That(result, Is.EqualTo(ResultType.Draw));

        }
        [Test]
        public void ResultAnlyzer_ShouldAnalzyerWinBoard_ReturnsGameWin()
        {
        
            //var board = new Board();
            //board.MarkCell(0, MarkType.X);
            //board.MarkCell(1, MarkType.X);
            //board.MarkCell(2, MarkType.X);
            //var resultAnalyzer = new ResultAnalyzer(board);
            //var result= resultAnalyzer.Analyze();
            //Assert.That(result, Is.EqualTo(ResultType.Win));

            var board = new Mock<IBoard>();
            board.Setup(x => x.IsEmpty()).Returns(false);
            board.Setup(x => x.IsBoardFull()).Returns(true);

            board.Setup(x => x.GetCell(0)).Returns(new Cell{ Mark=MarkType.X });
            board.Setup(x => x.GetCell(1)).Returns(new Cell{ Mark = MarkType.X });
            board.Setup(x => x.GetCell(2)).Returns(new Cell{ Mark = MarkType.X });

            board.Setup(x => x.GetCell(3)).Returns(new Cell { Mark = MarkType.X });
            board.Setup(x => x.GetCell(4)).Returns(new Cell { Mark = MarkType.X });
            board.Setup(x => x.GetCell(5)).Returns(new Cell { Mark = MarkType.X });


            board.Setup(x => x.GetCell(6)).Returns(new Cell { Mark = MarkType.X });
            board.Setup(x => x.GetCell(7)).Returns(new Cell { Mark = MarkType.X });
            board.Setup(x => x.GetCell(8)).Returns(new Cell { Mark = MarkType.X });


            var resultAnalyzer = new ResultAnalyzer(board.Object);
            var result = resultAnalyzer.Analyze();
            Assert.That(result, Is.EqualTo(ResultType.Win));

        }


    }
}
