using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace Game.View
{
    public class GameUIView : MonoBehaviour
    {
        private Presenter.GameUIPresenter _gameUIPresenter;
        public float Speed;
        public Action OnUpdate;

        #region Serialized Fields
        [SerializeField] private TextMeshProUGUI _pins;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _button;
        #endregion

        private void OnEnable()
        {
            _button.onClick.AddListener(() => _gameUIPresenter.Play());
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void Start()
        {
            _gameUIPresenter = new Presenter.GameUIPresenter(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        public void UpdatePins(int value)
        {
            _pins.text = value.ToString();
        }

        public void UpdateScore(float value)
        {
            _scoreText.text = value.ToString("00000");
        }
    }
}

