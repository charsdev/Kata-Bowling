using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CarlosView : MonoBehaviour
    {
       [SerializeField] private Button _buttonThrow;
        private CarlosPresenter _presenter;


        private void Awake()
        {
            _presenter = new CarlosPresenter(this);
            _buttonThrow.onClick.AddListener(_presenter.Throw);
        }

        public void UpdateView(string r, int turn)
        {
            Debug.Log($"EN EL TURNO {turn} SE LANZARON {r} PINOS");
        }

        public void SetButtonOff()
        {
            _buttonThrow.interactable = false;
        }
    }
}
