using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    [System.Serializable]
    public struct FeedBackText
    {
        public TextMeshProUGUI Strike;
        public TextMeshProUGUI Spare;
        public TextMeshProUGUI Gutter;
        public TextMeshProUGUI PinesPoints;
    }

    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button _buttonThrow;
        [SerializeField] private CustomButton _buttonLeft;
        [SerializeField] private CustomButton _buttonRight;
        [SerializeField] private TextMeshProUGUI _signEnd;
        [SerializeField] private TurnResult[] _turnResultsUI;
        [SerializeField] private Ball _ball;
        [SerializeField] private Frame frame;
        [SerializeField] private CameraFollow _cameraFollow;

        public FeedBackText FeedbackText;

        private GamePresenter _presenter;

        private void Awake()
        {
            _presenter = new GamePresenter(this);
            _buttonThrow.onClick.AddListener(() => StartCoroutine(_presenter.ThrowCoroutine()));
            GetButtonRight().OnHeld.AddListener(() => _ball.MoveToDirection(Vector3.right));
            GetButtonLeft().OnHeld.AddListener(() => _ball.MoveToDirection(Vector3.left));
        }

        public void UpdateScoreBoard(int currentTurn, int indexPos, string print)
        {
            _turnResultsUI[currentTurn].SetNumberTurn(indexPos, print);
        }

        public Button GetButton() => _buttonThrow;

        public Ball GetBall() => _ball;

        public CustomButton GetButtonLeft() => _buttonLeft;

        public CustomButton GetButtonRight() => _buttonRight;

        public Frame GetFrame() => frame;

        public CameraFollow GetCameraFollow() => _cameraFollow;

        public void SeeEndSign(int amount)
        {
            _signEnd.text = $"AWESOME! YOUR SCORE IS <color=#FF0000>{amount}</color> POINTS!";
            _signEnd.gameObject.SetActive(true);
        }

        public void DisableThrowButton()
        {
            if (_buttonThrow.interactable)
            {
                _buttonThrow.interactable = false;
            }
        }

        public void HideFeedback()
        {
            FeedbackText.Strike.gameObject.SetActive(false);
            FeedbackText.Spare.gameObject.SetActive(false);
            FeedbackText.Gutter.gameObject.SetActive(false);
            FeedbackText.PinesPoints.gameObject.SetActive(false);
        }

        public void SetEnableButton(Button button, bool state)
        {
            button.gameObject.SetActive(state);
        }
    }
}
