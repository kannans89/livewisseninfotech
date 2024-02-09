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
            if(_board.IsBoardFull())
                return ResultType.Draw;



            return ResultType.InProgress;
        }

        private bool MatchDiagonally()
        {
            if (CheckDiagonallyForX() || CheckDiagonallyForX())
                return true;
            return false;
        }
        private bool MatchHorizontally() { 
        
            if(CheckHorizonallyForX()||CheckHorizontallyForO())
                return true;
            return false;
        }
      
        

        private bool MatchVertically()
        {
           if(CheckVertiallyForX()||CheckVertiallyForO())
                return true;
            return false;
        }
        private bool CheckHorizonallyForX()
        {

            if (_board.GetCell(0).Mark == MarkType.X &&
               _board.GetCell(1).Mark == MarkType.X &&
               _board.GetCell(2).Mark == MarkType.X)
                return true;

            if (_board.GetCell(3).Mark == MarkType.X &&
               _board.GetCell(4).Mark == MarkType.X &&
               _board.GetCell(5).Mark == MarkType.X)
                return true;

            if (_board.GetCell(6).Mark == MarkType.X &&
               _board.GetCell(7).Mark == MarkType.X &&
               _board.GetCell(8).Mark == MarkType.X)
                return true;

            return false;

        }
        private bool CheckHorizontallyForO()
        {
            if (_board.GetCell(0).Mark == MarkType.O &&
               _board.GetCell(1).Mark == MarkType.O &&
               _board.GetCell(2).Mark == MarkType.O)
                return true;

            if (_board.GetCell(3).Mark == MarkType.O &&
               _board.GetCell(4).Mark == MarkType.O &&
               _board.GetCell(5).Mark == MarkType.O)
                return true;

            if (_board.GetCell(6).Mark == MarkType.O &&
               _board.GetCell(7).Mark == MarkType.O &&
               _board.GetCell(8).Mark == MarkType.O)
                return true;

            return false;
        }
        private bool CheckVertiallyForX()
        {

            if (_board.GetCell(0).Mark == MarkType.X &&
                _board.GetCell(3).Mark == MarkType.X &&
                _board.GetCell(6).Mark == MarkType.X)
                return true;

            if (_board.GetCell(1).Mark == MarkType.X &&
               _board.GetCell(4).Mark == MarkType.X &&
               _board.GetCell(7).Mark == MarkType.X)
                return true;

            if (_board.GetCell(2).Mark == MarkType.X &&
               _board.GetCell(5).Mark == MarkType.X &&
               _board.GetCell(8).Mark == MarkType.X)
                return true;

            return false;

        }
        private bool CheckVertiallyForO()
        {

            if (_board.GetCell(0).Mark == MarkType.O &&
                _board.GetCell(3).Mark == MarkType.O &&
                _board.GetCell(6).Mark == MarkType.O)
                return true;

            if (_board.GetCell(1).Mark == MarkType.O &&
               _board.GetCell(4).Mark == MarkType.O &&
               _board.GetCell(7).Mark == MarkType.O)
                return true;

            if (_board.GetCell(2).Mark == MarkType.O &&
               _board.GetCell(5).Mark == MarkType.O &&
               _board.GetCell(8).Mark == MarkType.O)
                return true;

            return false;

        }
        private bool CheckDiagonllayForO()
        {
            if (_board.GetCell(0).Mark == MarkType.O &&
                _board.GetCell(4).Mark == MarkType.O &&
                _board.GetCell(8).Mark == MarkType.O
                ||
                _board.GetCell(6).Mark == MarkType.O &&
                _board.GetCell(4).Mark == MarkType.O &&
                _board.GetCell(2).Mark == MarkType.O
                )
                return true;

            return false;
        }
        private bool CheckDiagonallyForX()
        {
            if (_board.GetCell(0).Mark == MarkType.X &&
                _board.GetCell(4).Mark == MarkType.X &&
                _board.GetCell(8).Mark == MarkType.X
                ||
                _board.GetCell(6).Mark == MarkType.X &&
                _board.GetCell(4).Mark == MarkType.X &&
                _board.GetCell(2).Mark == MarkType.X)
                return true;

            return false;
        }
       
    }
}
