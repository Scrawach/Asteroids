using Components.Abstract;
using UnityEngine;

namespace Components.Environment
{
    [RequireComponent(typeof(IMover))]
    public class EndlessMovement : MonoBehaviour
    {
        private IMover _mover;

        public Vector2 Direction { get; private set; }

        public void Construct(Vector2 direction) => 
            Direction = direction;

        private void Awake() => 
            _mover = GetComponent<IMover>();

        private void Update() => 
            _mover.Move(Direction);

        public void Inverse() => 
            Direction *= -1;
    }
}