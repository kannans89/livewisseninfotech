using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib
{
    public class Board
    {
        private Cell[] _cells = new Cell[9];

        public Board()
        {
            for (int i = 0; i < 9; i++)
            {
                _cells[i] = new Cell();
            }
        }

        public void MarkCell(int index, MarkType mark)
        {
            if (index >= 0 && index < 9)
            {
                _cells[index].Mark = mark;
                return;
            }
            throw new InvalidCellPositionException("Wrong cell position");
        }

        public bool IsBoardFull()
        {
            foreach (var cell in _cells)
            {
                if (cell.Mark == MarkType.Empty)
                    return false;
            }
            return true;
        }

        public bool IsEmpty()
        {
            foreach (var cell in _cells)
            {
                if (cell.Mark != MarkType.Empty)
                    return false;
            }
            return true;
        }

        public Cell GetCell(int index)
        {
            return _cells[index];
        }

        public Cell[] Cells
        {

            get { return _cells; }
        }
    }
}
