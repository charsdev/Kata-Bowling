using System.Linq;

namespace Game
{
    public class GameModel
    {
        public const int TotalRounds = 10;
        public const int MaxPines = 10;
        public const int RollsPerRound = 2;
        public const int ExtraTurns = 1;
        public const int TotalRolls = (TotalRounds * RollsPerRound) + ExtraTurns;

        public const string StrikeMark = "X";
        public const string SpareMark = "/";
        public const string GutterMark = "-";

        public int[] RollsResult { get; } = new int[TotalRolls];
        public int RollIndex { get; private set; }
        public int RoundIndex { get; private set; }
        public int LeftPines { get; private set; } = MaxPines;

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

        private void NextRound()
        {
            RoundIndex++;
            ResetPines();
        }

        public void HandleTurn(int currentRollIndex, int rollResult)
        {
            if (IsLastRound(RoundIndex))
            {
                HandleThirdTurn(rollResult);
                return;
            }

            if (IsFirstRoll(currentRollIndex))
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
            if (RollIndex == TotalRolls - 3)
            {
                LeftPines = IsStrike(RollIndex) ? MaxPines : LeftPines - rollResult;
                NextRoll();
            }
            else if (RollIndex == TotalRolls - 2)
            {
                var lastRoll = RollIndex - 1;
                if (IsStrike(lastRoll))
                {
                    LeftPines = IsStrike(RollIndex) ? MaxPines : LeftPines - rollResult;
                    NextRoll();
                }
                else
                {
                    if (IsSpare(RollIndex))
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
        public bool IsSpare(int rollIndex) => RollsResult[rollIndex] == LeftPines;
        public bool IsGutter(int rollIndex) => RollsResult[rollIndex] == 0;
        #endregion Check Score

        public bool IsLastRound(int roundIndex) => roundIndex == TotalRounds - 1;
        public void CleanPines(int amount) => LeftPines -= amount;
        private void ResetPines() => LeftPines = MaxPines;
        public bool IsEndGame() => RoundIndex >= TotalRounds;
        private void NextRoll() => RollIndex++;
        public void SaveResult(int rollIndex, int result) => RollsResult[rollIndex] = result;
        public bool IsFirstRoll(int currentRollIndex) => currentRollIndex % 2 == 0;
    }
}
