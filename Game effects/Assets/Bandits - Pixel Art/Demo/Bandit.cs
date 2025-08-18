using UnityEngine;

namespace Bandits___Pixel_Art.Demo
{
    public class Bandit : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private static readonly int AnimState = Animator.StringToHash("AnimState");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        private static readonly int AirSpeed = Animator.StringToHash("AirSpeed");

        private bool _grounded;
        private Animator _animator;
        private Rigidbody2D _body2d;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _body2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Jump();

            float inputX = Input.GetAxisRaw("Horizontal");
            if (inputX > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (inputX < 0)
                transform.rotation = Quaternion.identity;

            _body2d.velocity = new Vector2(inputX * _speed, _body2d.velocity.y);
            _animator.SetInteger(AnimState, Mathf.Abs(inputX) > Mathf.Epsilon ? 2 : 0);
        }

        private void Jump()
        {
            _animator.SetFloat(AirSpeed, _body2d.velocity.y);
            
            if (Input.GetKeyDown(KeyCode.Space) && _grounded)
            {
                _grounded = false;
                _animator.SetBool(Grounded, _grounded);
                _body2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent<Ground>(out _))
            {
                _grounded = true;
                _animator.SetBool(Grounded, _grounded);
            }
        }
    }
}