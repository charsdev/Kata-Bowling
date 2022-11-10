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

        private int GetRandomFallPines(int max) => Random.Range(0, max + 1);

        private void DrawScores()
        {
            var scores = _model.GetScores();
            const int lastIndex = GameModel.TotalRounds - 1;

            for (int i = 0; i < GameModel.TotalRounds; i++)
            {
                var currentScore = scores[i];
                var index = i < lastIndex ? 2 : 3;
                _view.UpdateScoreBoard(i, index, currentScore.ToString());
            }

            _view.SeeEndSign(scores[lastIndex]);
        }

        public void Throw()
        {
            if (_model.IsEndGame())
            {
                DisableThrowButton();
                DrawScores();
                return;
            }

            #region effects
            var cameraFollow = _view.GetCameraFollow();
            cameraFollow.ResetCamera();

            var filter = _view.GetFilter();
            filter.ExecuteGlitch();

            var frame = _view.GetFrame();
            frame.Reset();

            var ball = _view.GetBall();
            ball.Reset();
            ball.Launch();
            #endregion effects

            //Throw pines
            var currentRollIndex = _model.GetRollIndex();
            var turnPines = _model.GetPines();
            var rollResult = GetRandomFallPines(turnPines);
            _model.SaveResult(currentRollIndex, rollResult);
            var currentMark = _model.GetScoreMark(currentRollIndex);

            //Handle next turn
            var currentRound = _model.GetCurrentRound();
            _model.HandleTurn(currentRollIndex, rollResult);

            //Handle score board
            var turn = _model.IsLastRound(currentRound) ? currentRollIndex - (GameModel.TotalRolls - 3) : currentRollIndex % 2;
            _view.UpdateScoreBoard(currentRound, turn, currentMark);
        }

        private void DisableThrowButton()
        {
            var button = _view.GetButton();
            if (button.interactable)
            {
                button.interactable = false;
            }
        }
    }
}



