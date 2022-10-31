namespace Presenter
{
    class GameUIPresenter
    {
        private View.GameUIView _view;
        private Model.GameModel _gameModel;

        public GameUIPresenter(View.GameUIView view)
        {
            _view = view;
            _gameModel = new Model.GameModel();
        }

        public void Play()
        {
            _gameModel.HandlePins();
            _gameModel.Roll(_gameModel.CurrentPins);

            float currentScore = _gameModel.TotalScore;
            int endScore = _gameModel.TotalScore + _gameModel.GetScore();
            _gameModel.TotalScore = endScore;

            _view.UpdatePins(_gameModel.CurrentPins);

            _view.OnUpdate += () => {
                if (currentScore <= endScore)
                {
                    _view.UpdateScore(currentScore);
                    currentScore += UnityEngine.Time.deltaTime * _view.Speed;
                }
            };
        }

    }
}