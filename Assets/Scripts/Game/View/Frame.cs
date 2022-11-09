using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Frame : MonoBehaviour
    {
        public GameObject[] Pins;
        private List<Vector3> _originalPosition = new List<Vector3>();
        private List<Quaternion> _originalRotation = new List<Quaternion>();
        private List<Vector3> _originalScale = new List<Vector3>();
        private List<Rigidbody> _rigidBodies = new List<Rigidbody>();

        private void Awake()
        {
            for (int i = 0; i < Pins.Length; i++)
            {
                var transform = Pins[i].transform;
                _originalPosition.Add(transform.position);
                _originalRotation.Add(transform.rotation);
                _originalScale.Add(transform.localScale);
                _rigidBodies.Add(transform.GetComponent<Rigidbody>());
            }
        }

        public void Reset()
        {
            for (int i = 0; i < Pins.Length; i++)
            {
                var transform = Pins[i].transform;
                transform.position = _originalPosition[i];
                transform.rotation = _originalRotation[i];
                transform.localScale = _originalScale[i];
                _rigidBodies[i].velocity = Vector3.zero;
                _rigidBodies[i].angularVelocity = Vector3.zero;
            }
        }

    }
}