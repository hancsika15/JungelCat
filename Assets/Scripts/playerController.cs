using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _facingRight = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        _animator.SetFloat("speed", Mathf.Abs(move));

        _rigidbody.linearVelocity = new Vector2(
            x: move * _maxSpeed,
            y: _rigidbody.linearVelocity.y);

        if (move > 0 && !_facingRight) Flip();
        else if (move < 0 && _facingRight) Flip();
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;

        transform.localScale = transformScale;
    }
}

