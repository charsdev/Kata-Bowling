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



        private void Awake()
        {
            _presenter = new GamePresenter(this);

            _buttonThrow.onClick.AddListener(_presenter.Throw);  
        }

        internal void EndGame()
        {
            _buttonThrow.interactable = false;
        }
    }
}
