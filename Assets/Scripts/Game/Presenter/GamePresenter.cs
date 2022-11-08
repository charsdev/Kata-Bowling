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

        private int GetRandomFallPines(int max)
        {
            return Random.Range(0, max + 1);
        }

        public void Throw()
        {
            //if (_model.IsEndGame())
            //{
            //    var button = _view.GetButton();
            //    if (button.interactable)
            //    {
            //        button.interactable = false;
            //    }
            //    return;
            //}

            //var ball = _view.GetBall();
            //ball.Launch();

            var currentRollIndex = _model.GetRollIndex();
            var turnPines = _model.GetPines();
            var rollResult = currentRollIndex % 2 == 0 ? 4 : 6;//GetRandomFallPines(turnPines);

            _model.SaveResult(currentRollIndex, rollResult);
            
            var currentMark = _model.GetScoreMark(currentRollIndex);
            var currentRound = _model.GetCurrentRound();
            Debug.Log($"{currentRound} {currentRollIndex}");

            //_view.UpdateTotalScore(currentRound, _model.HandleTotalResult(currentMark));

            _model.HandleTurn(currentRollIndex, rollResult);
            _view.UpdateScoreBoard(currentRound, currentRollIndex % 2, currentMark);
        }
    }
}