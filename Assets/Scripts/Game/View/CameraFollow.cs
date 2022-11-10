using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject ball;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float offset;
        private Vector3 _initialPosition;

        public bool CanFollow { get; set; }

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            if (transform.position.z <= _maxDistance && CanFollow)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    ball.transform.position.z - offset);
            }
        }

        public void ResetCamera()
        {
            transform.position = _initialPosition;
        }
    }
}