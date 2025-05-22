using UnityEngine;

public class platformMoveBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = .95f;

    private void Update()
    {
        transform.position +=
            Vector3.left
            * _speed
            * Time.deltaTime;
    }
}
