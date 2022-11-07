using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 direction;

    private void Update()
    {
        transform.Rotate(direction * Time.deltaTime);
    }
}
