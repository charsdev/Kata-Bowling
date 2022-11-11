using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button _buttonThrow;
        [SerializeField] private TextMeshProUGUI _signEnd;
        [SerializeField] private TurnResult[] _turnResultsUI;
        [SerializeField] private Ball _ball;
        [SerializeField] private Frame frame;
        [SerializeField] private CameraFollow _cameraFollow;

        public TextMeshProUGUI[] feedbackText;

        private GamePresenter _presenter;

        public Frame GetFrame()
        {
            return frame;
        }

        private void Awake()
        {
            _presenter = new GamePresenter(this);
            _buttonThrow.onClick.AddListener(() => _presenter.Throw());
        }

        public void UpdateScoreBoard(int currentTurn, int indexPos, string print)
        {
            _turnResultsUI[currentTurn].SetNumberTurn(indexPos, print);
        }


        internal Button GetButton() => _buttonThrow;

        internal Ball GetBall() => _ball;

        internal CameraFollow GetCameraFollow() => _cameraFollow;

        public void SeeEndSign(int amount)
        {
            _signEnd.text = $"AWESOME! YOUR SCORE IS <color=#FF0000>{amount}</color> POINTS!";
            _signEnd.gameObject.SetActive(true);
        }

    }
}
