using UnityEngine;

namespace Game
{
    public class GamePresenter
    {
        private readonly GameView _view;
        private readonly GameModel _model;

        public GamePresenter(GameView view)
        {
            _view = view;
            _model = new GameModel();
        }

        private uint GetRandomFallPines(int max)
        {
            max = Mathf.Abs(max);
            return (uint)Random.Range(0, max + 1);
        }

        public void Throw()
        {
            if (_model.IsEndGame())
            {
                var button = _view.GetButton();
                if (button.interactable)
                {
                    button.interactable = false;
                }
                return;
            }

            var ball = _view.GetBall();
            ball.Launch();

            var currentRound = _model.GetCurrentRound();
            var currentRollIndex = _model.GetRollIndex();
            var turnPines = _model.GetPinesByTurn(currentRollIndex);
            var rollResult = GetRandomFallPines((int)turnPines);
            var mark = _model.GetScoreMark(rollResult, currentRollIndex);
            _view.UpdateTotalScore(currentRound -1, _model.HandleTotalResult(mark));            
            _model.CheckScore(currentRollIndex, rollResult);
            _view.UpdateScoreBoard(currentRound - 1, currentRollIndex - 1, mark);
        }


    }
}