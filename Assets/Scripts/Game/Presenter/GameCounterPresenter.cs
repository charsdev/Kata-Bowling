using System;
using System.Collections.Generic;
using Game.View;
using Game.Model;
namespace Game.Presenter
{
    public class GameCounterPresenter
    {
        private GameCounterView _view;
        private GameCounterModel _model;

        public GameCounterPresenter(GameCounterView view, List<BowlThrowMarkerView> markers)
        {
            _model = new GameCounterModel(markers);
            _view = view;

        }

        void GameInit()
        {

        }

        public void OnTrhowedPine(int pinesFalled)
        {
            _model.ThrowPines(pinesFalled);
        }
    }
}