using Components.Abstract;
using Extensions;
using UnityEngine;

namespace Components
{
    public class TransformMover : MonoBehaviour, IMover
    {
        [SerializeField] 
        private float _speed;
        
        public void Move(Vector2 to)
        {
            var step = _speed * Time.deltaTime;
            transform.position += (to * step).AsVector3();
        }
    }
}