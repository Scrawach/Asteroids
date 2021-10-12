using UnityEngine;

namespace InputLogic
{
    public class PlayerInput : IPlayerInput
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Fire = "Fire";
        private const string AltFire = "AltFire";
        
        public Vector2 Axis =>
            new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical)).normalized;

        public Vector2 Mouse =>
            Input.mousePosition;
        
        public bool IsAttackButtonDown() => 
            Input.GetKeyDown(Fire);

        public bool IsAlternativeAttackButtonDown() => 
            Input.GetKeyDown(AltFire);
    }
}