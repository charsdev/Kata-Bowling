using System;

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
        private uint _rollIndex = 1;
        private uint _roundIndex = 1;

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
        }

        public uint GetPinesByTurn(uint turn) => turn > 1 ? _leftPines : MaxPines;

        public void CheckScore(uint currentRound, uint rollResult)
        {
            if (IsStrike(currentRound, rollResult) || GetRollIndex() == 2)
            {
                NextRound();
            }
            else
            {
                CleanPines(rollResult);
                NextRoll();
            }
        }

        public bool IsStrike(uint turn, uint fallPines) => fallPines == MaxPines && turn == 1;
        public bool IsSpare(uint turn, uint fallPines) => fallPines == _leftPines && turn > 1;
        public bool IsGutter(uint fallPines) => fallPines < 1;
        public void CleanPines(uint amount) => _leftPines -= amount;
        public bool IsEndGame() => _roundIndex > TotalTurns;
        public void NextRoll() => _rollIndex++;
        public uint GetCurrentRound() => _roundIndex;
        public uint GetRollIndex() => _rollIndex;
    }
}
