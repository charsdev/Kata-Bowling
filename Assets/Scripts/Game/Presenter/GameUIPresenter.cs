namespace Game.Presenter
{
    public class GameUIPresenter
    {
        private Game.View.GameUIView _view;
        private Game.Model.GameModel _gameModel;

        public GameUIPresenter(Game.View.GameUIView view)
        {
            _view = view;
            _gameModel = new Game.Model.GameModel();
        }

        public void Play()
        {
            _gameModel.HandlePins();
            _gameModel.Roll(_gameModel.CurrentPins);

            float currentScore = _gameModel.TotalScore;
            int endScore = _gameModel.TotalScore + _gameModel.HandleScore();
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