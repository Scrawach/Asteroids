using Components.Abstract;
using Extensions;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour, IEngine
    {
        [SerializeField]
        private float _speed;
        
        [SerializeField]
        private float _accelerationModifier;

        [SerializeField] 
        private float _rotateSpeed;

        private Rigidbody2D _rigidbody;
        private Vector2 _velocity;
        private Vector2 _rotation;

        public void Construct(float moveSpeed, float rotateSpeed, float acceleration)
        {
            _speed = moveSpeed;
            _rotateSpeed = rotateSpeed;
            _accelerationModifier = acceleration;
        }

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        public void Move(Vector2 to)
        {
            _velocity += ReachedVelocity(to);
            _rigidbody.MovePosition(NextPosition());
        }

        public void Rotate(Vector2 to)
        {
            var rotateStep = _rotateSpeed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, to.AsRotation(), rotateStep);
        }

        private Vector2 ReachedVelocity(Vector2 toDirection)
        {
            var desiredVelocity = toDirection * _speed;
            var acceleration = (desiredVelocity - _velocity) * _accelerationModifier;
            return acceleration * Time.fixedDeltaTime;
        }
        
        private Vector2 NextPosition()
        {
            var currentPosition = transform.position.AsVector2();
            var movement = _velocity * Time.fixedDeltaTime;
            var nextPosition = currentPosition + movement;
            return nextPosition;
        }
    }
}