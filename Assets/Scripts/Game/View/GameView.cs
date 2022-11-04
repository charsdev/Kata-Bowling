using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    public class GameView : MonoBehaviour
    {

        GamePresenter _presenter;

        [SerializeField] Button _buttonThrow;
        [SerializeField] TurnResult[] _turnResultsUI;


        private void Awake()
        {
            _presenter = new GamePresenter(this);

            _buttonThrow.onClick.AddListener(_presenter.Throw);  
        }


        public void UpdateScoreBoard(int currentTurn, int indexPos, string print)
        {
            _turnResultsUI[currentTurn].NumberTurnText(indexPos, print);
        }

        internal void EndGame()
        {
            _buttonThrow.interactable = false;
        }
    }
}
