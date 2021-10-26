using Components.Abstract;
using Extensions;
using Infrastructure.InputLogic;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IRotator))]
    public class RotateToMouse : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IRotator _rotator;
        private Camera _camera;

        public void Construct(IPlayerInput playerInput) => 
            _playerInput = playerInput;

        private void Awake()
        {
            _camera = Camera.main;
            _rotator = GetComponent<IRotator>();
        }

        private void FixedUpdate()
        {
            var worldPoint = _camera.ScreenToWorldPoint(_playerInput.Mouse);
            var direction = worldPoint - transform.position;
            _rotator.Rotate(to: direction.AsVector2());
        }
    }
}