using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class GamePresenter
    {
        GameView _view;
        GameModel _model;





        public GamePresenter(GameView view)
        {
            _view = view;
            _model = new GameModel();
        }

        public void Throw()
        {
            string resultThrow = _model.Throw(); 


            _view.UpdateScoreBoard(_model.GetCurrentTurn() - 1, _model.GetThrowIndex(), resultThrow);


            if (resultThrow == "X" || _model.GetThrowIndex() == 2)
            {
                _model.NewRound();
            }
            else
            {
                _model.CleanPines(int.Parse(resultThrow));
                _model.StartNextThrow();
            }



        }
    }
}
