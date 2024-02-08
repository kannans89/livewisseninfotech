using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib.Test
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void Board_CreatedAllEmptyCells()
        {
            var board = new Board();
            foreach (var cell in board.Cells)
            {
                Assert.That(cell.Mark, Is.EqualTo(MarkType.Empty));
            }
                
           // Assert.That(board.Cells, Is.All.EqualTo(MarkType.Empty));
        }

        [Test]
        [TestCase(0,MarkType.X)]
        [TestCase(1, MarkType.X)]
        [TestCase(2, MarkType.X)]
        [TestCase(3, MarkType.X)]
        [TestCase(8, MarkType.X)]
       // [TestCase(9, MarkType.X)]
        public void MarkCell_ShouldBeAbleToMarkCell(int location,MarkType mark) { 
        
            var board = new Board();
            board.MarkCell(location, mark);
            Assert.That(board.GetCell(location).Mark, Is.EqualTo(mark));
        }


        [Test]
        public void MarkCell_InvalidCellPosition_ShouldThrowException()
        {
            var board = new Board();
            Assert.Throws<InvalidCellPositionException>(() => board.MarkCell(9, MarkType.X));
        }

        [Test]
        public void ShouldREturnTrueIfBoardIsFull() { 
        
            var board = new Board();
            board.MarkCell(0, MarkType.X);
            board.MarkCell(1, MarkType.X);
            board.MarkCell(2, MarkType.X);
            board.MarkCell(3, MarkType.X);
            board.MarkCell(4, MarkType.X);
            board.MarkCell(5, MarkType.X);
            board.MarkCell(6, MarkType.X);
            board.MarkCell(7, MarkType.X);
            board.MarkCell(8, MarkType.X);


            Assert.That(board.IsBoardFull, Is.True);
        }
    }
}
