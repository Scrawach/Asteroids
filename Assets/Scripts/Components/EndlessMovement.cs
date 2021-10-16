using Extensions;
using UnityEngine;

namespace Components
{
    public class EndlessMovement : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;

        private Vector2 _direction;

        public void Construct(Vector2 direction)
        {
            _direction = direction;
        }
        
        private void Update()
        {
            var step = _speed * Time.deltaTime;
            transform.position += (_direction * step).AsVector3();
        }
    }
}