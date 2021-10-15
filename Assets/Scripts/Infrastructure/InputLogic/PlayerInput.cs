using Infrastructure.AssetManagement;
using StaticData;
using UnityEngine;

namespace Infrastructure.InputLogic
{
    public class PlayerInput : IPlayerInput
    {
        private readonly string _horizontal;
        private readonly string _vertical;
        private readonly KeyCode _fire;
        private readonly KeyCode _altFire;

        public PlayerInput(string horizontalAxis, string verticalAxis, KeyCode fire, KeyCode altFire)
        {
            _horizontal = horizontalAxis;
            _vertical = verticalAxis;
            _fire = fire;
            _altFire = altFire;
        }
        
        public Vector2 Axis =>
            new Vector2(Input.GetAxis(_horizontal), Input.GetAxis(_vertical)).normalized;

        public Vector2 Mouse =>
            Input.mousePosition;
        
        public bool IsAttackButtonDown() => 
            Input.GetKeyDown(_fire);

        public bool IsAlternativeAttackButtonDown() => 
            Input.GetKeyDown(_altFire);
    }
}