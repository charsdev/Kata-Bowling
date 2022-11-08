using System;
using UnityEngine;

namespace Game
{
    public class GameModel
    {
        private const uint TotalTurns = 10;
        private const uint MaxPines = 10;
        private const string StrikeMark = "X";
        private const string SpareMark = "/";
        private const string GutterMark = "-";

        private uint _leftPines = MaxPines;
        private uint _rollIndex = 1;//turno
        private uint _roundIndex = 1;

        private uint _lastScore;
        private bool _isLastTurn;

        
        public uint LeftPines { get => _leftPines; set => _leftPines = value; }
        public bool IsLastTurn { get => _isLastTurn; set => _isLastTurn = value; }

        public string GetScoreMark(uint score, uint rollIndex)
        {

            
            if (IsStrike(rollIndex, score))
            {
                return StrikeMark;
            }
            else if (IsSpare(rollIndex, score))
            {
                return SpareMark;
            }
            else if (IsGutter(score))
            {
                return GutterMark;
            }
            else
            {
                return score.ToString();
            }
        }

        public void NextRound()
        {
            _roundIndex++;
            _rollIndex = 1;
            _leftPines = MaxPines;
            _lastScore = 0;
        }

        public uint GetPinesByTurn(uint turn) => turn > 1 ? _leftPines : MaxPines;

        public void CheckScore(uint currentRound, uint rollResult)
        {
            if (CheckLastTurn(currentRound))
            {
                CheckScoreLastTurn(rollResult);
                return;
            }



            if ( IsStrike(currentRound, rollResult) || GetRollIndex() == 2)
            {
                NextRound();
            }
            else
            {
                CleanPines(rollResult);
                NextRoll();
            }
        }


        public void CheckScoreLastTurn(uint rr)
        {
            if (_rollIndex != 2 )
            {
                if (IsStrike(1, rr))
                {
                    _rollIndex = 1;
                    _leftPines = MaxPines;
                    _lastScore = 99;
                }
                else
                {
                    _lastScore = rr;
                    NextRoll();
                }

                if (_rollIndex == 3)
                {
                    NextRound();
                }
            }
            else 
            {
            }
        }



        public int HandleTotalResult(string mark)
        {
            if (mark == "X" || mark == "/")
            {
                return 10;
            }

            int total = 0;
            int result1 = mark == "-" ? 0 : int.Parse(mark);
            total = result1 + (int)_lastScore;
            _lastScore = (uint)result1;
            return total;
        }

        public bool IsStrike(uint turn, uint fallPines) => fallPines == MaxPines && (turn == 1 || _isLastTurn);
        public bool IsSpare(uint turn, uint fallPines) => fallPines == _leftPines && (turn > 1 || _isLastTurn);
        public bool IsGutter(uint fallPines) => fallPines < 1;
        public bool CheckLastTurn(uint turn) => turn == TotalTurns;
        public void CleanPines(uint amount) => _leftPines -= amount;
        public bool IsEndGame() => _roundIndex > TotalTurns;
        public void NextRoll() => _rollIndex++;
        public uint GetCurrentRound() => _roundIndex;
        public uint GetRollIndex() => _rollIndex;
    }
}
