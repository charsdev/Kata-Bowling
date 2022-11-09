using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button _buttonThrow;
        [SerializeField] private TMPro.TextMeshProUGUI _signEnd;
        [SerializeField] private TurnResult[] _turnResultsUI;
        [SerializeField] private Ball _ball;
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

        internal Button GetButton()
        {
            return _buttonThrow;
        }

        internal Ball GetBall()
        {
            return _ball;
        }

        internal void UpdateTotalScore(int currentTurn, int v)
        {
          //  _turnResultsUI[currentTurn].SetTotal(v);
        }

        public void SeeEndSign(int amount)
        {
            _signEnd.text = $"AWESOME! YOU'RE SCORED <color=#FF0000>{amount}</color> POINTS!";
            _signEnd.gameObject.SetActive(true);
        }
    }
}
