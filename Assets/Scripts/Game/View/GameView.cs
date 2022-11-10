using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button _buttonThrow;
        [SerializeField] private TextMeshProUGUI _signEnd;
        [SerializeField] private TurnResult[] _turnResultsUI;
        [SerializeField] private Ball _ball;
        [SerializeField] private CameraFilterFXGlitch _filter;
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private Frame _frame;

        public TextMeshProUGUI[] feedbackText;

        private GamePresenter _presenter;

        private void Awake()
        {
            _presenter = new GamePresenter(this);
            _buttonThrow.onClick.AddListener(_presenter.Throw);
        }

        public void UpdateScoreBoard(int currentTurn, int indexPos, string print)
        {
            _turnResultsUI[currentTurn].SetNumberTurn(indexPos, print);
        }

        internal Button GetButton() => _buttonThrow;

        internal Frame GetFrame() => _frame;

        internal Ball GetBall() => _ball;

        internal CameraFilterFXGlitch GetFilter() => _filter;

        internal CameraFollow GetCameraFollow() => _cameraFollow;

        public void SeeEndSign(int amount)
        {
            _signEnd.text = $"AWESOME! YOUR SCORE IS <color=#FF0000>{amount}</color> POINTS!";
            _signEnd.gameObject.SetActive(true);
        }

    }
}
