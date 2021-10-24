using Components.Abstract;
using Infrastructure.InputLogic;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(IWeapon))]
    public class PlayerAttack : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IWeapon _weapon;

        public void Construct(IPlayerInput playerInput) => 
            _playerInput = playerInput;

        private void Awake() => 
            _weapon = GetComponent<IWeapon>();

        private void Update()
        {
            if (_playerInput.IsAttackButtonDown())
                _weapon.TryFire();
        }
    }
}