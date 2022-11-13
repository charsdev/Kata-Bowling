using System;
using UnityEngine;

namespace Game
{
    public class Pin : MonoBehaviour
    {
        private Vector3 _originalPosition;
        private Quaternion _originalRotation;
        private Vector3 _originalScale;
        private Rigidbody _rigidbody;

        public void Reset()
        {
            transform.SetPositionAndRotation(_originalPosition, _originalRotation);
            transform.localScale = _originalScale;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            UnFreeze();
            gameObject.SetActive(true);
        }
  
        private void OnEnable()
        {
            _originalPosition = transform.position;
            _originalRotation = transform.rotation;
            _originalScale = transform.localScale;
            _rigidbody = GetComponent<Rigidbody>();
            Freeze();
        }


        public void Freeze()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void UnFreeze()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
        }


        public bool IsStanding => _originalRotation == transform.rotation;

    }
}