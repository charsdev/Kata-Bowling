namespace Game
{
    public class GameModel
    {
        private const uint TotalRounds = 10;
        private const int MaxPines = 10;

        private const string StrikeMark = "X";
        private const string SpareMark = "/";
        private const string GutterMark = "-";

        public int[] RollsResult { get; } = new int[21];
        private int _currentRoll = 0;
        private int _currentRound = 0;

        private int _lastScore;

        public int LeftPines { get; set; } = MaxPines;
        public bool IsLastTurn { get; set; }


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

        public void SaveResult(int rollIndex, int result)
        {
            RollsResult[rollIndex] = result;
        }

        public void NextRound()
        {
             _currentRound++;
             LeftPines = MaxPines;
        }

        public int GetPines() => LeftPines;

        public void HandleTurn(int currentRollIndex, int rollResult)
        {
            //if (CheckLastTurn(currentRound))
            //{
            //    CheckScoreLastTurn(rollResult);
            //    return;
            //}

            if (IsLastRound(currentRollIndex))
            {
                UnityEngine.Debug.Log("Last");
            }


            if (currentRollIndex % 2 == 0) //first roll
            {
                if (IsStrike(currentRollIndex))
                {
                    NextRound();
                }
                else
                {
                    CleanPines(rollResult);
                    NextRoll();
                }
            }
            else  //second roll  
            {
                CleanPines(rollResult);
                NextRound();
                NextRoll();
            }
        }


        public void CheckScoreLastTurn(int rollResult)
        {
            //if (_currentRoll != 2 )
            //{
            //    if (IsStrike(1, rr))
            //    {
            //        _currentRoll = 1;
            //        _leftPines = MaxPines;
            //        _lastScore = 99;
            //    }
            //    else
            //    {
            //        _lastScore = rr;
            //        NextRoll();
            //    }

            //    if (_currentRoll == 3)
            //    {
            //        NextRound();
            //    }
            //}
            //else 
            //{
            //}
        }

        public int HandleTotalResult(string mark)
        {
            if (mark == "X" || mark == "/")
            {
                return 10;
            }

            int result1 = mark == "-" ? 0 : int.Parse(mark);
            //int total = result1 + _lastScore;
            //_lastScore = result1;
            //return total;
            return 0;
        }

        #region Check Score
        public bool IsStrike(int rollIndex) => RollsResult[rollIndex] == MaxPines;
        public bool IsSpare(int rollIndex)
        {
            return RollsResult[rollIndex] == LeftPines;
        }

        public bool IsGutter(int rollIndex) => RollsResult[rollIndex] == 0;
        #endregion Check Score

        public bool IsLastRound(int roundIndex) => roundIndex == TotalRounds - 1 || IsLastTurn;

        public void CleanPines(int amount) => LeftPines -= amount;

        public bool IsEndGame() => _currentRound > TotalRounds - 1;

        public void NextRoll() => _currentRoll++;

        public int GetCurrentRound() => _currentRound;

        public int GetRollIndex() => _currentRoll;
    }
}
