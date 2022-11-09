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
            var filter = _view.GetFilter();
            filter.ExecuteGlitch();

            if (_model.IsEndGame())
            {
                var button = _view.GetButton();
                if (button.interactable)
                {
                    button.interactable = false;
                }

                int sum = 0;
                int pairs = 0;

                for (int i = 0; i < _model.GetTotalRounds - 1; i++)
                {
                    if (_model.IsStrike(pairs))
                    {
                        //if (_model.IsStrike(pairs + 2))
                        //{
                        //    // sum += 10 + _model.RollsResult[pairs + 2] + _model.RollsResult[pairs + 4];
                        //}
                        //else
                        //{
                        //    sum += 10 + _model.RollsResult[pairs + 2] + _model.RollsResult[pairs + 3];
                        //}
                        sum += 10 + _model.RollsResult[pairs + 2] + _model.RollsResult[pairs + 3];
                        pairs++;
                        pairs++;
                    }
                    else if (_model.RollsResult[pairs] + _model.RollsResult[pairs + 1] == 10)
                    {
                        sum += 10 + _model.RollsResult[pairs + 2];
                        pairs += 2;
                    }
                    else
                    {
                        sum += (_model.RollsResult[pairs] + _model.RollsResult[pairs + 1]);
                        pairs += 2;
                    }

                    _view.UpdateScoreBoard(i, 2, sum.ToString());
                    //pairs += 2;
                }

                sum += _model.RollsResult[18] + _model.RollsResult[19] + _model.RollsResult[20];
                _view.UpdateScoreBoard(_model.GetTotalRounds - 1, 3, sum.ToString());

                _view.SeeEndSign(sum);
                return;
            }

            var frame = _view.GetFrame();
            frame.Reset();

            var ball = _view.GetBall();
            ball.Reset();
            ball.Launch();

            var currentRollIndex = _model.GetRollIndex();
            var turnPines = _model.GetPines();
            var rollResult = GetRandomFallPines(turnPines);

            _model.SaveResult(currentRollIndex, rollResult);

            var currentMark = _model.GetScoreMark(currentRollIndex);
            var currentRound = _model.GetCurrentRound();

            //_view.UpdateTotalScore(currentRound, _model.HandleTotalResult(currentMark));

            _model.HandleTurn(currentRollIndex, rollResult);

            if (_model.IsLastRound(currentRound))
            {
                Debug.Log($"{currentRound} {currentRollIndex}");
                _view.UpdateScoreBoard(currentRound, currentRollIndex - 18, currentMark);
                return;
            }

            _view.UpdateScoreBoard(currentRound, currentRollIndex % 2, currentMark);
        }
    }
}