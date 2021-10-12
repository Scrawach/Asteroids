using Components.Abstract;
using Extensions;
using InputLogic;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IEngine))]
    public class RotateToMouse : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IEngine _engine;
        private Camera _camera;

        public void Construct(IPlayerInput playerInput) => 
            _playerInput = playerInput;

        private void Awake()
        {
            _camera = Camera.main;
            _engine = GetComponent<IEngine>();
        }

        private void FixedUpdate()
        {
            var worldPoint = _camera.ScreenToWorldPoint(_playerInput.Mouse);
            var direction = worldPoint - transform.position;
            _engine.Rotate(to: direction.AsVector2());
        }
    }
}