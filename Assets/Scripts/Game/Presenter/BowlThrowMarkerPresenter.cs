using Game.View;
using Game.Model;

namespace Game.Presenter
{
    public class BowlThrowMarkerPresenter
    {

        BowlThrowMarkerView _view;
        BowlThrowMarkerModel _model;

        public BowlThrowMarkerPresenter(BowlThrowMarkerView view)
        {
            _model = new BowlThrowMarkerModel();
            _view = view;
        }


    }

}