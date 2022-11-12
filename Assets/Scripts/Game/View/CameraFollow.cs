using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _offset;
        [SerializeField] private float _WaitTime;

        private Vector3 _initialPosition;
        private Vector3 _targetPosition;
        public UnityEvent OnFinishFollow;
        public AnimationCurve MoveCurve;

        public bool Finished;
        public bool WaitingToFinish;

        private void Start()
        {
            _initialPosition = transform.position;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _offset);
        }

        public void Follow()
        {
            StopAllCoroutines();
            StartCoroutine(FollowCoroutine(_WaitTime));
        }

        private IEnumerator FollowCoroutine(float time)
        {
            Finished = false;
            WaitingToFinish = false;

            Vector3 startingPos = transform.position;
            Vector3 finalPos = _targetPosition;
            float elapsedTime = 0;

            while (elapsedTime < time)
            {
                transform.position = Vector3.Lerp(startingPos, finalPos, MoveCurve.Evaluate(elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            WaitingToFinish = true;

            yield return new WaitForSeconds(_WaitTime);
            OnFinishFollow?.Invoke();
            Finished = true;
        }


        public void ResetCamera()
        {
            transform.position = _initialPosition;
            _targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _offset);
        }
    }
}