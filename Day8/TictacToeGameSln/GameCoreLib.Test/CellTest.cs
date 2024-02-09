using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib.Test
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void Cell_ShouldHaveAnEmptyMark()
        {
           var cell = new Cell();
           Assert.That(cell.Mark,Is.EqualTo(MarkType.Empty));
        }

        [Test]
        [TestCase(MarkType.X)]
        [TestCase(MarkType.O)]
        public void Cell_ShouldBeAbleToSetMark(MarkType inputMarktype)
        {
            var cell = new Cell();
            cell.Mark = inputMarktype;
            Assert.That(cell.Mark, Is.EqualTo(inputMarktype));
        }

        [Test]
        public void Cell_AlreadyMarked_ShouldThrowException()
        {
            var cell = new Cell();
            cell.Mark = MarkType.X;
           Assert.Throws<InvalidOperationException>(() => cell.Mark = MarkType.O);
        }
    }
}
