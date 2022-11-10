using System.Linq;

namespace Game
{
    public class GameModel
    {
        public const int TotalRounds = 10;
        public const int MaxPines = 10;
        public const int RollsPerRound = 2;
        public const int ExtraTurns = 1;
        public const int TotalRolls = TotalRounds * RollsPerRound + ExtraTurns;

        private const string StrikeMark = "X";
        private const string SpareMark = "/";
        private const string GutterMark = "-";

        public int[] RollsResult { get; } = new int[TotalRolls];

        private int _currentRoll;
        private int _currentRound;

        public int LeftPines { get; set; } = MaxPines;

        public string GetScoreMark(int rollIndex)
        {
            if (IsStrike(rollIndex))
            {
                return StrikeMark;
            }
            else if (IsSpare(rollIndex))
            {
                return SpareMark;
            }
            else if (IsGutter(rollIndex))
            {
                return GutterMark;
            }
            else
            {
                return RollsResult[rollIndex].ToString();
            }
        }

        public void NextRound()
        {
            _currentRound++;
            ResetPines();
        }

        public int GetPines() => LeftPines;

        public void HandleTurn(int currentRollIndex, int rollResult)
        {
            if (IsLastRound(GetCurrentRound()))
            {
                HandleThirdTurn(rollResult);
                return;
            }

            if (currentRollIndex % 2 == 0) //first roll
            {
                if (IsStrike(currentRollIndex))
                {
                    NextRound();
                    NextRoll();
                    NextRoll();
                }
                else
                {
                    CleanPines(rollResult);
                    NextRoll();
                }
            }
            else
            {
                CleanPines(rollResult);
                NextRound();
                NextRoll();
            }
        }

        private void HandleThirdTurn(int rollResult)
        {
            if (_currentRoll == TotalRolls - 3)
            {
                LeftPines = IsStrike(_currentRoll) ? MaxPines : LeftPines - rollResult;
                NextRoll();
            }
            else if (_currentRoll == TotalRolls - 2)
            {
                var lastRoll = _currentRoll - 1;
                if (IsStrike(lastRoll))
                {
                    LeftPines = IsStrike(_currentRoll) ? MaxPines : LeftPines - rollResult;
                    NextRoll();
                }
                else
                {
                    if (IsSpare(_currentRoll))
                    {
                        NextRoll();
                        ResetPines();
                    }
                    else
                    {
                        NextRound();
                    }
                }
            }
            else
            {
                NextRound();
            }
        }

        public int[] GetScores()
        {
            int[] scores = new int[TotalRounds];
            int sum = 0;
            int pairs = 0;
            for (int i = 0; i < TotalRounds - 1; i++)
            {
                if (IsStrike(pairs))
                {
                    sum += MaxPines + RollsResult[pairs + 2] + RollsResult[pairs + 3];
                }
                else if (RollsResult[pairs] + RollsResult[pairs + 1] == MaxPines)
                {
                    sum += MaxPines + RollsResult[pairs + 2];
                }
                else
                {
                    sum += RollsResult[pairs] + RollsResult[pairs + 1];
                }

                pairs += 2;
                scores[i] = sum;
            }

            for (int i = 1; i <= 3; i++)
            {
                var index = RollsResult.Length - i;
                sum += RollsResult[index];
            }

            scores[TotalRounds - 1] = sum;
            return scores;
        }


        #region Check Score
        public bool IsStrike(int rollIndex) => RollsResult[rollIndex] == MaxPines;

        public bool IsSpare(int rollIndex) =>  RollsResult[rollIndex] == LeftPines;

        public bool IsGutter(int rollIndex) => RollsResult[rollIndex] == 0;
        #endregion Check Score

        public bool IsLastRound(int roundIndex) => roundIndex == TotalRounds - 1;

        public void CleanPines(int amount) => LeftPines -= amount;

        private void ResetPines() => LeftPines = MaxPines;

        public bool IsEndGame() => _currentRound >= TotalRounds;

        public void NextRoll() => _currentRoll++;

        public int GetCurrentRound() => _currentRound;

        public int GetRollIndex() => _currentRoll;

        public int GetTotalScore() => RollsResult.Sum();

        public void SaveResult(int rollIndex, int result) => RollsResult[rollIndex] = result;
    }
}
