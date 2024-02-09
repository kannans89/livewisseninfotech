using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib
{
    public class Game
    {
        private IBoard _board;
        private Player[] _players;
        private IResultAnalyzer _resultAnalyzer;
        private Player _currentPlayer;
        private ResultType _status= ResultType.NotStarted;

        public Game(IBoard board, Player[] players, IResultAnalyzer resultAnalyzer)
        {
            _board = board;
            _players = players;
            _resultAnalyzer = resultAnalyzer;
            _currentPlayer = _players[0];
        }

        public void Play(int cellPosition) { 
        
            _board.MarkCell(cellPosition, _currentPlayer.Mark);
           _status= _resultAnalyzer.Analyze();
            if(_status== ResultType.Win || _status== ResultType.Draw)
            {
                return;
            }
            if (_currentPlayer == _players[0])
            {
                _currentPlayer = _players[1];
            }
            else
            {
                _currentPlayer = _players[0];
            }

        }
       
        public ResultType Status
        {
            get { return _status; }
        }
        public Player CurrentPlayer {
            get { 
             return _currentPlayer;
            }
         }

    }
}
