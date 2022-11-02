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
            
            Debug.LogError(_model.Throw());
            if (_model.EndGame()) 
            {
                _view.EndGame();
            }
        }


        
    }
}
