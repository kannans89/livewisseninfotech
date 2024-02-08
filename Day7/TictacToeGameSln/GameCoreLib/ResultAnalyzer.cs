using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib
{
    public class ResultAnalyzer
    {
        private Board _board;
        public ResultAnalyzer(Board board)
        {
            _board = board;
        }
        public ResultType Analyze()
        {
            if(_board.IsEmpty())
             return ResultType.NotStarted;

            //Win
            if(MatchVertically() || MatchHorizontally() || MatchDiagonally())
                return ResultType.Win;

            //Draw
            if(_board.IsFull())
                return ResultType.Draw;



            return ResultType.InProgress;
        }
        private bool MatchHorizontally() { 
        
            if(CheckHorizontallyForX()||CheckHorizontallyForO())
                return true;
            return false;
        }
        public bool CheckHorizontallyForX()
        {
            for (int i = 0; i < 9; i+=3)
            {
                if (_board.GetCell(i).Mark == MarkType.X &&
                                       
                    _board.GetCell(i + 1).Mark == MarkType.X 
                                && _board.GetCell(i + 2).Mark == MarkType.X)
                    return true;
            }
            return false;
        }
        public bool CheckHorizontallyForO()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (_board.GetCell(i).Mark == MarkType.O &&
                                       _board.GetCell(i + 1).Mark == MarkType.O
                                                          && _board.GetCell(i + 2).Mark == MarkType.O)
                    return true;
            }
            return false;
        }

        private bool MatchVertically()
        {
           if(CheckVerficallyForX()||CheckVerticallyForO())
                return true;
            return false;
        }
        public bool CheckVerficallyForX()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board.GetCell(i).Mark == MarkType.X &&
                    _board.GetCell(i + 3).Mark == MarkType.X 
                    && _board.GetCell(i + 6).Mark == MarkType.X)
                    return true;
            }
            return false;
        }
        public bool CheckVerticallyForO()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board.GetCell(i).Mark == MarkType.O 
                    && _board.GetCell(i + 3).Mark == MarkType.O 
                    && _board.GetCell(i + 6).Mark == MarkType.O)
                    return true;
            }
            return false;
        }
    }
}
