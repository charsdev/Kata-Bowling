using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Game
{
    public class CustomButton : Button
    {
        private bool _isPressed;
        public UnityEvent OnHeld;

        public override void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed) OnHeld.Invoke();
        }
    }
}
