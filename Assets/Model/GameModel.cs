namespace Model
{
    class GameModel
    {
        #region constants
        private const int MaxRolls = 21;
        private const int MaxPins = 10;
        #endregion

        private readonly int[] _rolls = new int[MaxRolls];
        private int _currentRoll;

        public int TotalScore { get; set; }
        public int CurrentPins { get; private set; }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == MaxPins;
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == MaxPins;
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        public void HandlePins()
        {
            CurrentPins = UnityEngine.Random.Range(0, MaxPins);
        }

        public int GetScore()
        {
            int score = 0;
            for (int frame = 0, frameIndex = 0; frame < MaxPins; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }
    }
}
