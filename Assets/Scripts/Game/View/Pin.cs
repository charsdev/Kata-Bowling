using UnityEngine;

namespace Game
{
    public class Pin : MonoBehaviour
    {
        private Vector3 _originalPosition;
        private Quaternion _originalRotation;
        private Vector3 _originalScale;
        private Rigidbody _rigidbody;
        public bool IsFall;

        public void Reset()
        {
            transform.position = _originalPosition;
            transform.rotation = _originalRotation;
            transform.localScale = _originalScale;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            IsFall = false;
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _originalPosition = transform.position;
            _originalRotation = transform.rotation;
            _originalScale = transform.localScale;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            IsFall = true;
        }
    }
}