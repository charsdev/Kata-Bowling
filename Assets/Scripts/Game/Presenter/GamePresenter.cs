using System.Collections;
using System.Collections.Generic;
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
           
            var camera = _view.GetCameraFollow();
            camera.OnFinishFollow.AddListener(HideFeeback);
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

            #region Effects
            var ball = _view.GetBall();
            ball.Launch();

            var cameraFollow = _view.GetCameraFollow();
            cameraFollow.Follow();

            var frame = _view.GetFrame();
            frame.Reset();
            #endregion

            #region Pines result
            var currentRollIndex = _model.RollIndex;
            var turnPines = _model.LeftPines;
            var rollResult = GetRandomFallPines(turnPines);

            _model.SaveResult(currentRollIndex, rollResult);
            #endregion

            #region Mark
            var currentMark = _model.GetScoreMark(currentRollIndex);
            ShowFeedBackByMark(currentMark);
            #endregion

            #region Handle next turn
            var currentRound = _model.RoundIndex;
            _model.HandleTurn(currentRollIndex, rollResult);
            #endregion

            #region Handle Score board
            var lastTurnIndex = currentRollIndex - (GameModel.TotalRolls - 3);
            var pairTurn = currentRollIndex % 2;
            var turn = _model.IsLastRound(currentRound) ? lastTurnIndex : pairTurn;
            _view.UpdateScoreBoard(currentRound, turn, currentMark); 
            #endregion
        }

        public void ShowFeedBackByMark(string scoreMark)
        {
            //TODO change
            if (scoreMark == GameModel.StrikeMark)
            {
                _view.feedbackText[0].gameObject.SetActive(true);
            }
            else if(scoreMark == GameModel.SpareMark)
            {
                _view.feedbackText[1].gameObject.SetActive(true);
            }
            else if (scoreMark == GameModel.GutterMark)
            {
                _view.feedbackText[2].gameObject.SetActive(true);
            }
        }

        public void HideFeeback()
        {
            _view.feedbackText[0].gameObject.SetActive(false);
            _view.feedbackText[1].gameObject.SetActive(false);
            _view.feedbackText[2].gameObject.SetActive(false);
        }

        public IEnumerator ThrowCoroutine()
        {
            _view.GetBall().Launch();

            var cameraFollow = _view.GetCameraFollow();
            cameraFollow.Follow();

            var currentRollIndex = _model.RollIndex;

            while (!cameraFollow.Finished)
            {
                yield return null;
            }

            var frame = _view.GetFrame();
            var rollResult = frame.GetPinsFalled();
            _model.SaveResult(currentRollIndex, rollResult);

            //get the mark after handle the turn
            var currentMark = _model.GetScoreMark(currentRollIndex);

            //Handle next turn
            var currentRound = _model.RoundIndex;
            _model.HandleTurn(currentRollIndex, rollResult);

            //Handle score board
            var lastTurnIndex = currentRollIndex - (GameModel.TotalRolls - 3);
            var pairTurn = currentRollIndex % 2;

            var turn = _model.IsLastRound(currentRound) ? lastTurnIndex : pairTurn;
            _view.UpdateScoreBoard(currentRound, turn, currentMark);

            if (_model.IsFirstRoll(_model.RollIndex))
            {
                frame.Reset();
            }
            else
            {
                frame.HideFalledPins();
            }
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



